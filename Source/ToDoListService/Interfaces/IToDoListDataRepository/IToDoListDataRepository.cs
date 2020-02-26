using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListService.Data.ToDoListData;

namespace ToDoListService.Interfaces.IToDoListDataRepository
{
    public interface IToDoListDataRepository
    {
        bool StartTaskEditing(int userID, int taskID);

        bool EndTaskEditing(int userID, int taskID);

        bool CreateToDoListTask(int userID, ToDoListDataModel data);

        bool DeleteToDoListTask(int userID, ToDoListDataModel data);

        bool UpdateToDoListTask(int userID, ToDoListDataModel data);

        ToDoListDataModel ReadToDoList(int userID, int taskID);

        List<ToDoListDataModel> ReadAllToDoList(int userID);

        List<ToDoListDataModel> ReadToDoLists(int userID, ToDoListDataModel query);

        bool CreateReminder(int taskID, Reminder reminderData);

        bool UpdateReminder(int taskID, Reminder reminderData);

        bool DeleteReminder(int taskID, int reminderID);

        List<Reminder> ReadAllReminders(int userID, int taskID);

        Reminder ReadReminder(int taskID, int reminderID);

    }
}
