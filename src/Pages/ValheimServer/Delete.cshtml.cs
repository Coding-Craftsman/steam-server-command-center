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
    public class DeleteModel : PageModel
    {
        private readonly steam_server_command_center.Models.CommandCenterContext _context;

        public DeleteModel(steam_server_command_center.Models.CommandCenterContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ValheimConfiguration ValheimConfiguration { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }            

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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var server = await _context.EnabledServers.FindAsync(id);

            //var valheimconfiguration = await _context.ValheimConfiguration.FindAsync(id);
            if (server != null)
            {
                EnabledServer enabledServer = server;
                //ValheimConfiguration = valheimconfiguration;
                _context.EnabledServers.Remove(enabledServer);

                foreach (string key in ValheimConfiguration.ServerSettingKeys)
                {
                    // now delete all the server configs for this instance
                    ConfigurationItem setting = _context.Configuration.Where(c => c.Key == string.Format(key, id)).FirstOrDefault();
                    if (setting != null)
                    {
                        _context.Configuration.Remove(setting);
                    }
                }
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
