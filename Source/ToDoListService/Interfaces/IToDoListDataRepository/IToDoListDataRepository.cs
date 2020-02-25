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
        bool CreateToDoTask(int userID, ToDoListDataModel data);

        bool DeleteToDoTask(int userID, ToDoListDataModel data);

        bool UpdateToDoTask(int userID, ToDoListDataModel data);

        bool StartTaskEditing(int userID, int taskID);

        bool EndTaskEditing(int userID, int taskID);

        bool CreateReminder(int userID, Reminder reminderData);

        bool UpdateReminder(int userID, Reminder reminderData);

        bool DeleteReminder(int userID, int reminderID);

        List<Reminder> ReadAllReminders(int userID, int taskID);

        Reminder ReadReminder(int userID, int reminderID);

        List<Reminder> ReadReminders(int userID, int taskID, ReminderType type);

        ToDoListDataModel ReadToDoList(int userID, int taskID);

        List<ToDoListDataModel> ReadAllToDoList(int userID);

        List<ToDoListDataModel> ReadToDoList(int userID, ToDoListDataModel query);
    }
}
