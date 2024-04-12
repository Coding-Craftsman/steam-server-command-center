using Microsoft.CodeAnalysis.FlowAnalysis;
using Newtonsoft.Json;
using steam_server_command_center.Models.Interfaces;
using System.Diagnostics;

namespace steam_server_command_center.Models.ProjectZomboid
{
    public class ZomboidServer : IGameServer
    {
        /*
         * Still to do:
         * Write unit test for this!!!
         * Test the server
         * Figure out how to store the dockerfile contents for all games...
         * Zomboid Dual ID thingy
         * */
        /*
         * Process to setup server
         * 
         * 1. Download game files using steamcmd container
         * 2. Create runtime Dockerfile
         * 3. Create runtime docker container image
         * 4. Create server .ini file with configuration in it
         * 5. Start the server in detached mode.
         * 
         * */

        public const int GameID = 380870;
       
        public string ServerRoot { get; set; }

        public string InstallPath { get; set; } = "server";

        private const string dockerFileContents = """
            ######## INSTALL ########

            # Set the base image
            FROM ubuntu:22.04

            # Set environment variables
            ENV USER root
            ENV HOME /root

            # Set working directory
            WORKDIR $HOME

            # Insert Steam prompt answers
            SHELL ["/bin/bash", "-o", "pipefail", "-c"]
            RUN echo steam steam/question select "I AGREE" | debconf-set-selections \
             && echo steam steam/license note '' | debconf-set-selections

            # Update the repository and install SteamCMD
            ARG DEBIAN_FRONTEND=noninteractive
            RUN dpkg --add-architecture i386 \
             && apt-get update -y \
             && apt-get install -y --no-install-recommends ca-certificates locales steamcmd \
             && rm -rf /var/lib/apt/lists/*

            # Add unicode support
            RUN locale-gen en_US.UTF-8
            ENV LANG 'en_US.UTF-8'
            ENV LANGUAGE 'en_US:en'

            # Create symlink for executable
            RUN ln -s /usr/games/steamcmd /usr/bin/steamcmd

            # Update SteamCMD and verify latest version
            RUN steamcmd +quit

            # Fix missing directories and libraries
            RUN mkdir -p $HOME/.steam \
             && ln -s $HOME/.local/share/Steam/steamcmd/linux32 $HOME/.steam/sdk32 \
             && ln -s $HOME/.local/share/Steam/steamcmd/linux64 $HOME/.steam/sdk64 \
             && ln -s $HOME/.steam/sdk32/steamclient.so $HOME/.steam/sdk32/steamservice.so \
             && ln -s $HOME/.steam/sdk64/steamclient.so $HOME/.steam/sdk64/steamservice.so

            # Expose the server game ports
            EXPOSE 16261-16262/udp

            # Set default command
            WORKDIR /data
            ENTRYPOINT ["bash"]
            CMD ["./start_server.sh", "-adminpassword", "{0}"] 
            """; // need to change the password

        private ProjectZomboidConfiguration serverConfig;

        private EnabledServer enabledServerSettings;

        private CommandCenterContext context;

        public ZomboidServer(EnabledServer enabledServer, CommandCenterContext DataContext)
        {
            if(enabledServer.Configuration != null || enabledServer.Configuration.Length  != 0)
            {
                this.serverConfig = JsonConvert.DeserializeObject<ProjectZomboidConfiguration>(enabledServer.Configuration);
                this.context = DataContext;
                var appRootPath = context.Configuration.Where(c => c.Key == "global.settings.application_root").First().Value;
                ServerRoot = Path.Join(appRootPath, serverConfig.ServerRoot);
                InstallPath = Path.Join(ServerRoot, "server");
            }
        }

        public void CreateContainerImage()
        {
            var processInfo = new ProcessStartInfo
            {
                //LoadUserProfile = true,
                FileName = "powershell.exe",
                WorkingDirectory = ServerRoot,
                Arguments = "docker build -t projectzomboid-run-server-app .",
                //RedirectStandardOutput = false,
                UseShellExecute = true,
                CreateNoWindow = false
            };

            var p = Process.Start(processInfo);
            p.WaitForExit();
        }

        public void CreateDockerFile()
        {
            // first, write the content of the docker file out to the game server root path
            File.WriteAllText(Path.Combine(ServerRoot, "Dockerfile"), string.Format(dockerFileContents, serverConfig.AdminPassword));
        }

        public void CreateServerConfiguration()
        {
            // first, check to see if the config file exists, if it does, delete it
            //if(File.Exists(Path.Combine(GameRootFolderName)))
        }

        public void DownloadGameFiles()
        {
            //var serverPath = Path.Combine(ServerPath, Configuration.GameRootFolderName, "server");
            // start a process to kick off the docker download of the game.
            var processInfo = new ProcessStartInfo
            {
                FileName = "powershell.exe",
                WorkingDirectory = InstallPath,
                Arguments = "docker run -it -v " + InstallPath + ":/data steamcmd/steamcmd:latest +force_install_dir /data +login anonymous /data +app_update " + GameID + " +quit",
                UseShellExecute = true,
                CreateNoWindow = false
            };

            var p = Process.Start(processInfo);
            p.WaitForExit();
        }

        public async void StartServer()
        {
            var processInfo = new ProcessStartInfo
            {
                FileName = "powershell.exe",
                WorkingDirectory = InstallPath,
                Arguments = "docker run --rm -d -v " + InstallPath + ":/data\" -p '16261-16262:16261-16262/udp' projectzomboid-run-server-app",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = false
            };

            var p = Process.Start(processInfo);
            var id = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            enabledServerSettings.ContainerID = id;
            enabledServerSettings.Configuration = JsonConvert.SerializeObject(serverConfig);

            context.EnabledServers.Attach(enabledServerSettings);
            await context.SaveChangesAsync();
        }

        public void StopServer()
        {
            var processInfo = new ProcessStartInfo
            {
                FileName = "powershell.exe",
                WorkingDirectory = InstallPath,
                //Arguments = "docker stop " + Configuration.ContainerID,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = false
            };

            var p = Process.Start(processInfo);
            var id = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            enabledServerSettings.ContainerID = "";
            enabledServerSettings.Configuration = JsonConvert.SerializeObject(serverConfig);

            context.EnabledServers.Attach(enabledServerSettings);
            context.SaveChanges();
        }
    }
}
