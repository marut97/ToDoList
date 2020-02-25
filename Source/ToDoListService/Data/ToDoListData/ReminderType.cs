using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListService.Data.ToDoListData
{
    [DataContract]
    [Flags]
    public enum ReminderType
    {
        [EnumMember]
        Notification,

        [EnumMember]
        Reminder
    }
}
