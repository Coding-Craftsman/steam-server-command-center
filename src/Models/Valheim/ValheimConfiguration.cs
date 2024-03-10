using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace steam_server_command_center.Models.Valheim
{
    [NotMapped]
    public class ValheimConfiguration
    {
        // gameserver.settings.valheim.servername.<instanceID>
        [DisplayName("Server Name")]
        public string ServerName { get; set; } = string.Empty;

        // gameserver.settings.valheim.worldname.<instanceID>
        [DisplayName("World Name")]
        public string WorldName { get; set; } = string.Empty;

        // gameserver.settings.valheim.password.<InstanceID>
        [DisplayName("Server Password")]
        public string Password {  get; set; } = string.Empty;

        public string startServerScriptName { get; set; } = "start_server.sh";

        // The modified contents of the start_server.sh file.  Note that it has {} for the fields 
        //  that the app can modify to make a custom start
        public string startScriptContent { get; set; } = @"
            #!/bin/bash
            export templdpath=$LD_LIBRARY_PATH
            export LD_LIBRARY_PATH=./linux64:$LD_LIBRARY_PATH
            export SteamAppId=892970

            echo ""Starting server PRESS CTRL-C to exit""

            # Tip: Make a local copy of this script to avoid it being overwritten by steam.
            # NOTE: Minimum password length is 5 characters & Password cant be in the server name.
            # NOTE: You need to make sure the ports 2456-2458 is being forwarded to your server through your local router & firewall.
            ./valheim_server.x86_64 -name ""{0}"" -port 2456 -world ""{1}"" -password ""{2}"" 

            export LD_LIBRARY_PATH=$templdpath
            ";

        // This is the contents of the docker file that is used to create a custom docker container
        //  image for this game server.
        public string dockerFileContents { get; set; } = """
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
            EXPOSE 2456-2457/udp
            
            # Set default command
            WORKDIR /data
            ENTRYPOINT ["bash"]
            CMD ["./start_server.sh"] 
            """;
        
        public string GameRootFolderName { get; set; } = "Valheim-896660";        
    }
}
