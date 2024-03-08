using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace steam_server_command_center.Migrations
{
    /// <inheritdoc />
    public partial class UpdateActiveServers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GameServerID",
                table: "ActiveServers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GameServerID",
                table: "ActiveServers");
        }
    }
}
