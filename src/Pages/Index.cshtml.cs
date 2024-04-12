using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using steam_server_command_center.Models;
using steam_server_command_center.Models.ServerStatus;

namespace steam_server_command_center.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public string headingValue { get; set; } = "Initial Value";

    [BindProperty]
    public string ApplicationRoot { get; set; } = string.Empty;

    [BindProperty]
    public List<ServerStatus> ActiveServers { get; set; } = new List<ServerStatus>();

    private readonly steam_server_command_center.Models.CommandCenterContext _context;

    public IndexModel(ILogger<IndexModel> logger, steam_server_command_center.Models.CommandCenterContext context)
    {
        _logger = logger;
        _context = context;

        ConfigurationItem? setting = null;

        setting = _context.Configuration.Where(v => v.Key == "global.settings.application_root").FirstOrDefault();

        if(setting == null)
        {
            setting = _context.Configuration.Where(v => v.Key == "global.settings.game_server_root").FirstOrDefault();

            if(setting != null)
            {
                _context.Configuration.Remove(setting);
                _context.SaveChanges();

                setting.Key = "global.settings.application_root";
                _context.Configuration.Add(setting);

                _context.SaveChanges();
            }
        }
        
        
        if(setting != null) 
        { 
            ApplicationRoot = setting.Value;
        }

        var servers = _context.EnabledServers.Where(s => s.ContainerID != null || s.ContainerID.Length == 0).ToArray();

        foreach(var server in servers)
        {
            ServerStatus item = new ServerStatus()
            {
                ContainterID = server.ContainerID,
                EnabledServerID = server.ID,
                InstanceName = server.InstanceName
            };

            item.CheckStatus();
            ActiveServers.Add(item);
        }
    }

    public void OnGet()
    {
        
    }

    public async Task<IActionResult> OnPostUpdateServerRoot()
    {
        // first check to see if the key exists
        var setting = _context.Configuration.Where(v => v.Key == "global.settings.application_root").FirstOrDefault();

        if (setting == null)
        {
            setting = new ConfigurationItem();
            setting.Key = "global.settings.application_root";
            setting.Value = ApplicationRoot;
            _context.Configuration.Add(setting);
        }
        else
        {
            setting.Value = ApplicationRoot;

            _context.Attach(setting).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
        
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }

    public void OnPostTest()
    {
        //ValheimServer server = new ValheimServer();
        //server.ServerPath = ServerRoot;
        //server.DownloadGameContent();
        //server.CreateRuntimeContainer();
        //server.StartServer();
    }
}
