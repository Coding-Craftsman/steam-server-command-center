using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace steam_server_command_center.Models
{
    [NotMapped]
    public class ValheimConfiguration : EnabledServer
    {
        // gameserver.settings.valheim.servername.<instanceID>
        [DisplayName("Server Name")]
        public string ServerName { get; set; } = string.Empty;

        // gameserver.settings.valheim.worldname.<instanceID>
        [DisplayName("World Name")]
        public string WorldName { get; set; } = string.Empty;

        // gameserver.settings.valheim.password.<InstanceID>
        [DisplayName("Server Password")]
        public string Password {  get; set; } = string.Empty;

        private CommandCenterContext _context;

        public CommandCenterContext? CommandCenterContext
        {
            get
            {
                return _context;
            }
            set
            {
                _context = value;
            }
        }        

        public string[] ServerSettingKeys
        {
            get
            {
                return
                [
                    "gameserver.settings.valheim.servername.{0}",
                    "gameserver.settings.valheim.worldname.{0}",
                    "gameserver.settings.valheim.password.{0}",
                    "gameserver.settings.valheim.rootfolderpath.{0}",
                    "gameserver.settings.valheim.instancename.{0}",
                    "gameserver.settings.valheim.isactive.{0}",
                    "gameserver.settings.valheim.containerid.{0}"
                ];
            }
        }
        // gameserver.settings.valheim.rootfolderpath.<InstanceID>
        public string GameRootFolderName { get; set; } = "Valheim-896660";

        public ValheimConfiguration()
        {

        }

        

        public ValheimConfiguration(CommandCenterContext context, int InstanceID = 0)
        {
            //InstanceName = Instance;
            ID = InstanceID;
            _context = context;
            // set values from datacontext if they exist.

            ServerName = getConfigSetting(string.Format("gameserver.settings.valheim.servername.{0}", ID)).Value;
            WorldName = getConfigSetting(string.Format("gameserver.settings.valheim.worldname.{0}", ID)).Value;
            Password = getConfigSetting(string.Format("gameserver.settings.valheim.password.{0}", ID)).Value;
            GameRootFolderName = getConfigSetting(string.Format("gameserver.settings.valheim.rootfolderpath.{0}", ID)).Value;
            InstanceName = getConfigSetting(string.Format("gameserver.settings.valheim.instancename.{0}", ID)).Value;
            IsActive = Convert.ToBoolean(getConfigSetting(string.Format("gameserver.settings.valheim.isactive.{0}", ID)).Value);
            ContainerID = getConfigSetting(string.Format("gameserver.settings.valheim.containerid.{0}", ID)).Value;
        }

        /// <summary>
        /// Saves all the fields to the database
        /// </summary>
        public async Task SaveSettings()
        {
            // ServerName 
            // --------------------------------------------------------------------------------------------------
            var item = _context.Configuration.Where(
                c => c.Key == string.Format("gameserver.settings.valheim.servername.{0}", ID)).FirstOrDefault();

            if (item != null && item.Value != null)
            {
                item.Value = ServerName;
                _context.Attach(item).State = EntityState.Modified;
            }
            else
            {
                ConfigurationItem config = new ConfigurationItem()
                {
                    Key = string.Format("gameserver.settings.valheim.servername.{0}", ID),
                    Value = ServerName
                };
                _context.Configuration.Add(config);
            }

            // World Name
            // --------------------------------------------------------------------------------------------------
            item = _context.Configuration.Where(
                c => c.Key == string.Format("gameserver.settings.valheim.worldname.{0}", ID)).FirstOrDefault();

            if (item != null && item.Value != null)
            {
                item.Value = WorldName;
                _context.Attach(item).State = EntityState.Modified;
            }
            else
            {
                ConfigurationItem config = new ConfigurationItem()
                {
                    Key = string.Format("gameserver.settings.valheim.worldname.{0}", ID),
                    Value = WorldName
                };
                _context.Configuration.Add(config);
            }

            // Password
            // --------------------------------------------------------------------------------------------------
            item = _context.Configuration.Where(
                c => c.Key == string.Format("gameserver.settings.valheim.password.{0}", ID)).FirstOrDefault();

            if (item != null && item.Value != null)
            {
                item.Value = Password;
                _context.Attach(item).State = EntityState.Modified;
            }
            else
            {
                ConfigurationItem config = new ConfigurationItem()
                {
                    Key = string.Format("gameserver.settings.valheim.password.{0}", ID),
                    Value = Password
                };
                _context.Configuration.Add(config);
            }

            // Server Root Path
            // --------------------------------------------------------------------------------------------------
            item = _context.Configuration.Where(
                c => c.Key == string.Format("gameserver.settings.valheim.rootfolderpath.{0}", ID)).FirstOrDefault();

            if (item != null && item.Value != null)
            {
                item.Value = GameRootFolderName;
                _context.Attach(item).State = EntityState.Modified;
            }
            else
            {
                ConfigurationItem config = new ConfigurationItem()
                {
                    Key = string.Format("gameserver.settings.valheim.rootfolderpath.{0}", ID),
                    Value = GameRootFolderName
                };
                _context.Configuration.Add(config);
            }

            // Instance name
            // --------------------------------------------------------------------------------------------------
            item = _context.Configuration.Where(
                c => c.Key == string.Format("gameserver.settings.valheim.instancename.{0}", ID)).FirstOrDefault();

            if (item != null && item.Value != null)
            {
                item.Value = InstanceName;
                _context.Attach(item).State = EntityState.Modified;
            }
            else
            {
                ConfigurationItem config = new ConfigurationItem()
                {
                    Key = string.Format("gameserver.settings.valheim.instancename.{0}", ID),
                    Value = InstanceName
                };
                _context.Configuration.Add(config);
            }

            // Is active
            // --------------------------------------------------------------------------------------------------
            item = _context.Configuration.Where(
                c => c.Key == string.Format("gameserver.settings.valheim.isactive.{0}", ID)).FirstOrDefault();

            if (item != null && item.Value != null)
            {
                item.Value = IsActive.ToString();
                _context.Attach(item).State = EntityState.Modified;
            }
            else
            {
                ConfigurationItem config = new ConfigurationItem()
                {
                    Key = string.Format("gameserver.settings.valheim.isactive.{0}", ID),
                    Value = IsActive.ToString()
                };
                _context.Configuration.Add(config);
            }

            // container ID
            // --------------------------------------------------------------------------------------------------
            item = _context.Configuration.Where(
                c => c.Key == string.Format("gameserver.settings.valheim.containerid.{0}", ID)).FirstOrDefault();

            if (item != null && item.Value != null)
            {
                item.Value = ContainerID ?? "";
                _context.Attach(item).State = EntityState.Modified;
            }
            else
            {
                ConfigurationItem config = new ConfigurationItem()
                {
                    Key = string.Format("gameserver.settings.valheim.containerid.{0}", ID),
                    Value = ContainerID ?? ""
                };
                _context.Configuration.Add(config);
            }

            await _context.SaveChangesAsync();
        }

        private ConfigurationItem getConfigSetting(string key)
        {
            ConfigurationItem? item = _context.Configuration.Where(c => c.Key == key).FirstOrDefault();

            if (item == null)
            {
                return new ConfigurationItem()
                {
                    Key = key
                };
            }
            else
            {
                return item;
            }
        }
    }
}
