using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using steam_server_command_center.Models;
using Object_Change_Tracker;
using System.Threading.Channels;

namespace steam_server_command_center.Pages.GameServers
{
    public class EditModel : PageModel
    {
        private readonly steam_server_command_center.Models.CommandCenterContext _context;

        public EditModel(steam_server_command_center.Models.CommandCenterContext context)
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

            var gameserver =  await _context.GameServers.FirstOrDefaultAsync(m => m.ID == id);
            if (gameserver == null)
            {
                return NotFound();
            }
            GameServer = gameserver;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var originalObject = _context.GameServers.AsNoTracking().Where(g => g.ID == GameServer.ID).FirstOrDefault();

            ChangeDetector changeDetector = new ChangeDetector();

            List<Change> changes = changeDetector.GetChanges(originalObject, GameServer, "user", DateTime.Now);

            if (changes.Any())
            {
                foreach (Change change in changes)
                {
                    CommandCenterChange dbChange = new CommandCenterChange(change);
                    _context.Changes.Add(dbChange);
                }
            }

            _context.Attach(GameServer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameServerExists(GameServer.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool GameServerExists(int id)
        {
            return _context.GameServers.Any(e => e.ID == id);
        }
    }
}
