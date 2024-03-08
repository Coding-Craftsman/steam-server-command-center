using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using steam_server_command_center.Models;

namespace steam_server_command_center.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public string headingValue { get; set; } = "Initial Value";

    [BindProperty]
    public string ServerRoot { get; set; } = string.Empty;

    private readonly steam_server_command_center.Models.CommandCenterContext _context;

    public IndexModel(ILogger<IndexModel> logger, steam_server_command_center.Models.CommandCenterContext context)
    {
        _logger = logger;
        _context = context;

        var setting = _context.Configuration.Where(v => v.Key == "global.settings.game_server_root").FirstOrDefault();
        
        if(setting != null) 
        { 
            ServerRoot = setting.Value;
        }
    }

    public void OnGet()
    {
        
    }

    public async Task<IActionResult> OnPostUpdateServerRoot()
    {
        // first check to see if the key exists
        var setting = _context.Configuration.Where(v => v.Key == "global.settings.game_server_root").FirstOrDefault();

        if (setting == null)
        {
            setting = new ConfigurationItem();
            setting.Key = "global.settings.game_server_root";
            setting.Value = ServerRoot;
            _context.Configuration.Add(setting);
        }
        else
        {
            setting.Value = ServerRoot;

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
