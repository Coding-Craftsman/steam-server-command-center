using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using steam_server_command_center.Models;
using steam_server_command_center.Models.ProjectZomboid;
using steam_server_command_center.Models.Valheim;
using Newtonsoft.Json;

namespace steam_server_command_center.Pages.GameServers
{
    public class CreateInstanceModel : PageModel
    {
        private readonly Models.CommandCenterContext _context;

        public CreateInstanceModel(Models.CommandCenterContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var gameServer = await _context.GameServers.FirstOrDefaultAsync(s => s.ID == id);
            if(gameServer == null) 
            {
                return NotFound();
            }

            // found a game server, now determine what config page we should return
            switch(gameServer.SteamAppID)
            {
                // Valheim
                case 896660:
                    // first, create the new instance of the Valheim config
                    ValheimConfiguration valheimConfig = new ValheimConfiguration();
                    EnabledServer enabledValheimServer = new EnabledServer();
                    enabledValheimServer.GameServerID = gameServer.ID;
                    enabledValheimServer.IsActive = false;
                    enabledValheimServer.Configuration = JsonConvert.SerializeObject(valheimConfig);
                    enabledValheimServer.SteamAppID = gameServer.SteamAppID;                    
                    
                    _context.EnabledServers.Add(enabledValheimServer);
                    await _context.SaveChangesAsync();

                    return RedirectToPage("/ValheimServer/Edit", new { id = enabledValheimServer.ID });
                // Zomboid
                case 380870:
                    // create an instance of Project Zomboid config
                    ProjectZomboidConfiguration zomboidConfig = new ProjectZomboidConfiguration();
                    EnabledServer enabledServer = new EnabledServer();
                    enabledServer.GameServerID = gameServer.ID;
                    enabledServer.IsActive = false;
                    enabledServer.Configuration = JsonConvert.SerializeObject(zomboidConfig);
                    enabledServer.SteamAppID = gameServer.SteamAppID;

                    _context.EnabledServers.Add(enabledServer);
                    await _context.SaveChangesAsync();

                    return RedirectToPage("/ProjectZomboid/Edit", new {id = enabledServer.ID});
                default:
                    return RedirectToPage("/Index");
            }
        }
    }
}
