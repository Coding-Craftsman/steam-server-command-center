using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using steam_server_command_center.Models;

namespace steam_server_command_center.Pages.ValheimServer
{
    public class IndexModel : PageModel
    {
        private readonly steam_server_command_center.Models.CommandCenterContext _context;

        public IndexModel(steam_server_command_center.Models.CommandCenterContext context)
        {
            _context = context;
        }

        public IList<ValheimConfiguration> ValheimConfiguration { get;set; } = default!;

        public async Task OnGetAsync()
        {
            var game = await _context.GameServers.Where(g => g.SteamAppID == 896660).FirstAsync();

            List<EnabledServer> items = await _context.EnabledServers.Where(i => i.GameServerID == game.ID).ToListAsync();

            ValheimConfiguration = new List<ValheimConfiguration>();

            foreach(var item in items)
            {
                ValheimConfiguration.Add(new ValheimConfiguration(_context, item.ID));
            }
        }
    }
}
