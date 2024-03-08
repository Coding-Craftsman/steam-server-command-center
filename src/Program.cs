using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using steam_server_command_center.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<CommandCenterContext>();
var app = builder.Build();

using var scope = app.Services.CreateScope();

//CommandCenterContext context = scope.ServiceProvider.GetRequiredService<CommandCenterContext>;

//if (context != null)
//{    
    //context.Database.Migrate();
//}

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
