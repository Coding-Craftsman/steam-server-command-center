using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using steam_server_command_center.Models;

namespace steam_server_command_center.Pages.Configuration
{
    public class IndexModel : PageModel
    {
        private readonly steam_server_command_center.Models.CommandCenterContext _context;
        private readonly CommandCenterApplicationSettings _appSettings;

        public IndexModel(steam_server_command_center.Models.CommandCenterContext context, IOptions<CommandCenterApplicationSettings> appSettings)
        {
            _context = context;
            _appSettings = appSettings.Value;
        }

        public IList<ConfigurationItem> ConfigurationItems { get;set; } = default!;

        public async Task OnGetAsync()
        {
            ConfigurationItems = await _context.Configuration.ToListAsync();

            // now add in any appsettings.json configurations we want to see in the app

            // Database path
            if(_appSettings.DatabasePath == null || _appSettings.DatabasePath.Length == 0)
            {
                ConfigurationItems.Add(new ConfigurationItem() { ID = -1, Key = "DatabasePath", Value = _context.DbPath });
            }
            else
            {
                ConfigurationItems.Add(new ConfigurationItem() { ID = -1, Key = "DatabasePath", Value = _appSettings.DatabasePath });
            }
        }
    }
}
