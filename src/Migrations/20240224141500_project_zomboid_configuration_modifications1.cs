using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace steam_server_command_center.Migrations
{
    /// <inheritdoc />
    public partial class project_zomboid_configuration_modifications1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectZomboidConfigurations");

            migrationBuilder.AddColumn<string>(
                name: "AdminPassword",
                table: "EnabledServers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AdminSafehouse",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AllowCoop",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AllowDestructionBySledgehammer",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AllowNonAsciiUsername",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AnnounceDeath",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AntiCheatProtectionType1",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AntiCheatProtectionType10",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AntiCheatProtectionType11",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AntiCheatProtectionType12",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AntiCheatProtectionType13",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AntiCheatProtectionType14",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AntiCheatProtectionType15",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "AntiCheatProtectionType15ThresholdMultiplier",
                table: "EnabledServers",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AntiCheatProtectionType16",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AntiCheatProtectionType17",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AntiCheatProtectionType18",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AntiCheatProtectionType19",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AntiCheatProtectionType2",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AntiCheatProtectionType20",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "AntiCheatProtectionType20ThresholdMultiplier",
                table: "EnabledServers",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AntiCheatProtectionType21",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AntiCheatProtectionType22",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "AntiCheatProtectionType22ThresholdMultiplier",
                table: "EnabledServers",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AntiCheatProtectionType23",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AntiCheatProtectionType24",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "AntiCheatProtectionType24ThresholdMultiplier",
                table: "EnabledServers",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "AntiCheatProtectionType2ThresholdMultiplier",
                table: "EnabledServers",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AntiCheatProtectionType3",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "AntiCheatProtectionType3ThresholdMultiplier",
                table: "EnabledServers",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AntiCheatProtectionType4",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "AntiCheatProtectionType4ThresholdMultiplier",
                table: "EnabledServers",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AntiCheatProtectionType6",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AntiCheatProtectionType7",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AntiCheatProtectionType8",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AntiCheatProtectionType9",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "AntiCheatProtectionType9ThresholdMultiplier",
                table: "EnabledServers",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AutoCreateUserInWhiteList",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BackupsCount",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "BackupsOnStart",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "BackupsOnVersionChange",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BackupsPeriod",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "BanKickGlobalSound",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BloodSplatLifespanDays",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "CarEngineAttractionModifier",
                table: "EnabledServers",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ChatStreams",
                table: "EnabledServers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClientActionLogs",
                table: "EnabledServers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClientCommandFilter",
                table: "EnabledServers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConfigFileLocation",
                table: "EnabledServers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ConstructionPreventsLootRespawn",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DefaultPort",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "DenyLoginOnOverloadedServer",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "DisableRadioAdmin",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "DisableRadioGM",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "DisableRadioInvisible",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "DisableRadioModerator",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "DisableRadioOverseer",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "DisableRadioStaff",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "DisableSafehouseWhenPlayerConnected",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DiscordChannel",
                table: "EnabledServers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DiscordChannelID",
                table: "EnabledServers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "DiscordEnable",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DiscordToken",
                table: "EnabledServers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "EnabledServers",
                type: "TEXT",
                maxLength: 34,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "DisplayUserName",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "DoLuaChecksum",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "DropOffWhiteListAfterDeath",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Faction",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FactionDaySurvivedToCreate",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FactionPlayersRequiredForTag",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "FastForwardMultiplier",
                table: "EnabledServers",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "GlobalChat",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HidePlayersBehindYou",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HoursForLootRespawn",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItemNumbersLimitPerContainer",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "KickFastPlayers",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "KnockedDownAllowed",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoginQueueConnectTimeout",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "LoginQueueEnabled",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Map",
                table: "EnabledServers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MapRemotePlayerVisibility",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaxAccountsPerUser",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaxItemsForLootRespawn",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaxPlayers",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MinutesPerPage",
                table: "EnabledServers",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mods",
                table: "EnabledServers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "MouseOverToSeeDisplayName",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "NoFire",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Open",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PVP",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "PVPFirearmDamageModifier",
                table: "EnabledServers",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "PVPMeleeDamageModifier",
                table: "EnabledServers",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PVPMeleeWhileHitReaction",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "EnabledServers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PauseEmpty",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PerkLogs",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PingLimit",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PlayerBumpPlayer",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PlayerRespawnWithOther",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PlayerRespawnWithSelf",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PlayerSafehouse",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Public",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PublicDescription",
                table: "EnabledServers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PublicName",
                table: "EnabledServers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RCONPassword",
                table: "EnabledServers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RCONPort",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "RemovePlayerCorpsesOnCorpseRemoval",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ResetID",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SafeHouseRemovalTime",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SafehouseAllowFire",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SafehouseAllowLoot",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SafehouseAllowNonResidential",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SafehouseAllowRespawn",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SafehouseAllowTrepass",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SafehouseDaySurvivedToClaim",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SafetyCooldownTimer",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SafetySystem",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SafetyToggleTimer",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SaveWorldEveryMinutes",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServerHome",
                table: "EnabledServers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ServerInstanceID",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServerName",
                table: "EnabledServers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServerPlayerID",
                table: "EnabledServers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServerWelcomeMessage",
                table: "EnabledServers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ShowFirstAndLastName",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ShowSafety",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SledgehammerOnlyInSafehouse",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SleepAllowed",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SleepNeeded",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SneakModeHideFromOtherPlayers",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpawnItems",
                table: "EnabledServers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpawnPoint",
                table: "EnabledServers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "SpeedLimit",
                table: "EnabledServers",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SteamScoreboard",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SteamVAC",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TrashDeleteAll",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UDPPort",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "UPnP",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Voice3D",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "VoiceEnable",
                table: "EnabledServers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "VoiceMaxDistance",
                table: "EnabledServers",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "VoiceMinDistance",
                table: "EnabledServers",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorkshopItems",
                table: "EnabledServers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "server_browser_announced_ip",
                table: "EnabledServers",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdminPassword",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "AdminSafehouse",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "AllowCoop",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "AllowDestructionBySledgehammer",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "AllowNonAsciiUsername",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "AnnounceDeath",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "AntiCheatProtectionType1",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "AntiCheatProtectionType10",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "AntiCheatProtectionType11",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "AntiCheatProtectionType12",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "AntiCheatProtectionType13",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "AntiCheatProtectionType14",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "AntiCheatProtectionType15",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "AntiCheatProtectionType15ThresholdMultiplier",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "AntiCheatProtectionType16",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "AntiCheatProtectionType17",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "AntiCheatProtectionType18",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "AntiCheatProtectionType19",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "AntiCheatProtectionType2",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "AntiCheatProtectionType20",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "AntiCheatProtectionType20ThresholdMultiplier",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "AntiCheatProtectionType21",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "AntiCheatProtectionType22",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "AntiCheatProtectionType22ThresholdMultiplier",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "AntiCheatProtectionType23",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "AntiCheatProtectionType24",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "AntiCheatProtectionType24ThresholdMultiplier",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "AntiCheatProtectionType2ThresholdMultiplier",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "AntiCheatProtectionType3",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "AntiCheatProtectionType3ThresholdMultiplier",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "AntiCheatProtectionType4",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "AntiCheatProtectionType4ThresholdMultiplier",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "AntiCheatProtectionType6",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "AntiCheatProtectionType7",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "AntiCheatProtectionType8",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "AntiCheatProtectionType9",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "AntiCheatProtectionType9ThresholdMultiplier",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "AutoCreateUserInWhiteList",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "BackupsCount",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "BackupsOnStart",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "BackupsOnVersionChange",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "BackupsPeriod",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "BanKickGlobalSound",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "BloodSplatLifespanDays",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "CarEngineAttractionModifier",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "ChatStreams",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "ClientActionLogs",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "ClientCommandFilter",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "ConfigFileLocation",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "ConstructionPreventsLootRespawn",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "DefaultPort",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "DenyLoginOnOverloadedServer",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "DisableRadioAdmin",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "DisableRadioGM",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "DisableRadioInvisible",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "DisableRadioModerator",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "DisableRadioOverseer",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "DisableRadioStaff",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "DisableSafehouseWhenPlayerConnected",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "DiscordChannel",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "DiscordChannelID",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "DiscordEnable",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "DiscordToken",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "DisplayUserName",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "DoLuaChecksum",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "DropOffWhiteListAfterDeath",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "Faction",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "FactionDaySurvivedToCreate",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "FactionPlayersRequiredForTag",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "FastForwardMultiplier",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "GlobalChat",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "HidePlayersBehindYou",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "HoursForLootRespawn",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "ItemNumbersLimitPerContainer",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "KickFastPlayers",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "KnockedDownAllowed",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "LoginQueueConnectTimeout",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "LoginQueueEnabled",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "Map",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "MapRemotePlayerVisibility",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "MaxAccountsPerUser",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "MaxItemsForLootRespawn",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "MaxPlayers",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "MinutesPerPage",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "Mods",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "MouseOverToSeeDisplayName",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "NoFire",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "Open",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "PVP",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "PVPFirearmDamageModifier",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "PVPMeleeDamageModifier",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "PVPMeleeWhileHitReaction",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "PauseEmpty",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "PerkLogs",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "PingLimit",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "PlayerBumpPlayer",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "PlayerRespawnWithOther",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "PlayerRespawnWithSelf",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "PlayerSafehouse",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "Public",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "PublicDescription",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "PublicName",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "RCONPassword",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "RCONPort",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "RemovePlayerCorpsesOnCorpseRemoval",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "ResetID",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "SafeHouseRemovalTime",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "SafehouseAllowFire",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "SafehouseAllowLoot",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "SafehouseAllowNonResidential",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "SafehouseAllowRespawn",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "SafehouseAllowTrepass",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "SafehouseDaySurvivedToClaim",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "SafetyCooldownTimer",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "SafetySystem",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "SafetyToggleTimer",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "SaveWorldEveryMinutes",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "ServerHome",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "ServerInstanceID",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "ServerName",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "ServerPlayerID",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "ServerWelcomeMessage",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "ShowFirstAndLastName",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "ShowSafety",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "SledgehammerOnlyInSafehouse",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "SleepAllowed",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "SleepNeeded",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "SneakModeHideFromOtherPlayers",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "SpawnItems",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "SpawnPoint",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "SpeedLimit",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "SteamScoreboard",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "SteamVAC",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "TrashDeleteAll",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "UDPPort",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "UPnP",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "Voice3D",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "VoiceEnable",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "VoiceMaxDistance",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "VoiceMinDistance",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "WorkshopItems",
                table: "EnabledServers");

            migrationBuilder.DropColumn(
                name: "server_browser_announced_ip",
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
                });
        }
    }
}
