using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using steam_server_command_center.Models;

namespace steam_server_command_center.Pages.GameServers
{
    public class CreateModel : PageModel
    {
        private readonly steam_server_command_center.Models.CommandCenterContext _context;

        public CreateModel(steam_server_command_center.Models.CommandCenterContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public GameServer GameServer { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.GameServers.Add(GameServer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
