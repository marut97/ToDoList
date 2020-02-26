using System;
using System.Collections.Generic;
using ToDoListService.Interfaces.IToDoListDataRepository;
using ToDoListService.Data.ToDoListData;
using System.Data.SQLite;

namespace ToDoListService.Lib.ToDoListRepository
{
    public class ToDoListRepository : IToDoListDataRepository
    {
        public ToDoListRepository(bool test = false)
        {
            if (test)
                m_connectionString = "Data Source=C:\\ToDoListDatabase\\Test\\ToDoListDatabase.sqlite;Version=3;";
            else
                m_connectionString = "Data Source=C:\\ToDoListDatabase\\ToDoListDatabase.sqlite;Version=3;";
        }

        public bool StartTaskEditing(int userID, int taskID)
        {
            throw new NotImplementedException();
        }

        public bool EndTaskEditing(int userID, int taskID)
        {
            throw new NotImplementedException();
        }

        public bool CreateToDoListTask(int userID, ToDoListDataModel data)
        {
            throw new NotImplementedException();
        }

        public bool DeleteToDoListTask(int userID, ToDoListDataModel data)
        {
            throw new NotImplementedException();
        }

        public bool UpdateToDoListTask(int userID, ToDoListDataModel data)
        {
            throw new NotImplementedException();
        }

        public ToDoListDataModel ReadToDoList(int userID, int taskID)
        {
            throw new NotImplementedException();
        }

        public List<ToDoListDataModel> ReadAllToDoList(int userID)
        {
            throw new NotImplementedException();
        }

        public List<ToDoListDataModel> ReadToDoLists(int userID, ToDoListDataModel query)
        {
            throw new NotImplementedException();
        }

        public bool CreateReminder(int taskID, Reminder reminderData)
        {
            throw new NotImplementedException();
        }

        public bool UpdateReminder(int taskID, Reminder reminderData)
        {
            throw new NotImplementedException();
        }

        public bool DeleteReminder(int taskID, int reminderID)
        {
            throw new NotImplementedException();
        }

        public List<Reminder> ReadAllReminders(int userID, int taskID)
        {
            throw new NotImplementedException();
        }

        public Reminder ReadReminder(int taskID, int reminderID)
        {
            throw new NotImplementedException();
        }

        private readonly string m_connectionString;

    }
}
