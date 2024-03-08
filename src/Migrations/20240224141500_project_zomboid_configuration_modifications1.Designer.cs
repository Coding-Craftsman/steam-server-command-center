﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using steam_server_command_center.Models;

#nullable disable

namespace steam_server_command_center.Migrations
{
    [DbContext(typeof(CommandCenterContext))]
    [Migration("20240224141500_project_zomboid_configuration_modifications1")]
    partial class project_zomboid_configuration_modifications1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.2");

            modelBuilder.Entity("steam_server_command_center.Models.ConfigurationItem", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Configuration");
                });

            modelBuilder.Entity("steam_server_command_center.Models.EnabledServer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ContainerID")
                        .HasColumnType("TEXT");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(34)
                        .HasColumnType("TEXT");

                    b.Property<int>("GameServerID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("InstanceName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.ToTable("EnabledServers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("EnabledServer");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("steam_server_command_center.Models.GameServer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("LogoUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("SteamAppID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.ToTable("GameServers");
                });

            modelBuilder.Entity("steam_server_command_center.Models.ProjectZomboid.ProjectZomboidConfiguration", b =>
                {
                    b.HasBaseType("steam_server_command_center.Models.EnabledServer");

                    b.Property<string>("AdminPassword")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("AdminSafehouse")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("AllowCoop")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("AllowDestructionBySledgehammer")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("AllowNonAsciiUsername")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("AnnounceDeath")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("AntiCheatProtectionType1")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("AntiCheatProtectionType10")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("AntiCheatProtectionType11")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("AntiCheatProtectionType12")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("AntiCheatProtectionType13")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("AntiCheatProtectionType14")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("AntiCheatProtectionType15")
                        .HasColumnType("INTEGER");

                    b.Property<double>("AntiCheatProtectionType15ThresholdMultiplier")
                        .HasColumnType("REAL");

                    b.Property<bool>("AntiCheatProtectionType16")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("AntiCheatProtectionType17")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("AntiCheatProtectionType18")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("AntiCheatProtectionType19")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("AntiCheatProtectionType2")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("AntiCheatProtectionType20")
                        .HasColumnType("INTEGER");

                    b.Property<double>("AntiCheatProtectionType20ThresholdMultiplier")
                        .HasColumnType("REAL");

                    b.Property<bool>("AntiCheatProtectionType21")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("AntiCheatProtectionType22")
                        .HasColumnType("INTEGER");

                    b.Property<double>("AntiCheatProtectionType22ThresholdMultiplier")
                        .HasColumnType("REAL");

                    b.Property<bool>("AntiCheatProtectionType23")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("AntiCheatProtectionType24")
                        .HasColumnType("INTEGER");

                    b.Property<double>("AntiCheatProtectionType24ThresholdMultiplier")
                        .HasColumnType("REAL");

                    b.Property<double>("AntiCheatProtectionType2ThresholdMultiplier")
                        .HasColumnType("REAL");

                    b.Property<bool>("AntiCheatProtectionType3")
                        .HasColumnType("INTEGER");

                    b.Property<double>("AntiCheatProtectionType3ThresholdMultiplier")
                        .HasColumnType("REAL");

                    b.Property<bool>("AntiCheatProtectionType4")
                        .HasColumnType("INTEGER");

                    b.Property<double>("AntiCheatProtectionType4ThresholdMultiplier")
                        .HasColumnType("REAL");

                    b.Property<bool>("AntiCheatProtectionType6")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("AntiCheatProtectionType7")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("AntiCheatProtectionType8")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("AntiCheatProtectionType9")
                        .HasColumnType("INTEGER");

                    b.Property<double>("AntiCheatProtectionType9ThresholdMultiplier")
                        .HasColumnType("REAL");

                    b.Property<bool>("AutoCreateUserInWhiteList")
                        .HasColumnType("INTEGER");

                    b.Property<int>("BackupsCount")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("BackupsOnStart")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("BackupsOnVersionChange")
                        .HasColumnType("INTEGER");

                    b.Property<int>("BackupsPeriod")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("BanKickGlobalSound")
                        .HasColumnType("INTEGER");

                    b.Property<int>("BloodSplatLifespanDays")
                        .HasColumnType("INTEGER");

                    b.Property<double>("CarEngineAttractionModifier")
                        .HasColumnType("REAL");

                    b.Property<string>("ChatStreams")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ClientActionLogs")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ClientCommandFilter")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ConfigFileLocation")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("ConstructionPreventsLootRespawn")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DefaultPort")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("DenyLoginOnOverloadedServer")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("DisableRadioAdmin")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("DisableRadioGM")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("DisableRadioInvisible")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("DisableRadioModerator")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("DisableRadioOverseer")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("DisableRadioStaff")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("DisableSafehouseWhenPlayerConnected")
                        .HasColumnType("INTEGER");

                    b.Property<string>("DiscordChannel")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("DiscordChannelID")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("DiscordEnable")
                        .HasColumnType("INTEGER");

                    b.Property<string>("DiscordToken")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("DisplayUserName")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("DoLuaChecksum")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("DropOffWhiteListAfterDeath")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Faction")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FactionDaySurvivedToCreate")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FactionPlayersRequiredForTag")
                        .HasColumnType("INTEGER");

                    b.Property<double>("FastForwardMultiplier")
                        .HasColumnType("REAL");

                    b.Property<bool>("GlobalChat")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("HidePlayersBehindYou")
                        .HasColumnType("INTEGER");

                    b.Property<int>("HoursForLootRespawn")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ItemNumbersLimitPerContainer")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("KickFastPlayers")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("KnockedDownAllowed")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LoginQueueConnectTimeout")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LoginQueueEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Map")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("MapRemotePlayerVisibility")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MaxAccountsPerUser")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MaxItemsForLootRespawn")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MaxPlayers")
                        .HasColumnType("INTEGER");

                    b.Property<double>("MinutesPerPage")
                        .HasColumnType("REAL");

                    b.Property<string>("Mods")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("MouseOverToSeeDisplayName")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("NoFire")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Open")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("PVP")
                        .HasColumnType("INTEGER");

                    b.Property<double>("PVPFirearmDamageModifier")
                        .HasColumnType("REAL");

                    b.Property<double>("PVPMeleeDamageModifier")
                        .HasColumnType("REAL");

                    b.Property<bool>("PVPMeleeWhileHitReaction")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("PauseEmpty")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("PerkLogs")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PingLimit")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("PlayerBumpPlayer")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("PlayerRespawnWithOther")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("PlayerRespawnWithSelf")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("PlayerSafehouse")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Public")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PublicDescription")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PublicName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("RCONPassword")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("RCONPort")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("RemovePlayerCorpsesOnCorpseRemoval")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ResetID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SafeHouseRemovalTime")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("SafehouseAllowFire")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("SafehouseAllowLoot")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("SafehouseAllowNonResidential")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("SafehouseAllowRespawn")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("SafehouseAllowTrepass")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SafehouseDaySurvivedToClaim")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SafetyCooldownTimer")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("SafetySystem")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SafetyToggleTimer")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SaveWorldEveryMinutes")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ServerHome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ServerInstanceID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ServerName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ServerPlayerID")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ServerWelcomeMessage")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("ShowFirstAndLastName")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("ShowSafety")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("SledgehammerOnlyInSafehouse")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("SleepAllowed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("SleepNeeded")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("SneakModeHideFromOtherPlayers")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SpawnItems")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SpawnPoint")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("SpeedLimit")
                        .HasColumnType("REAL");

                    b.Property<bool>("SteamScoreboard")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("SteamVAC")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("TrashDeleteAll")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UDPPort")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("UPnP")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Voice3D")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("VoiceEnable")
                        .HasColumnType("INTEGER");

                    b.Property<double>("VoiceMaxDistance")
                        .HasColumnType("REAL");

                    b.Property<double>("VoiceMinDistance")
                        .HasColumnType("REAL");

                    b.Property<string>("WorkshopItems")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("server_browser_announced_ip")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("ProjectZomboidConfiguration");
                });
#pragma warning restore 612, 618
        }
    }
}