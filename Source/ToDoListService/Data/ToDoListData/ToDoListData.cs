using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ToDoListData;

namespace ToDoListService.Data.ToDoListData
{
    [DataContract]
    public struct ToDoListDataModel
    {
        [DataMember]
        public ListMode ListMode { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Notes { get; set; }

        [DataMember]
        public List<int> ReminderIDs { get; set; }

        [DataMember]
        public bool UnderModification { get; set; }

        [DataMember]
        public DateTime DateModified { get; set; }

        [DataMember]
        public DateTime StartDate { get; set; }

        [DataMember]
        public DateTime EndDate { get; set; }

        [DataMember]
        public int TaskID { get; set; }
    }
}
