using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using steam_server_command_center.Models;
using steam_server_command_center.Models.Interfaces;
using steam_server_command_center.Models.ServerStatus;
using Object_Change_Tracker;

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

        [FromQuery(Name = "ID")]
        public int ID { get; set; }

        [BindProperty]
        public ServerStatus ServerStatus { get; set; } = default!;

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

            ServerStatus = new ServerStatus()
            {
                ContainterID = enabledserver.ContainerID.Trim(),
                EnabledServerID = enabledserver.ID
            };

            ServerStatus.CheckStatus();

            if(ServerStatus.StatusColor == "Green")
            {
                EnabledServer.IsActive = true;
            }

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

                var originalEntity = _context.EnabledServers.AsNoTracking().Where(c => c.ID == entity.ID).FirstOrDefault();
                
                Object_Change_Tracker.ChangeDetector changeDetector = new Object_Change_Tracker.ChangeDetector();

                List<Change> changes = changeDetector.GetChanges(originalEntity, entity, "user", DateTime.Now);

                if(changes.Any())
                {
                    foreach (Change change in changes)
                    {
                        CommandCenterChange dbChange = new CommandCenterChange(change);
                        _context.Changes.Add(dbChange);
                    }
                }

                _context.Attach(entity).State = EntityState.Modified;
            }
            else
            {
                return RedirectToPage("./Index");
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

        public IActionResult OnPostSetup(int id)
        {
            // get the game server configuration
            IGameServer server = GameServerFactory.GetGameServer(id, _context);           

            // run download command
            server.DownloadGameFiles();

            // return to manage page
            return RedirectToPage("Edit", new { id = id });
        }

        public async Task<IActionResult> OnPostStart(int id)
        {
            // get the game server configuration
            IGameServer server = GameServerFactory.GetGameServer(id, _context);

            // call the start command
            server.StartServer();

            return RedirectToPage("Edit", new { id = id });
        }


        public async Task<IActionResult> OnPostStop(int id)
        {
            // get the game server configuration
            IGameServer server = GameServerFactory.GetGameServer(id, _context);

            // call the stop command
            server.StopServer();

            return RedirectToPage("Edit", new { id = id });
        }

        private bool EnabledServerExists(int id)
        {
            return _context.EnabledServers.Any(e => e.ID == id);
        }
    }
}
