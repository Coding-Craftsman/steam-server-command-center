using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Object_Change_Tracker;
using steam_server_command_center.Models;

namespace steam_server_command_center.Pages.Configuration
{
    public class DeleteModel : PageModel
    {
        private readonly steam_server_command_center.Models.CommandCenterContext _context;

        public DeleteModel(steam_server_command_center.Models.CommandCenterContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ConfigurationItem ConfigurationItem { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var configurationitem = await _context.Configuration.FirstOrDefaultAsync(m => m.ID == id);

            if (configurationitem == null)
            {
                return NotFound();
            }
            else
            {
                ConfigurationItem = configurationitem;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var configurationitem = await _context.Configuration.FindAsync(id);
            if (configurationitem != null)
            {
                ConfigurationItem = configurationitem;

                Object_Change_Tracker.ChangeDetector changeDetector = new Object_Change_Tracker.ChangeDetector();

                List<Change> changes = changeDetector.GetChanges(ConfigurationItem, new ConfigurationItem(), "user", DateTime.Now);

                if (changes.Any())
                {
                    foreach (Change change in changes)
                    {
                        CommandCenterChange dbChange = new CommandCenterChange(change);
                        _context.Changes.Add(dbChange);
                    }
                }

                _context.Configuration.Remove(ConfigurationItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
