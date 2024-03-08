namespace steam_server_command_center.Models
{
    /// <summary>
    /// A configuration item is a simple Key/value pair that is used to store application
    ///  specific configuration items
    /// </summary>
    public class ConfigurationItem
    {
        public int ID { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }

        public ConfigurationItem()
        {
            ID = 0;
            Key = string.Empty;
            Value = string.Empty;
        }
    }
}
