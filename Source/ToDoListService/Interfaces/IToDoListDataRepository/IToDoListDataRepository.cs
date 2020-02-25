using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListService.Interfaces.IToDoListDataRepository
{
    public interface IToDoListDataRepository
    {
        bool CreateToDoEntry(string username, Data.ToDoListData.ToDoListData data);

        bool DeleteToDoEntry(string username, Data.ToDoListData.ToDoListData data);

        bool UpdateToDoEntry(string username, Data.ToDoListData.ToDoListData data);

        bool UpdateReminder()
    }
}
