using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using steam_server_command_center.Models;

namespace steam_server_command_center.Pages.Configuration
{
    public class IndexModel : PageModel
    {
        private readonly steam_server_command_center.Models.CommandCenterContext _context;

        public IndexModel(steam_server_command_center.Models.CommandCenterContext context)
        {
            _context = context;
        }

        public IList<ConfigurationItem> ConfigurationItem { get;set; } = default!;

        public async Task OnGetAsync()
        {
            ConfigurationItem = await _context.Configuration.ToListAsync();
        }
    }
}
