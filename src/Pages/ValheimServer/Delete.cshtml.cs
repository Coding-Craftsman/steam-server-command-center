using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using steam_server_command_center.Models.Valheim;

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

            var enabledServer = await _context.EnabledServers.FindAsync(id);

            if (enabledServer != null)
            {
                if(enabledServer.Configuration != null)
                {
                    ValheimConfiguration valheimconfiguration = JsonConvert.DeserializeObject<ValheimConfiguration>(enabledServer.Configuration);
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return NotFound();
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
                _context.EnabledServers.Remove(server);
                
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
