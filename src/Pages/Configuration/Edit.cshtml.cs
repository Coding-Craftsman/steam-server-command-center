using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Object_Change_Tracker;
using steam_server_command_center.Models;

namespace steam_server_command_center.Pages.Configuration
{
    public class EditModel : PageModel
    {
        private readonly steam_server_command_center.Models.CommandCenterContext _context;

        public EditModel(steam_server_command_center.Models.CommandCenterContext context)
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

            var configurationitem =  await _context.Configuration.FirstOrDefaultAsync(m => m.ID == id);
            if (configurationitem == null)
            {
                return NotFound();
            }
            ConfigurationItem = configurationitem;
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

            // setup a change detector
            Object_Change_Tracker.ChangeDetector changeDetector = new Object_Change_Tracker.ChangeDetector();

            var originalObject = _context.Configuration.AsNoTracking().Where(c => c.ID == ConfigurationItem.ID).FirstOrDefault();

            List<Change> changes = changeDetector.GetChanges(originalObject, ConfigurationItem, "user", DateTime.Now);

            if(changes.Any())
            {
                foreach (Change change in changes)
                {
                    CommandCenterChange dbChange = new CommandCenterChange(change);
                    _context.Changes.Add(dbChange);
                }
            }           

            _context.Attach(ConfigurationItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConfigurationItemExists(ConfigurationItem.ID))
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

        private bool ConfigurationItemExists(int id)
        {
            return _context.Configuration.Any(e => e.ID == id);
        }
    }
}
