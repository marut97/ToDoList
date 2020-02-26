using System;
using System.Collections.Generic;
using ToDoListService.Interfaces.IToDoListDataRepository;
using ToDoListService.Data.ToDoListData;

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

        public bool CreateReminder(int taskID, Reminder reminderData)
        {
            
        }

        public bool CreateToDoListTask(int userID, ToDoListDataModel data)
        {
            throw new NotImplementedException();
        }

        public bool DeleteReminder(int userID, int reminderID)
        {
            throw new NotImplementedException();
        }

        public bool DeleteToDoListTask(int userID, ToDoListDataModel data)
        {
            throw new NotImplementedException();
        }

        public bool EndTaskEditing(int userID, int taskID)
        {
            throw new NotImplementedException();
        }

        public List<Reminder> ReadAllReminders(int userID, int taskID)
        {
            throw new NotImplementedException();
        }

        public List<ToDoListDataModel> ReadAllToDoList(int userID)
        {
            throw new NotImplementedException();
        }

        public Reminder ReadReminder(int userID, int reminderID)
        {
            throw new NotImplementedException();
        }

        public ToDoListDataModel ReadToDoList(int userID, int taskID)
        {
            throw new NotImplementedException();
        }

        public List<ToDoListDataModel> ReadToDoList(int userID, ToDoListDataModel query)
        {
            throw new NotImplementedException();
        }

        public bool StartTaskEditing(int userID, int taskID)
        {
            throw new NotImplementedException();
        }

        public bool UpdateReminder(int userID, Reminder reminderData)
        {
            throw new NotImplementedException();
        }

        public bool UpdateToDoListTask(int userID, ToDoListService.Data.ToDoListData.ToDoListDataModel data)
        {
            throw new NotImplementedException();
        }

        private readonly string m_connectionString;
    }
}
