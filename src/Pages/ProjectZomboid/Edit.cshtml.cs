using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using steam_server_command_center.Models;
using steam_server_command_center.Models.ProjectZomboid;

namespace steam_server_command_center.Pages.ProjectZomboid
{
    public class EditModel : PageModel
    {
        private readonly CommandCenterContext _context;

        public EditModel(CommandCenterContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ProjectZomboidConfiguration ProjectZomboidConfiguration { get; set; } = default!;

        [FromQuery(Name = "ID" )]
        public int id { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enabledServer = await _context.EnabledServers.FindAsync(id);

            if(enabledServer == null || enabledServer.Configuration == null || enabledServer.Configuration.Length == 0)
            {
                return NotFound();
            }

            ProjectZomboidConfiguration = JsonConvert.DeserializeObject<ProjectZomboidConfiguration>(enabledServer.Configuration);
            
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

            if(enabledServer == null)
            {
                return NotFound();
            }

            enabledServer.Configuration = JsonConvert.SerializeObject(ProjectZomboidConfiguration);

            _context.Attach(ProjectZomboidConfiguration).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return RedirectToPage("./Index");
        }
    }
}
