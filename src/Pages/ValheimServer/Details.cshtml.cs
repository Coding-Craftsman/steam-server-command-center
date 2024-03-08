using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using steam_server_command_center.Models;

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

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ID = (int)id;

            ValheimConfiguration valheimconfiguration = new ValheimConfiguration(_context, (int)id);
            
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
            ValheimConfiguration ValheimConfiguration = new ValheimConfiguration(_context, id);

            var rootPath = _context.Configuration.Where(c => c.Key == "global.settings.game_server_root").FirstOrDefault();

            if (rootPath != null)
            {
                Models.ValheimServer server = new Models.ValheimServer(ValheimConfiguration, rootPath.Value);
                await server.StartServer();
            }

            return RedirectToPage("Details", new { id = id });
        }

        public IActionResult OnPostDownload(int id)
        {
            ValheimConfiguration ValheimConfiguration = new ValheimConfiguration(_context, id);

            var rootPath = _context.Configuration.Where(c => c.Key == "global.settings.game_server_root").FirstOrDefault();

            if (rootPath != null)
            {
                Models.ValheimServer server = new Models.ValheimServer(ValheimConfiguration, rootPath.Value);
                server.DownloadGameContent();
            }

            return RedirectToPage("Details", new { id = id });
        }

        public IActionResult OnPostStop(int id)
        {
            ValheimConfiguration ValheimConfiguration = new ValheimConfiguration(_context, id);

            var rootPath = _context.Configuration.Where(c => c.Key == "global.settings.game_server_root").FirstOrDefault();

            if (rootPath != null)
            {
                Models.ValheimServer server = new Models.ValheimServer(ValheimConfiguration, rootPath.Value);
                server.StopServer();
            }

            return RedirectToPage("Details", new { id = id });
        }
    }
}
