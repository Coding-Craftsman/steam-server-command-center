using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace steam_server_command_center.Migrations
{
    /// <inheritdoc />
    public partial class merged_game_enabled_models : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectZomboidConfigurations");

            migrationBuilder.AddColumn<string>(
                name: "Configuration",
                table: "EnabledServers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Configuration",
                table: "EnabledServers");

            migrationBuilder.CreateTable(
                name: "ProjectZomboidConfigurations",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AdminPassword = table.Column<string>(type: "TEXT", nullable: false),
                    AdminSafehouse = table.Column<bool>(type: "INTEGER", nullable: false),
                    AllowCoop = table.Column<bool>(type: "INTEGER", nullable: false),
                    AllowDestructionBySledgehammer = table.Column<bool>(type: "INTEGER", nullable: false),
                    AllowNonAsciiUsername = table.Column<bool>(type: "INTEGER", nullable: false),
                    AnnounceDeath = table.Column<bool>(type: "INTEGER", nullable: false),
                    AntiCheatProtectionType1 = table.Column<bool>(type: "INTEGER", nullable: false),
                    AntiCheatProtectionType10 = table.Column<bool>(type: "INTEGER", nullable: false),
                    AntiCheatProtectionType11 = table.Column<bool>(type: "INTEGER", nullable: false),
                    AntiCheatProtectionType12 = table.Column<bool>(type: "INTEGER", nullable: false),
                    AntiCheatProtectionType13 = table.Column<bool>(type: "INTEGER", nullable: false),
                    AntiCheatProtectionType14 = table.Column<bool>(type: "INTEGER", nullable: false),
                    AntiCheatProtectionType15 = table.Column<bool>(type: "INTEGER", nullable: false),
                    AntiCheatProtectionType15ThresholdMultiplier = table.Column<double>(type: "REAL", nullable: false),
                    AntiCheatProtectionType16 = table.Column<bool>(type: "INTEGER", nullable: false),
                    AntiCheatProtectionType17 = table.Column<bool>(type: "INTEGER", nullable: false),
                    AntiCheatProtectionType18 = table.Column<bool>(type: "INTEGER", nullable: false),
                    AntiCheatProtectionType19 = table.Column<bool>(type: "INTEGER", nullable: false),
                    AntiCheatProtectionType2 = table.Column<bool>(type: "INTEGER", nullable: false),
                    AntiCheatProtectionType20 = table.Column<bool>(type: "INTEGER", nullable: false),
                    AntiCheatProtectionType20ThresholdMultiplier = table.Column<double>(type: "REAL", nullable: false),
                    AntiCheatProtectionType21 = table.Column<bool>(type: "INTEGER", nullable: false),
                    AntiCheatProtectionType22 = table.Column<bool>(type: "INTEGER", nullable: false),
                    AntiCheatProtectionType22ThresholdMultiplier = table.Column<double>(type: "REAL", nullable: false),
                    AntiCheatProtectionType23 = table.Column<bool>(type: "INTEGER", nullable: false),
                    AntiCheatProtectionType24 = table.Column<bool>(type: "INTEGER", nullable: false),
                    AntiCheatProtectionType24ThresholdMultiplier = table.Column<double>(type: "REAL", nullable: false),
                    AntiCheatProtectionType2ThresholdMultiplier = table.Column<double>(type: "REAL", nullable: false),
                    AntiCheatProtectionType3 = table.Column<bool>(type: "INTEGER", nullable: false),
                    AntiCheatProtectionType3ThresholdMultiplier = table.Column<double>(type: "REAL", nullable: false),
                    AntiCheatProtectionType4 = table.Column<bool>(type: "INTEGER", nullable: false),
                    AntiCheatProtectionType4ThresholdMultiplier = table.Column<double>(type: "REAL", nullable: false),
                    AntiCheatProtectionType6 = table.Column<bool>(type: "INTEGER", nullable: false),
                    AntiCheatProtectionType7 = table.Column<bool>(type: "INTEGER", nullable: false),
                    AntiCheatProtectionType8 = table.Column<bool>(type: "INTEGER", nullable: false),
                    AntiCheatProtectionType9 = table.Column<bool>(type: "INTEGER", nullable: false),
                    AntiCheatProtectionType9ThresholdMultiplier = table.Column<double>(type: "REAL", nullable: false),
                    AutoCreateUserInWhiteList = table.Column<bool>(type: "INTEGER", nullable: false),
                    BackupsCount = table.Column<int>(type: "INTEGER", nullable: false),
                    BackupsOnStart = table.Column<bool>(type: "INTEGER", nullable: false),
                    BackupsOnVersionChange = table.Column<bool>(type: "INTEGER", nullable: false),
                    BackupsPeriod = table.Column<int>(type: "INTEGER", nullable: false),
                    BanKickGlobalSound = table.Column<bool>(type: "INTEGER", nullable: false),
                    BloodSplatLifespanDays = table.Column<int>(type: "INTEGER", nullable: false),
                    CarEngineAttractionModifier = table.Column<double>(type: "REAL", nullable: false),
                    ChatStreams = table.Column<string>(type: "TEXT", nullable: false),
                    ClientActionLogs = table.Column<string>(type: "TEXT", nullable: false),
                    ClientCommandFilter = table.Column<string>(type: "TEXT", nullable: false),
                    ConfigFileLocation = table.Column<string>(type: "TEXT", nullable: false),
                    ConstructionPreventsLootRespawn = table.Column<bool>(type: "INTEGER", nullable: false),
                    DefaultPort = table.Column<int>(type: "INTEGER", nullable: false),
                    DenyLoginOnOverloadedServer = table.Column<bool>(type: "INTEGER", nullable: false),
                    DisableRadioAdmin = table.Column<bool>(type: "INTEGER", nullable: false),
                    DisableRadioGM = table.Column<bool>(type: "INTEGER", nullable: false),
                    DisableRadioInvisible = table.Column<bool>(type: "INTEGER", nullable: false),
                    DisableRadioModerator = table.Column<bool>(type: "INTEGER", nullable: false),
                    DisableRadioOverseer = table.Column<bool>(type: "INTEGER", nullable: false),
                    DisableRadioStaff = table.Column<bool>(type: "INTEGER", nullable: false),
                    DisableSafehouseWhenPlayerConnected = table.Column<bool>(type: "INTEGER", nullable: false),
                    DiscordChannel = table.Column<string>(type: "TEXT", nullable: false),
                    DiscordChannelID = table.Column<string>(type: "TEXT", nullable: false),
                    DiscordEnable = table.Column<bool>(type: "INTEGER", nullable: false),
                    DiscordToken = table.Column<string>(type: "TEXT", nullable: false),
                    DisplayUserName = table.Column<bool>(type: "INTEGER", nullable: false),
                    DoLuaChecksum = table.Column<bool>(type: "INTEGER", nullable: false),
                    DropOffWhiteListAfterDeath = table.Column<bool>(type: "INTEGER", nullable: false),
                    Faction = table.Column<bool>(type: "INTEGER", nullable: false),
                    FactionDaySurvivedToCreate = table.Column<int>(type: "INTEGER", nullable: false),
                    FactionPlayersRequiredForTag = table.Column<int>(type: "INTEGER", nullable: false),
                    FastForwardMultiplier = table.Column<double>(type: "REAL", nullable: false),
                    GlobalChat = table.Column<bool>(type: "INTEGER", nullable: false),
                    HidePlayersBehindYou = table.Column<bool>(type: "INTEGER", nullable: false),
                    HoursForLootRespawn = table.Column<int>(type: "INTEGER", nullable: false),
                    ItemNumbersLimitPerContainer = table.Column<int>(type: "INTEGER", nullable: false),
                    KickFastPlayers = table.Column<bool>(type: "INTEGER", nullable: false),
                    KnockedDownAllowed = table.Column<bool>(type: "INTEGER", nullable: false),
                    LoginQueueConnectTimeout = table.Column<int>(type: "INTEGER", nullable: false),
                    LoginQueueEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    Map = table.Column<string>(type: "TEXT", nullable: false),
                    MapRemotePlayerVisibility = table.Column<int>(type: "INTEGER", nullable: false),
                    MaxAccountsPerUser = table.Column<int>(type: "INTEGER", nullable: false),
                    MaxItemsForLootRespawn = table.Column<int>(type: "INTEGER", nullable: false),
                    MaxPlayers = table.Column<int>(type: "INTEGER", nullable: false),
                    MinutesPerPage = table.Column<double>(type: "REAL", nullable: false),
                    Mods = table.Column<string>(type: "TEXT", nullable: false),
                    MouseOverToSeeDisplayName = table.Column<bool>(type: "INTEGER", nullable: false),
                    NoFire = table.Column<bool>(type: "INTEGER", nullable: false),
                    Open = table.Column<bool>(type: "INTEGER", nullable: false),
                    PVP = table.Column<bool>(type: "INTEGER", nullable: false),
                    PVPFirearmDamageModifier = table.Column<double>(type: "REAL", nullable: false),
                    PVPMeleeDamageModifier = table.Column<double>(type: "REAL", nullable: false),
                    PVPMeleeWhileHitReaction = table.Column<bool>(type: "INTEGER", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    PauseEmpty = table.Column<bool>(type: "INTEGER", nullable: false),
                    PerkLogs = table.Column<bool>(type: "INTEGER", nullable: false),
                    PingLimit = table.Column<int>(type: "INTEGER", nullable: false),
                    PlayerBumpPlayer = table.Column<bool>(type: "INTEGER", nullable: false),
                    PlayerRespawnWithOther = table.Column<bool>(type: "INTEGER", nullable: false),
                    PlayerRespawnWithSelf = table.Column<bool>(type: "INTEGER", nullable: false),
                    PlayerSafehouse = table.Column<bool>(type: "INTEGER", nullable: false),
                    Public = table.Column<bool>(type: "INTEGER", nullable: false),
                    PublicDescription = table.Column<string>(type: "TEXT", nullable: false),
                    PublicName = table.Column<string>(type: "TEXT", nullable: false),
                    RCONPassword = table.Column<string>(type: "TEXT", nullable: false),
                    RCONPort = table.Column<int>(type: "INTEGER", nullable: false),
                    RemovePlayerCorpsesOnCorpseRemoval = table.Column<bool>(type: "INTEGER", nullable: false),
                    ResetID = table.Column<int>(type: "INTEGER", nullable: false),
                    SafeHouseRemovalTime = table.Column<int>(type: "INTEGER", nullable: false),
                    SafehouseAllowFire = table.Column<bool>(type: "INTEGER", nullable: false),
                    SafehouseAllowLoot = table.Column<bool>(type: "INTEGER", nullable: false),
                    SafehouseAllowNonResidential = table.Column<bool>(type: "INTEGER", nullable: false),
                    SafehouseAllowRespawn = table.Column<bool>(type: "INTEGER", nullable: false),
                    SafehouseAllowTrepass = table.Column<bool>(type: "INTEGER", nullable: false),
                    SafehouseDaySurvivedToClaim = table.Column<int>(type: "INTEGER", nullable: false),
                    SafetyCooldownTimer = table.Column<int>(type: "INTEGER", nullable: false),
                    SafetySystem = table.Column<bool>(type: "INTEGER", nullable: false),
                    SafetyToggleTimer = table.Column<int>(type: "INTEGER", nullable: false),
                    SaveWorldEveryMinutes = table.Column<int>(type: "INTEGER", nullable: false),
                    ServerHome = table.Column<string>(type: "TEXT", nullable: false),
                    ServerInstanceID = table.Column<int>(type: "INTEGER", nullable: false),
                    ServerName = table.Column<string>(type: "TEXT", nullable: false),
                    ServerPlayerID = table.Column<string>(type: "TEXT", nullable: false),
                    ServerWelcomeMessage = table.Column<string>(type: "TEXT", nullable: false),
                    ShowFirstAndLastName = table.Column<bool>(type: "INTEGER", nullable: false),
                    ShowSafety = table.Column<bool>(type: "INTEGER", nullable: false),
                    SledgehammerOnlyInSafehouse = table.Column<bool>(type: "INTEGER", nullable: false),
                    SleepAllowed = table.Column<bool>(type: "INTEGER", nullable: false),
                    SleepNeeded = table.Column<bool>(type: "INTEGER", nullable: false),
                    SneakModeHideFromOtherPlayers = table.Column<bool>(type: "INTEGER", nullable: false),
                    SpawnItems = table.Column<string>(type: "TEXT", nullable: false),
                    SpawnPoint = table.Column<string>(type: "TEXT", nullable: false),
                    SpeedLimit = table.Column<double>(type: "REAL", nullable: false),
                    SteamScoreboard = table.Column<bool>(type: "INTEGER", nullable: false),
                    SteamVAC = table.Column<bool>(type: "INTEGER", nullable: false),
                    TrashDeleteAll = table.Column<bool>(type: "INTEGER", nullable: false),
                    UDPPort = table.Column<int>(type: "INTEGER", nullable: false),
                    UPnP = table.Column<bool>(type: "INTEGER", nullable: false),
                    Voice3D = table.Column<bool>(type: "INTEGER", nullable: false),
                    VoiceEnable = table.Column<bool>(type: "INTEGER", nullable: false),
                    VoiceMaxDistance = table.Column<double>(type: "REAL", nullable: false),
                    VoiceMinDistance = table.Column<double>(type: "REAL", nullable: false),
                    WorkshopItems = table.Column<string>(type: "TEXT", nullable: false),
                    server_browser_announced_ip = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectZomboidConfigurations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProjectZomboidConfigurations_EnabledServers_ID",
                        column: x => x.ID,
                        principalTable: "EnabledServers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });
        }
    }
}
