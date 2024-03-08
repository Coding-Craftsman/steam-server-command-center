using Microsoft.EntityFrameworkCore;
using steam_server_command_center.Models;
using steam_server_command_center.Models.ProjectZomboid;

namespace steam_server_command_center.Models
{
    public class CommandCenterContext : DbContext
    {
        public DbSet<EnabledServer> EnabledServers { get; set; }
        public DbSet<ConfigurationItem> Configuration { get; set; }
        public DbSet<GameServer> GameServers { get; set; }
        //public DbSet<ProjectZomboidConfiguration> ProjectZomboidConfigurations {get;set;}

        public string DbPath { get; }

        public CommandCenterContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "SteamCommandCenter.db");
        }

        // The following configures EF to create a Sqlite database in the special "local" folder on your platform
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EnabledServer>().UseTptMappingStrategy();
            //modelBuilder.Entity<ProjectZomboidConfiguration>().UseTptMappingStrategy();
        }
        //public DbSet<steam_server_command_center.Models.ValheimConfiguration> ValheimConfiguration { get; set; } = default!;
    }
}
