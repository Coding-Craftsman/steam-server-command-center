using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace steam_server_command_center.Migrations
{
    /// <inheritdoc />
    public partial class enabledServersAddition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActiveServers");

            migrationBuilder.CreateTable(
                name: "EnabledServers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GameServerID = table.Column<int>(type: "INTEGER", nullable: false),
                    InstanceName = table.Column<string>(type: "TEXT", nullable: false),
                    ContainerID = table.Column<string>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnabledServers", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnabledServers");

            migrationBuilder.CreateTable(
                name: "ActiveServers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ContainerID = table.Column<string>(type: "TEXT", nullable: false),
                    GameServerID = table.Column<int>(type: "INTEGER", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActiveServers", x => x.ID);
                });
        }
    }
}
