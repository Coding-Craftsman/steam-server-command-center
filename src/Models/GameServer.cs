using System.ComponentModel;

namespace steam_server_command_center.Models
{
    /// <summary>
    /// A game server is a generic container for all the available games for this application to manage.  
    ///  it is used to store basic server information.
    /// </summary>
    public class GameServer
    {
        /// <summary>
        /// DatabaseId
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Steam ID for the game server
        /// </summary>
        [DisplayName("Steam App ID")]
        public int SteamAppID { get; set; }

        /// <summary>
        /// Game name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// URL for the logo of the game to display in the app
        /// </summary>
        [DisplayName("Logo")]
        public string LogoUrl { get; set; }

        public GameServer()
        {
            ID = 0;
            SteamAppID = 0;
            Name = string.Empty;
            LogoUrl = string.Empty;
        }
    }
}
