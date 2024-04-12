using Object_Change_Tracker;
using System.ComponentModel.DataAnnotations;

namespace steam_server_command_center.Models
{
    public class CommandCenterChange : Change
    {
        [Key]
        public int ID { get; set; }

        public CommandCenterChange() : base()
        {
            ID = 0;            
        }

        public CommandCenterChange(Change ParentChange)
        {
            ID = 0;
            this.ObjectID = ParentChange.ObjectID;
            this.ObjectName = ParentChange.ObjectName;
            this.PropertyChanged = ParentChange.PropertyChanged;
            this.ChangedBy = ParentChange.ChangedBy;
            this.NewValue = ParentChange.NewValue;
            this.OldValue = ParentChange.OldValue;
            this.TimeStamp = ParentChange.TimeStamp;
        }
    }
}
