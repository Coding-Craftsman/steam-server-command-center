using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using steam_server_command_center.Models;

namespace steam_server_command_center.Pages.ValheimServer
{
    public class EditModel : PageModel
    {
        private readonly steam_server_command_center.Models.CommandCenterContext _context;

        public EditModel(steam_server_command_center.Models.CommandCenterContext context)
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

            var enabledServer = await _context.EnabledServers.Where(g => g.ID == id).FirstOrDefaultAsync();
            
            if(enabledServer == null)
            {
                return NotFound();
            }

            ValheimConfiguration valheimconfiguration = new ValheimConfiguration(_context, enabledServer.ID);
            valheimconfiguration.ID = enabledServer.ID;
            valheimconfiguration.GameServerID = enabledServer.GameServerID;

            //var valheimconfiguration =  await _context.ValheimConfiguration.FirstOrDefaultAsync(m => m.ID == id);
            if (valheimconfiguration == null)
            {
                return NotFound();
            }
            ValheimConfiguration = valheimconfiguration;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            ValheimConfiguration.CommandCenterContext = _context;

            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            
            await ValheimConfiguration.SaveSettings();

            return RedirectToPage("./Index");
        }
    }
}
