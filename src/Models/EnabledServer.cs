using System.ComponentModel;

namespace steam_server_command_center.Models
{
    /// <summary>
    /// An enabled server is a game server that has been created to run on this local machine.
    ///  this stores the game ID, the name the user has given this server and the docker
    ///  container ID that is running the game
    /// </summary>
    public class EnabledServer
    {
        public int ID { get; set; }
        
        [DisplayName("Game Server ID")]
        public int GameServerID { get; set; }

        /// <summary>
        /// Steam ID for the game server
        /// </summary>
        public int SteamAppID { get; set; }

        // this is the name of the game instance in the UI
        [DisplayName("Instance Name")]
        public string InstanceName { get; set; }

        // the docker container ID for managing it (if it's running)
        [DisplayName("Container ID")]
        public string? ContainerID { get; set; }

        // active means that it should be running at all times
        [DisplayName("Active")]
        public bool IsActive { get; set; }

        public string Configuration { get; set; }

        /// <summary>
        /// The absolute path the the install directory
        /// </summary>
        [DisplayName("Serve Root")]
        public string InstalledPath { get; set; }

        [DisplayName("Game Name")]
        public string GameName
        {
            get
            {
                switch (SteamAppID)
                {
                    // Valheim
                    case 896660:
                        return "Valheim";
                    // Zomboid
                    case 380870:
                        return "Project Zomboid";
                    default:
                        return "Unknown";
                }
            }
        }
        
        public string EditPageRoute()
        {
            switch (SteamAppID)
            {
                // Valheim
                case 896660:
                    return "/ValheimServer/Edit";
                // Zomboid
                case 380870:
                    return "/ProjectZomboid/Edit";
                default:
                    return "/Index";
            }
        }


        public EnabledServer()
        {
            ID = 0;
            GameServerID = 0;
            InstanceName = string.Empty;
            ContainerID = string.Empty;
            IsActive = false;
            Configuration = string.Empty;
        }
    }
}
