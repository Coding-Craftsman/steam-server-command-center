using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text;

namespace steam_server_command_center.Models.ProjectZomboid
{
    public class ProjectZomboidConfiguration
    {
        // EF Database ID
        //[Key]
        //public int ID { get; set; }

        //public int ServerInstanceID { get; set; }

        // The server connection password
        public string AdminPassword { get; set; } = "";

        // The path to the server save files (location of config files and saves)
        public string ServerHome { get; set; } = "/data/Zomboid";

        public string ServerName { get; set; } = "Zomboid-Dedicated-Server";

        public string ConfigFileLocation { get; set; } = "/data/Zomboid/Zomboid/Server/servertest.ini";

        public string GameServerRootFolder = "Zomboid-108600";

        // Players can hurt and kill other players
        public bool PVP { get; set; } = true;

        // Game time stops when there are no players online
        public bool PauseEmpty { get; set; } = true;

        // Toggles global chat on or off.
        public bool GlobalChat { get; set; } = true;

        public string ChatStreams { get; set; } = "s,r,a,w,y,sh,f,all"; //{ "s", "r", "a", "w", "y", "sh", "f", "all" };

        // Clients may join without already having an account in the whitelist. If set to false, administrators must manually create username/password combos.
        public bool Open { get; set; } = true;

        // The first welcome message visible in the chat panel. This will be displayed immediately after player login. you can use RGB colours to chance the colour of the welcome message. You can also use <LINE> to create a separate lines within your text. Use: <RGB:1,0,0> This message will show up red!
        public string ServerWelcomeMessage { get; set; } = "Welcome to Project Zomboid Multiplayer! <LINE> <LINE> To interact with the Chat panel: press Tab, T, or Enter. <LINE> <LINE> The Tab key will change the target stream of the message. <LINE> <LINE> Global Streams: /all<LINE> Local Streams: /say, /yell<LINE> Special Steams: /whisper, /safehouse, /faction. <LINE> <LINE> Press the Up arrow to cycle through your message history.Click the Gear icon to customize chat. <LINE> <LINE> Happy surviving!";

        // Add unknown usernames to the whitelist when players join. Clients will supply their own username/password on joining. (This is for Open=true servers)
        public bool AutoCreateUserInWhiteList { get; set; } = false;

        // Display usernames above player's heads in-game.
        public bool DisplayUserName { get; set; } = true;

        // Display first & last name above player's heads.
        public bool ShowFirstAndLastName { get; set; } = false;

        // Force every new player to spawn at these set x,y,z world coordinates. Find desired coordinates at map.projectzomboid.com. (Ignored when 0,0,0)
        public string SpawnPoint { get; set; } = "0,0,0";

        // Players can enter and leave PVP on an individual basis. A player can only hurt another player when at least one of them is in PVP mode - as shown by the unobscured skull and crossbones on the left of the screen. When SafetySystem=false, players are free to hurt each other at any time if PVP is enabled.
        public bool SafetySystem { get; set; } = true;

        // Display a skull icon over the head of players who have entered PVP mode
        public bool ShowSafety { get; set; } = true;

        // The time it takes for a player to enter and leave PVP mode\nMinimum=0 Maximum=1000 Default=2
        public int SafetyToggleTimer { get; set; } = 2;

        // The delay before a player can enter or leave PVP mode again, having recently done so\nMinimum=0 Maximum=1000 Default=3
        public int SafetyCooldownTimer { get; set; } = 3;

        // Item types new players spawn with.\nSeparate multiple item types with commas.\nExample: Base.Axe,Base.Bag_BigHikingBag
        public string SpawnItems { get; set; } = "";

        // Default starting port for player data. If UDP, this is this one of two ports used.\nMinimum=0 Maximum=65535 Default=16261
        public int DefaultPort { get; set; } = 16261;

        // Minimum=0 Maximum=65535 Default=16262
        public int UDPPort { get; set; } = 16262;

        // Reset ID determines if the server has undergone a soft-reset. If this number does match the client, the client must create a new character. Used in conjunction with PlayerServerID. It is strongly advised that you backup these IDs somewhere\nMinimum=0 Maximum=2147483647 Default=305630290
        public int ResetID { get; set; } = 207984;

        // Enter the mod loading ID here. It can be found in \Steam\steamapps\workshop\modID\mods\modName\info.txt
        public string Mods { get; set; } = "";

        // Enter the foldername of the mod found in \Steam\steamapps\workshop\modID\mods\modName\media\maps\
        public string Map { get; set; } = "Muldraugh, KY";

        // Kick clients whose game files don't match the server's.
        public bool DoLuaChecksum { get; set; } = true;

        public bool DenyLoginOnOverloadedServer { get; set; } = true;

        // Shows the server on the in-game browser. (Note: Steam-enabled servers are always visible in the Steam server browser)
        public bool Public { get; set; } = false;

        // Name of the server displayed in the in-game browser and, if applicable, the Steam browser
        public string PublicName { get; set; } = "My PZ Server";

        // Description displayed in the in-game public server browser. Typing \n will create a new line in your description
        public string PublicDescription { get; set; } = "";

        // Maximum number of players that can be on the server at one time. This excludes admins.
        // WARNING: Server player counts above 32 will potentially result in poor map streaming and desync. Please advance with caution.\nMinimum=1 Maximum=100 Default=32
        public int MaxPlayers { get; set; } = 32;

        // Ping limit, in milliseconds, before a player is kicked from the server. (Set to 100 to disable)\nMinimum=100 Maximum=2147483647 Default=400
        public int PingLimit { get; set; } = 400;

        // After X hours, all containers in the world will respawn loot. To spawn loot a container must have been looted at least once. Loot respawn is not impacted by visibility or subsequent looting.\nMinimum=0 Maximum=2147483647 Default=0
        public int HoursForLootRespawn { get; set; } = 0;

        // Containers with a number of items greater, or equal to, this setting will not respawn\nMinimum=1 Maximum=2147483647 Default=4
        public int MaxItemsForLootRespawn { get; set; } = 4;

        // Items will not respawn in buildings that players have barricaded or built in
        public bool ConstructionPreventsLootRespawn { get; set; } = true;

        // Remove player accounts from the whitelist after death. This prevents players creating a new character after death on Open=false servers
        public bool DropOffWhiteListAfterDeath { get; set; } = false;

        // All forms of fire are disabled - except for campfires
        public bool NoFire { get; set; } = false;

        // If checked, every time a player dies a global message will be displayed in the chat
        public bool AnnounceDeath { get; set; } = false;

        // The number of in-game minutes it takes to read one page of a book\nMinimum=0.00 Maximum=60.00 Default=1.00
        public double MinutesPerPage { get; set; } = 1.0;

        // Loaded parts of the map are saved after this set number of real-world minutes have passed. (The map is usually saved only after clients leave a loaded area)\nMinimum=0 Maximum=2147483647 Default=0
        public int SaveWorldEveryMinutes { get; set; } = 0;

        // Both admins and players can claim safehouses
        public bool PlayerSafehouse { get; set; } = false;

        // Only admins can claim safehouses
        public bool AdminSafehouse { get; set; } = false;

        // Allow non-members to enter a safehouse without being invited
        public bool SafehouseAllowTrepass { get; set; } = true;

        // Allow fire to damage safehouses
        public bool SafehouseAllowFire { get; set; } = true;

        // Allow non-members to take items from safehouses
        public bool SafehouseAllowLoot { get; set; } = true;

        // Players will respawn in a safehouse that they were a member of before they died
        public bool SafehouseAllowRespawn { get; set; } = false;

        // Players must have survived this number of in-game days before they are allowed to claim a safehouse\nMinimum=0 Maximum=2147483647 Default=0
        public int SafehouseDaySurvivedToClaim { get; set; } = 0;

        // Players are automatically removed from a safehouse they have not visited for this many real-world hours\nMinimum=0 Maximum=2147483647 Default=144
        public int SafeHouseRemovalTime { get; set; } = 144;

        // Governs whether players can claim non-residential buildings.
        public bool SafehouseAllowNonResidential { get; set; } = false;

        // Allow players to destroy world objects with sledgehammers
        public bool AllowDestructionBySledgehammer { get; set; } = true;

        // Allow players to destroy world objects only in their safehouse (require AllowDestructionBySledgehammer to true).
        public bool SledgehammerOnlyInSafehouse { get; set; } = false;

        // Kick players that appear to be moving faster than is possible. May be buggy -- use with caution.
        public bool KickFastPlayers { get; set; } = false;

        // ServerPlayerID determines if a character is from another server, or single player. This value may be changed by soft resets. If this number does match the client, the client must create a new character. This is used in conjunction with ResetID. It is strongly advised that you backup these IDs somewhere
        public string ServerPlayerID { get; set; } = "1271294508";

        // The port for the RCON (Remote Console)\nMinimum=0 Maximum=65535 Default=27015
        public int RCONPort { get; set; } = 27015;

        // RCON password (Pick a strong password)
        public string RCONPassword { get; set; } = "";

        // Enables global text chat integration with a Discord channel
        public bool DiscordEnable { get; set; } = false;

        // Discord bot access token
        public string DiscordToken { get; set; } = "";

        // The Discord channel name. (Try the separate channel ID option if having difficulties)
        public string DiscordChannel { get; set; } = "";

        // The Discord channel ID. (Use if having difficulties with Discord channel name option)
        public string DiscordChannelID { get; set; } = "";

        // Clients must know this password to join the server. (Ignored when hosting a server via the Host button)
        public string Password { get; set; } = "";

        // Limits the number of different accounts a single Steam user may create on this server. Ignored when using the Hosts button.\nMinimum=0 Maximum=2147483647 Default=0
        public int MaxAccountsPerUser { get; set; } = 0;

        // Allow co-op/splitscreen players
        public bool AllowCoop { get; set; } = true;

        // Players are allowed to sleep when their survivor becomes tired, but they do not NEED to sleep
        public bool SleepAllowed { get; set; } = false;

        // Players get tired and need to sleep. (Ignored if SleepAllowed=false)
        public bool SleepNeeded { get; set; } = false;

        public bool KnockedDownAllowed { get; set; } = true;

        public bool SneakModeHideFromOtherPlayers { get; set; } = true;

        // List Workshop Mod IDs for the server to download. Each must be separated by a semicolon. Example: WorkshopItems=514427485;513111049
        public string WorkshopItems { get; set; } = "";

        // Show Steam usernames and avatars in the Players list. Can be true (visible to everyone), false (visible to no one), or admin (visible to only admins)
        public bool SteamScoreboard { get; set; } = true;

        // Enable the Steam VAC system
        public bool SteamVAC { get; set; } = true;

        // Attempt to configure a UPnP-enabled internet gateway to automatically setup port forwarding rules. The server will fall back to default ports if this fails
        public bool UPnP { get; set; } = true;

        // VOIP is enabled when checked
        public bool VoiceEnable { get; set; } = true;

        // The minimum tile distance over which VOIP sounds can be heard.\nMinimum=0.00 Maximum=100000.00 Default=10.00
        public double VoiceMinDistance { get; set; } = 10.0;

        // The maximum tile distance over which VOIP sounds can be heard.\nMinimum=0.00 Maximum=100000.00 Default=100.00
        public double VoiceMaxDistance { get; set; } = 100.0;

        // Toggle directional audio for VOIP
        public bool Voice3D { get; set; } = true;

        // Minimum=10.00 Maximum=150.00 Default=70.00
        public double SpeedLimit { get; set; } = 70.0;

        public bool LoginQueueEnabled { get; set; } = false;

        // Minimum=20 Maximum=1200 Default=60
        public int LoginQueueConnectTimeout { get; set; } = 60;

        // Set the IP from which the server is broadcast. This is for network configurations with multiple IP addresses, such as server farms
        public string server_browser_announced_ip { get; set; } = "";

        // Players can respawn in-game at the coordinates where they died
        public bool PlayerRespawnWithSelf { get; set; } = false;

        // Players can respawn in-game at a split screen / Remote Play player's location
        public bool PlayerRespawnWithOther { get; set; } = false;

        // Governs how fast time passes while players sleep. Value multiplies the speed of the time that passes during sleeping.\nMinimum=1.00 Maximum=100.00 Default=40.00
        public double FastForwardMultiplier { get; set; } = 40.0;

        // Safehouse acts like a normal house if a member of the safehouse is connected (so secure when players are offline)
        public bool DisableSafehouseWhenPlayerConnected { get; set; } = false;

        // Players can create factions when true
        public bool Faction { get; set; } = true;

        // Players must survive this number of in-game days before being allowed to create a faction\nMinimum=0 Maximum=2147483647 Default=0
        public int FactionDaySurvivedToCreate { get; set; } = 0;

        // Number of players required as faction members before the faction owner can create a group tag\nMinimum=1 Maximum=2147483647 Default=1
        public int FactionPlayersRequiredForTag { get; set; } = 1;

        // Disables radio transmissions from players with an access level
        public bool DisableRadioStaff { get; set; } = false;

        // Disables radio transmissions from players with 'admin' access level
        public bool DisableRadioAdmin { get; set; } = true;

        // Disables radio transmissions from players with 'gm' access level
        public bool DisableRadioGM { get; set; } = true;

        // Disables radio transmissions from players with 'overseer' access level
        public bool DisableRadioOverseer { get; set; } = false;

        // Disables radio transmissions from players with 'moderator' access level
        public bool DisableRadioModerator { get; set; } = false;

        // Disables radio transmissions from invisible players
        public bool DisableRadioInvisible { get; set; } = true;

        // Semicolon-separated list of commands that will not be written to the cmd.txt server log. For example: \n-vehicle. Inputting * means do NOT write any vehicle command. Inputting: \n+vehicle.installPart means DO write that command
        public string ClientCommandFilter { get; set; } = "-vehicle.*;+vehicle.damageWindow;+vehicle.fixPart;+vehicle.installPart;+vehicle.uninstallPart";

        // Semicolon-separated list of actions that will be written to the ClientActionLogs.txt server log.
        public string ClientActionLogs { get; set; } = "ISEnterVehicle; ISExitVehicle;ISTakeEngineParts;";

        // Track changes in player perk levels in PerkLog.txt server log
        public bool PerkLogs { get; set; } = true;

        // Maximum number of items that can be placed in a container.  Zero means there is no limit. (PLEASE NOTE: This includes individual small items such as nails. A limit of 50 will mean only 50 nails can be stored.)\nMinimum=0 Maximum=9000 Default=0
        public int ItemNumbersLimitPerContainer { get; set; } = 0;

        // Number of days before old blood splats are removed.
        // Removal happens when map chunks are loaded.
        // Zero means they will never disappear\nMinimum=0 Maximum=365 Default=0
        public int BloodSplatLifespanDays { get; set; } = 0;

        // Allow use of non-ASCII (cyrillic etc) characters in usernames
        public bool AllowNonAsciiUsername { get; set; } = false;

        public bool BanKickGlobalSound { get; set; } = true;

        // If enabled, when HoursForCorpseRemoval triggers, it will also remove player’s corpses from the ground.
        public bool RemovePlayerCorpsesOnCorpseRemoval { get; set; } = false;

        // If true, player can use the "delete all" button on bins.
        public bool TrashDeleteAll { get; set; } = false;

        // If true, player can hit again when struck by another player.
        public bool PVPMeleeWhileHitReaction { get; set; } = false;

        // If true, players will have to mouse over someone to see their display name.
        public bool MouseOverToSeeDisplayName { get; set; } = true;

        // If true, automatically hide the player you can't see (like zombies).
        public bool HidePlayersBehindYou { get; set; } = true;

        // Damage multiplier for PVP melee attacks.\nMinimum=0.00 Maximum=500.00 Default=30.00
        public double PVPMeleeDamageModifier { get; set; } = 30.0;

        // Damage multiplier for PVP ranged attacks.\nMinimum=0.00 Maximum=500.00 Default=50.00
        public double PVPFirearmDamageModifier { get; set; } = 50.0;

        // Modify the range of zombie attraction to cars. (Lower values can help with lag.)\nMinimum=0.00 Maximum=10.00 Default=0.50
        public double CarEngineAttractionModifier { get; set; } = 0.5;

        // Governs whether players bump (and knock over) other players when running through them.
        public bool PlayerBumpPlayer { get; set; } = false;

        // Controls display of remote players on the in-game map.\n1=Hidden 2=Friends 3=Everyone\nMinimum=1 Maximum=3 Default=1
        public int MapRemotePlayerVisibility { get; set; } = 1;

        // Minimum=1 Maximum=300 Default=5
        public int BackupsCount { get; set; } = 5;

        public bool BackupsOnStart { get; set; } = true;

        public bool BackupsOnVersionChange { get; set; } = true;

        // Minimum=0 Maximum=1500 Default=0
        public int BackupsPeriod { get; set; } = 0;

        // Disables anti-cheat protection for type 1.
        public bool AntiCheatProtectionType1 { get; set; } = true;

        // Disables anti-cheat protection for type 2.
        public bool AntiCheatProtectionType2 { get; set; } = true;

        // Disables anti-cheat protection for type 3.
        public bool AntiCheatProtectionType3 { get; set; } = true;

        // Disables anti-cheat protection for type 4.
        public bool AntiCheatProtectionType4 { get; set; } = true;

        // Disables anti-cheat protection for type 5.
        public bool AntiCheatProtectionType5 = true;

        // Disables anti-cheat protection for type 6.
        public bool AntiCheatProtectionType6 { get; set; } = true;

        // Disables anti-cheat protection for type 7.
        public bool AntiCheatProtectionType7 { get; set; } = true;

        // Disables anti-cheat protection for type 8.
        public bool AntiCheatProtectionType8 { get; set; } = true;

        // Disables anti-cheat protection for type 9.
        public bool AntiCheatProtectionType9 { get; set; } = true;

        // Disables anti-cheat protection for type 10.
        public bool AntiCheatProtectionType10 { get; set; } = true;

        // Disables anti-cheat protection for type 11.
        public bool AntiCheatProtectionType11 { get; set; } = true;

        // Disables anti-cheat protection for type 12.
        public bool AntiCheatProtectionType12 { get; set; } = true;

        // Disables anti-cheat protection for type 13.
        public bool AntiCheatProtectionType13 { get; set; } = true;

        // Disables anti-cheat protection for type 14.
        public bool AntiCheatProtectionType14 { get; set; } = true;

        // Disables anti-cheat protection for type 15.
        public bool AntiCheatProtectionType15 { get; set; } = true;

        // Disables anti-cheat protection for type 16.
        public bool AntiCheatProtectionType16 { get; set; } = true;

        // Disables anti-cheat protection for type 17.
        public bool AntiCheatProtectionType17 { get; set; } = true;

        // Disables anti-cheat protection for type 18.
        public bool AntiCheatProtectionType18 { get; set; } = true;

        // Disables anti-cheat protection for type 19.
        public bool AntiCheatProtectionType19 { get; set; } = true;

        // Disables anti-cheat protection for type 20.
        public bool AntiCheatProtectionType20 { get; set; } = true;
            
        public bool AntiCheatProtectionType21 { get; set; } = true;

        public bool AntiCheatProtectionType22 { get; set; } = true;

        public bool AntiCheatProtectionType23 { get; set; } = true;

        public bool AntiCheatProtectionType24 { get; set; } = true;

        // Threshold value multiplier for anti-cheat protection: type 2.\nMinimum=1.00 Maximum=10.00 Default=3.00
        public double AntiCheatProtectionType2ThresholdMultiplier { get; set; } = 3.0;

        // Threshold value multiplier for anti-cheat protection: type 3.\nMinimum=1.00 Maximum=10.00 Default=1.00
        public double AntiCheatProtectionType3ThresholdMultiplier { get; set; } = 1.0;

        // Threshold value multiplier for anti-cheat protection: type 4.\nMinimum=1.00 Maximum=10.00 Default=1.00
        public double AntiCheatProtectionType4ThresholdMultiplier { get; set; } = 1.0;

        // Threshold value multiplier for anti-cheat protection: type 9.\nMinimum=1.00 Maximum=10.00 Default=1.00
        public double AntiCheatProtectionType9ThresholdMultiplier { get; set; } = 1.0;

        // Threshold value multiplier for anti-cheat protection: type 15.\nMinimum=1.00 Maximum=10.00 Default=1.00
        public double AntiCheatProtectionType15ThresholdMultiplier { get; set; } = 1.0;

        // Threshold value multiplier for anti-cheat protection: type 20.\nMinimum=1.00 Maximum=10.00 Default=1.00
        public double AntiCheatProtectionType20ThresholdMultiplier { get; set; } = 1.0;

        // Minimum=1.00 Maximum=10.00 Default=1.00
        public double AntiCheatProtectionType22ThresholdMultiplier { get; set; } = 1.0;

        // Minimum=1.00 Maximum=10.00 Default=6.00
        public double AntiCheatProtectionType24ThresholdMultiplier { get; set; } = 6.0;

        public string BuildConfigFile()
        {
            StringBuilder sb = new StringBuilder();

            PropertyInfo[] properties = this.GetType().GetProperties();
            foreach(var property in properties)
            {
                sb.Append(property.Name);
                sb.Append("=");
                sb.Append(property.GetValue(this));
                sb.Append("\n");
            }

            return sb.ToString();
        }
    }
}
