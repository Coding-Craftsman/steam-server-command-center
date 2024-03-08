using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using steam_server_command_center.Models;
using steam_server_command_center.Models.ProjectZomboid;

namespace steam_server_command_center.Pages.ProjectZomboid
{
    public class IndexModel : PageModel
    {
        private readonly steam_server_command_center.Models.CommandCenterContext _context;

        public IndexModel(steam_server_command_center.Models.CommandCenterContext context)
        {
            _context = context;
        }

        public IList<ProjectZomboidConfiguration> ProjectZomboidConfiguration { get;set; } = default!;

        public async Task OnGetAsync()
        {
            //ProjectZomboidConfiguration = await _context.ProjectZomboidConfigurations.ToListAsync();
        }
    }
}
