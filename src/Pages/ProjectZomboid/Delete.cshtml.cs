using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using steam_server_command_center.Models;
using steam_server_command_center.Models.ProjectZomboid;
using Object_Change_Tracker;

namespace steam_server_command_center.Pages.ProjectZomboid
{
    public class DeleteModel : PageModel
    {
        private readonly steam_server_command_center.Models.CommandCenterContext _context;

        public DeleteModel(steam_server_command_center.Models.CommandCenterContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ProjectZomboidConfiguration ProjectZomboidConfiguration { get; set; } = default!;

        [FromQuery(Name = "ID")]
        public int id { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var server = await _context.EnabledServers.FindAsync(id);

            if(server == null)
            {
                return NotFound();
            }

            var projectzomboidconfiguration = JsonConvert.DeserializeObject<ProjectZomboidConfiguration>(server.Configuration);

            if (projectzomboidconfiguration == null)
            {
                return NotFound();
            }
            else
            {
                ProjectZomboidConfiguration = projectzomboidconfiguration;
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
            
            if (server != null)
            {
                ChangeDetector changeDetector = new ChangeDetector();

                List<Change> changes = changeDetector.GetChanges(server, new EnabledServer(), "user", DateTime.Now);

                if (changes.Any())
                {
                    foreach (Change change in changes)
                    {
                        CommandCenterChange dbChange = new CommandCenterChange(change);
                        _context.Changes.Add(dbChange);
                    }
                }
            
                _context.EnabledServers.Remove(server);
                await _context.SaveChangesAsync();
            }           

            return RedirectToPage("./Index");
        }
    }
}
