using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using steam_server_command_center.Models;


/*
 * Application Terms:
 * Application Root: The absolute path the the topmost folder for this application
 * 
 * Server Root: The path inside the app root path where everything for this game is saved
 * 
 * Install Path: the path inside the server root path where the game server is installed
 * */
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<CommandCenterContext>();

// setup getting the configuration values from the appsettings.json file
builder.Services.AddOptions<CommandCenterApplicationSettings>()
    .BindConfiguration("CommandCenterApplicationSettings");

// configured the application settings as a service so we can inject them 
//  into other classes
builder.Services.Configure<CommandCenterApplicationSettings>(
    builder.Configuration.GetSection("CommandCenterApplicationSettings"));

var app = builder.Build();

using var scope = app.Services.CreateScope();

CommandCenterContext context = scope.ServiceProvider.GetRequiredService<CommandCenterContext>();

if (context != null)
{    
    context.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
