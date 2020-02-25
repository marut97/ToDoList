﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ToDoListData;

namespace ToDoListService.Data.ToDoListData
{
    [DataContract]
    public struct ToDoListData
    {
        [DataMember]
        public ListMode ListMode { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Notes { get; set; }

        [DataMember]
        public List<Reminder> Reminders { get; set; }

        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public bool UnderModification { get; set; }

        [DataMember]
        public DateTime DateModified { get; set; }

        [DataMember]
        public DateTime StartDate { get; set; }

        [DataMember]
        public DateTime EndDate { get; set; }
    }
}
