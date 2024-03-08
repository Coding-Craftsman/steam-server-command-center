using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using steam_server_command_center.Models;

namespace steam_server_command_center.Pages.EnabledServers
{
    public class EditModel : PageModel
    {
        private readonly steam_server_command_center.Models.CommandCenterContext _context;

        public EditModel(steam_server_command_center.Models.CommandCenterContext context)
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

            var enabledserver =  await _context.EnabledServers.FirstOrDefaultAsync(m => m.ID == id);
            if (enabledserver == null)
            {
                return NotFound();
            }
            EnabledServer = enabledserver;
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

            var entity = await _context.EnabledServers.FindAsync(EnabledServer.ID);

            if(entity != null)
            {
                entity.InstanceName = EnabledServer.InstanceName;
                entity.IsActive = EnabledServer.IsActive;

                _context.Attach(entity).State = EntityState.Modified;
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnabledServerExists(EnabledServer.ID))
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

        private bool EnabledServerExists(int id)
        {
            return _context.EnabledServers.Any(e => e.ID == id);
        }
    }
}
