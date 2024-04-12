using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using steam_server_command_center.Models;
using Object_Change_Tracker;

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

                ChangeDetector changeDetector = new ChangeDetector();

                List<Change> changes = changeDetector.GetChanges(GameServer, new GameServer(), "user", DateTime.Now);
                
                if (changes.Any())
                {
                    foreach (Change change in changes)
                    {
                        CommandCenterChange dbChange = new CommandCenterChange(change);
                        _context.Changes.Add(dbChange);
                    }
                }

                _context.GameServers.Remove(GameServer);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
