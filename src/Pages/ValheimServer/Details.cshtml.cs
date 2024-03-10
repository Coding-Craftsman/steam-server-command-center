using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using steam_server_command_center.Models.Valheim;

namespace steam_server_command_center.Pages.ValheimServer
{
    public class DetailsModel : PageModel
    {
        private readonly steam_server_command_center.Models.CommandCenterContext _context;

        public DetailsModel(steam_server_command_center.Models.CommandCenterContext context)
        {
            _context = context;
        }

        public int ID { get; set; }

        public ValheimConfiguration ValheimConfiguration { get; set; } = default!;

        [FromQuery(Name = "ID")]
        public int id { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ID = (int)id;

            ValheimConfiguration valheimconfiguration = new ValheimConfiguration();
            
            if (valheimconfiguration == null)
            {
                return NotFound();
            }
            else
            {
                ValheimConfiguration = valheimconfiguration;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostStart(int id)
        {
            ValheimConfiguration ValheimConfiguration = new ValheimConfiguration();

            var rootPath = _context.Configuration.Where(c => c.Key == "global.settings.game_server_root").FirstOrDefault();

            if (rootPath != null)
            {
                var enabledServer = await _context.EnabledServers.FindAsync(id);
                Models.Valheim.ValheimServer server = new Models.Valheim.ValheimServer(ValheimConfiguration, rootPath.Value, enabledServer, _context);
                await server.StartServer();
            }

            return RedirectToPage("Details", new { id = id });
        }

        public IActionResult OnPostDownload(int id)
        {
            ValheimConfiguration ValheimConfiguration = new ValheimConfiguration();

            var rootPath = _context.Configuration.Where(c => c.Key == "global.settings.game_server_root").FirstOrDefault();

            if (rootPath != null)
            {
                var enabledServer = _context.EnabledServers.Find(id);
                Models.Valheim.ValheimServer server = new Models.Valheim.ValheimServer(ValheimConfiguration, rootPath.Value, enabledServer, _context);
                server.DownloadGameContent();
            }

            return RedirectToPage("Details", new { id = id });
        }

        public IActionResult OnPostStop(int id)
        {
            ValheimConfiguration ValheimConfiguration = new ValheimConfiguration();

            var rootPath = _context.Configuration.Where(c => c.Key == "global.settings.game_server_root").FirstOrDefault();

            if (rootPath != null)
            {
                var enabledServer = _context.EnabledServers.Find(id);
                Models.Valheim.ValheimServer server = new Models.Valheim.ValheimServer(ValheimConfiguration, rootPath.Value, enabledServer, _context);
                server.StopServer();
            }

            return RedirectToPage("Details", new { id = id });
        }
    }
}
