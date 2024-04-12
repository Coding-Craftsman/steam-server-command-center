using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace steam_server_command_center.Migrations
{
    /// <inheritdoc />
    public partial class enabled_server_install_path : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InstalledPath",
                table: "EnabledServers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InstalledPath",
                table: "EnabledServers");
        }
    }
}
