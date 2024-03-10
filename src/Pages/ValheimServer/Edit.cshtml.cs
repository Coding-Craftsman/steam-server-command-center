﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using steam_server_command_center.Models.Valheim;

namespace steam_server_command_center.Pages.ValheimServer
{
    public class EditModel : PageModel
    {
        private readonly steam_server_command_center.Models.CommandCenterContext _context;

        public EditModel(steam_server_command_center.Models.CommandCenterContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ValheimConfiguration ValheimConfiguration { get; set; } = default!;

        [FromQuery(Name = "ID")]
        public int id { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enabledServer = await _context.EnabledServers.FindAsync(id);
            
            if(enabledServer == null)
            {
                return NotFound();
            }

            ValheimConfiguration valheimconfiguration = JsonConvert.DeserializeObject<ValheimConfiguration>(enabledServer.Configuration);            

            //var valheimconfiguration =  await _context.ValheimConfiguration.FirstOrDefaultAsync(m => m.ID == id);
            if (valheimconfiguration == null)
            {
                return NotFound();
            }
            ValheimConfiguration = valheimconfiguration;
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

            var enabledServer = await _context.EnabledServers.FindAsync(id);

            enabledServer.Configuration = JsonConvert.SerializeObject(ValheimConfiguration);

            _context.EnabledServers.Attach(enabledServer);
            await _context.SaveChangesAsync();

            return RedirectToPage("/EnabledServers/Index");
        }
    }
}
