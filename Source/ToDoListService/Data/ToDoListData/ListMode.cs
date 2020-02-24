using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListData
{
    [DataContract]
    [Flags]
    public enum ListMode
    {
        [EnumMember]
        PeriodicTasks,

        [EnumMember]
        DailyTasks,

        [EnumMember]
        WeeklyGoals,

        [EnumMember]
        LongTermGoals
    }
}
