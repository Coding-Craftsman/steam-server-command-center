using Newtonsoft.Json;
using steam_server_command_center.Models.Interfaces;
using System.Diagnostics;

namespace steam_server_command_center.Models.Valheim
{
    public class ValheimServer : IGameServer
    {
        // the path to the application root server level (i.e. E:\steam-server-command-center)
        public string ApplicationRoot { get; set; } = "";

        public ValheimConfiguration Configuration { get; set; }

        private EnabledServer enabledServerSettings;

        private CommandCenterContext _context;

        // This is the start script for the Valheim server that runs in the docker container.
        //  We need to update this script with any customizations that need to be added to the
        //   base game
        //private string startServerScriptName { get; set; } = "start_server.sh";

        // The modified contents of the start_server.sh file.  Note that it has {} for the fields 
        //  that the app can modify to make a custom start
        //private string startScriptContent { get; set; } = @"
        //    #!/bin/bash
        //    export templdpath=$LD_LIBRARY_PATH
        //    export LD_LIBRARY_PATH=./linux64:$LD_LIBRARY_PATH
        //    export SteamAppId=892970

        //    echo ""Starting server PRESS CTRL-C to exit""

        //    # Tip: Make a local copy of this script to avoid it being overwritten by steam.
        //    # NOTE: Minimum password length is 5 characters & Password cant be in the server name.
        //    # NOTE: You need to make sure the ports 2456-2458 is being forwarded to your server through your local router & firewall.
        //    ./valheim_server.x86_64 -name ""{0}"" -port 2456 -world ""{1}"" -password ""{2}"" 

        //    export LD_LIBRARY_PATH=$templdpath
        //    ";

        // This is the contents of the docker file that is used to create a custom docker container
        //  image for this game server.
        //private string dockerFileContents { get; set; } = """
        //    ######## INSTALL ########

        //    # Set the base image
        //    FROM ubuntu:22.04

        //    # Set environment variables
        //    ENV USER root
        //    ENV HOME /root

        //    # Set working directory
        //    WORKDIR $HOME

        //    # Insert Steam prompt answers
        //    SHELL ["/bin/bash", "-o", "pipefail", "-c"]
        //    RUN echo steam steam/question select "I AGREE" | debconf-set-selections \
        //     && echo steam steam/license note '' | debconf-set-selections

        //    # Update the repository and install SteamCMD
        //    ARG DEBIAN_FRONTEND=noninteractive
        //    RUN dpkg --add-architecture i386 \
        //     && apt-get update -y \
        //     && apt-get install -y --no-install-recommends ca-certificates locales steamcmd \
        //     && rm -rf /var/lib/apt/lists/*

        //    # Add unicode support
        //    RUN locale-gen en_US.UTF-8
        //    ENV LANG 'en_US.UTF-8'
        //    ENV LANGUAGE 'en_US:en'

        //    # Create symlink for executable
        //    RUN ln -s /usr/games/steamcmd /usr/bin/steamcmd

        //    # Update SteamCMD and verify latest version
        //    RUN steamcmd +quit

        //    # Fix missing directories and libraries
        //    RUN mkdir -p $HOME/.steam \
        //     && ln -s $HOME/.local/share/Steam/steamcmd/linux32 $HOME/.steam/sdk32 \
        //     && ln -s $HOME/.local/share/Steam/steamcmd/linux64 $HOME/.steam/sdk64 \
        //     && ln -s $HOME/.steam/sdk32/steamclient.so $HOME/.steam/sdk32/steamservice.so \
        //     && ln -s $HOME/.steam/sdk64/steamclient.so $HOME/.steam/sdk64/steamservice.so

        //    # Expose the server game ports
        //    EXPOSE 2456-2457/udp

        //    # Set default command
        //    WORKDIR /data
        //    ENTRYPOINT ["bash"]
        //    CMD ["./start_server.sh"] 
        //    """;

        public ValheimServer(EnabledServer enabledServer, CommandCenterContext context)
        {
            ApplicationRoot = context.Configuration.Where(c => c.Key == "global.settings.application_root").First().Value;
            Configuration = JsonConvert.DeserializeObject<ValheimConfiguration>(enabledServer.Configuration);
            this.enabledServerSettings = enabledServer;
            _context = context;
        }

        public void CreateContainerImage()
        {
            var gameRootPath = Path.Combine(ApplicationRoot, Configuration.ServerRoot);

            var processInfo = new ProcessStartInfo
            {
                //LoadUserProfile = true,
                FileName = "powershell.exe",
                WorkingDirectory = gameRootPath,
                Arguments = "docker build -t valheim-run-server-app .",
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
            File.WriteAllText(Path.Combine(ApplicationRoot, Configuration.ServerRoot, "Dockerfile"), Configuration.dockerFileContents);
        }

        public void CreateServerConfiguration()
        {
            var serverPath = Path.Combine(ApplicationRoot, Configuration.ServerRoot, "server");

            updateStartScript(Path.Combine(serverPath, Configuration.startServerScriptName));
        }

        /// <summary>
        /// Creates an instance of the SteamCMD container and downloads all the game data for 
        ///  this server.
        /// </summary>
        public void DownloadGameFiles()
        {
            checkServerPath();

            if (!Directory.Exists(Path.Combine(ApplicationRoot, Configuration.ServerRoot)))
            {
                Directory.CreateDirectory(Path.Combine(ApplicationRoot, Configuration.ServerRoot));
            }

            if (!Directory.Exists(Path.Combine(ApplicationRoot, Configuration.ServerRoot, "server")))
            {
                Directory.CreateDirectory(Path.Combine(ApplicationRoot, Configuration.ServerRoot, "server"));
            }

            var serverPath = Path.Combine(ApplicationRoot, Configuration.ServerRoot, "server");
            // start a process to kick off the docker download of the game.
            var processInfo = new ProcessStartInfo
            {
                //LoadUserProfile = true,
                FileName = "powershell.exe",
                WorkingDirectory = serverPath,
                Arguments = "docker run -it -v " + serverPath + ":/data steamcmd/steamcmd:latest +force_install_dir /data +login anonymous /data +app_update 896660 +quit",
                UseShellExecute = true,
                CreateNoWindow = false
            };

            var p = Process.Start(processInfo);
            p.WaitForExit();

            // update the start script
            updateStartScript(Path.Combine(serverPath, Configuration.startServerScriptName));
        }

        /// <summary>
        /// Starts an instance of the custom runtime game server.  This server runs detached and will remove itself
        ///  when the container stops.  All the game files will remain on the local machine to be used by other
        ///  containers in the future.
        /// </summary>
        /// <returns></returns>
        public async void StartServer()
        {
            var installPath = Path.Combine(ApplicationRoot, Configuration.ServerRoot, "server");

            updateStartScript(Path.Combine(installPath, Configuration.startServerScriptName));

            var processInfo = new ProcessStartInfo
            {
                LoadUserProfile = true,
                FileName = "powershell.exe",
                WorkingDirectory = installPath,
                Arguments = "docker run --rm -d -v " + installPath + ":/data\" -p '2456-2457:2456-2457/udp' valheim-run-server-app",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false, // try this?
                CreateNoWindow = false
            };

            var p = Process.Start(processInfo);
            StreamReader streamReader = p.StandardError;

            var id = p.StandardOutput.ReadToEnd();
            p.WaitForExit();

            Console.WriteLine(streamReader.ReadLine());

            enabledServerSettings.ContainerID = id;
            _context.EnabledServers.Attach(enabledServerSettings);
            await _context.SaveChangesAsync();
            //await Configuration.SaveSettings();
        }

        /// <summary>
        /// Stops the current runtime container based on the saved container ID
        /// </summary>
        /// <returns></returns>
        public void StopServer()
        {
            var installPath = Path.Combine(ApplicationRoot, Configuration.ServerRoot, "server");

            updateStartScript(Path.Combine(installPath, Configuration.startServerScriptName));

            var processInfo = new ProcessStartInfo
            {
                FileName = "powershell.exe",
                WorkingDirectory = installPath,
                Arguments = "docker stop " + enabledServerSettings.ContainerID,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = false
            };

            var p = Process.Start(processInfo);
            var id = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            enabledServerSettings.ContainerID = "";
            _context.EnabledServers.Attach(enabledServerSettings);
            _context.SaveChanges();
            //await Configuration.SaveSettings();
        }

        /// <summary>
        /// Checks to make sure the application Root path where all the servers will be stored
        ///  exists.
        /// </summary>
        private void checkServerPath()
        {
            // check to see if the folder in the server path exists, if it doesn't create it
            if (ApplicationRoot != null || ApplicationRoot != "")
            {
                if (!Directory.Exists(ApplicationRoot))
                {
                    // create the directory
                    Directory.CreateDirectory(ApplicationRoot);
                }
            }
        }

        
        /// <summary>
        /// Creates a new dockerfile and uses it to create a new custom container that will run
        ///  this game server.
        /// </summary>
        public void CreateRuntimeContainer()
        {
            
            
        }

        /// <summary>
        /// Deletes the default start_server.sh file and replaces it with our customized one
        ///  with the current server configuration
        /// </summary>
        /// <param name="scriptPath"></param>
        private void updateStartScript(string scriptPath)
        {
            // first, delete the file
            File.Delete(scriptPath);

            // now write the new contents of the file
            File.WriteAllText(scriptPath,
                        string.Format(Configuration.startScriptContent,
                            Configuration.ServerName,
                            Configuration.WorldName,
                            Configuration.Password));
        }
    }
}
