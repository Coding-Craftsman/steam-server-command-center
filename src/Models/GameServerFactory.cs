using steam_server_command_center.Models.Interfaces;
using steam_server_command_center.Models.ProjectZomboid;
using steam_server_command_center.Models.Valheim;

namespace steam_server_command_center.Models
{
    public static class GameServerFactory
    {
        public static IGameServer GetGameServer(int InstanceID, CommandCenterContext Context)
        {
            IGameServer retVal = null;

            var steamAppID = Context.EnabledServers.Where(e => e.ID == InstanceID).FirstOrDefault().SteamAppID;
            
            if(steamAppID != null)
            {
                EnabledServer? server;
                switch((int)steamAppID)
                {
                    case 380870:
                        // Zomboid server
                        server = Context.EnabledServers.Find(InstanceID);
                        retVal = new ZomboidServer(server, Context);
                        break;
                    case 896660:
                        // valheim server
                        server = Context.EnabledServers.Find(InstanceID);
                        retVal = new ValheimServer(server, Context);
                        break;
                }
            }

            return retVal;
        }
    }
}
