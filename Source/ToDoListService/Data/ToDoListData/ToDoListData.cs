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
        public string Reminder { get; set; }

        [DataMember]
        public string Username { get; set; }
    }
}
