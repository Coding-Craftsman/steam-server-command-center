using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using steam_server_command_center.Models;

namespace steam_server_command_center.Pages.EnabledServers
{
    public class DeleteModel : PageModel
    {
        private readonly steam_server_command_center.Models.CommandCenterContext _context;

        public DeleteModel(steam_server_command_center.Models.CommandCenterContext context)
        {
            _context = context;
        }

        [BindProperty]
        public EnabledServer EnabledServer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enabledserver = await _context.EnabledServers.FirstOrDefaultAsync(m => m.ID == id);

            if (enabledserver == null)
            {
                return NotFound();
            }
            else
            {
                EnabledServer = enabledserver;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enabledserver = await _context.EnabledServers.FindAsync(id);
            if (enabledserver != null)
            {
                EnabledServer = enabledserver;
                _context.EnabledServers.Remove(EnabledServer);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
