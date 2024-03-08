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

namespace steam_server_command_center.Pages.ProjectZomboid
{
    public class DetailsModel : PageModel
    {
        private readonly steam_server_command_center.Models.CommandCenterContext _context;

        public DetailsModel(steam_server_command_center.Models.CommandCenterContext context)
        {
            _context = context;
        }

        public ProjectZomboidConfiguration ProjectZomboidConfiguration { get; set; } = default!;

        [FromQuery(Name = "ID")]
        public int id { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enableServer = await _context.EnabledServers.FindAsync(id);

            if(enableServer == null)
            {
                return NotFound();
            }
            var projectzomboidconfiguration = JsonConvert.DeserializeObject<ProjectZomboidConfiguration>(enableServer.Configuration);
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
    }
}
