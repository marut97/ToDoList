using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListService.Data.ToDoListData
{
    [DataContract]
    public struct Reminder
    {
        [DataMember]
        public ReminderType ReminderType { get; set; }

        [DataMember]
        public bool Repeat { get; set; }

        [DataMember]
        public DateTime ReminderTime { get; set; }

        [DataMember]
        public string RepeatDays { get; set; }

        [DataMember]
        public int ReminderID { get; set; }
    }
}
