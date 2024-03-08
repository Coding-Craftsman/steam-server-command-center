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
    public class DetailsModel : PageModel
    {
        private readonly steam_server_command_center.Models.CommandCenterContext _context;

        public DetailsModel(steam_server_command_center.Models.CommandCenterContext context)
        {
            _context = context;
        }

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
    }
}
