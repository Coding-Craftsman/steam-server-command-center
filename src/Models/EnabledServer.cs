using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using steam_server_command_center.Models.Interfaces;
using steam_server_command_center.Models.ProjectZomboid;

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

        public int GameServerID { get; set; }

        /// <summary>
        /// Steam ID for the game server
        /// </summary>
        public int SteamAppID { get; set; }

        // this is the name of the game instance in the UI
        public string InstanceName { get; set; }

        // the docker container ID for managing it (if it's running)
        public string? ContainerID { get; set; }

        // active means that it should be running at all times
        public bool IsActive { get; set; } 

        public string Configuration { get; set; }
        
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
