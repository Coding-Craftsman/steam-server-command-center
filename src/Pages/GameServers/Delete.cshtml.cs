using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using steam_server_command_center.Models;

namespace steam_server_command_center.Pages.GameServers
{
    public class DeleteModel : PageModel
    {
        private readonly steam_server_command_center.Models.CommandCenterContext _context;

        public DeleteModel(steam_server_command_center.Models.CommandCenterContext context)
        {
            _context = context;
        }

        [BindProperty]
        public GameServer GameServer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameserver = await _context.GameServers.FirstOrDefaultAsync(m => m.ID == id);

            if (gameserver == null)
            {
                return NotFound();
            }
            else
            {
                GameServer = gameserver;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameserver = await _context.GameServers.FindAsync(id);
            if (gameserver != null)
            {
                GameServer = gameserver;
                _context.GameServers.Remove(GameServer);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
