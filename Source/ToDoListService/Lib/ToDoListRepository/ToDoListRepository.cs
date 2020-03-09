using System;
using System.Collections.Generic;
using ToDoListService.Interfaces.IToDoListDataRepository;
using ToDoListService.Data.ToDoListData;
using System.Data.SQLite;
using System.Linq;

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
            try
            {
                int rowsAffected = 0;
                using (SQLiteConnection dbConnection = new SQLiteConnection(m_connectionString))
                {
                    dbConnection.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(dbConnection))
                    {
                        cmd.CommandText = "UPDATE ToDoListDataTable SET UnderModification = 1 " +
                                          "WHERE UserID = '" + userID + "' AND TaskID = '" + taskID + "';";
                        rowsAffected = cmd.ExecuteNonQuery();
                    }
                }
                return (rowsAffected == 1);
            }
            catch (SQLiteException e)
            {
                //throw fault exception
                return false;
            }
        }

        public bool EndTaskEditing(int userID, int taskID)
        {
            try
            {
                int rowsAffected = 0;
                using (SQLiteConnection dbConnection = new SQLiteConnection(m_connectionString))
                {
                    dbConnection.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(dbConnection))
                    {
                        cmd.CommandText = "UPDATE ToDoListDataTable SET UnderModification = 0 AND DateModified = datetime('now') " +
                                          "WHERE UserID = '" + userID + "' AND TaskID = '" + taskID + "';";
                        rowsAffected = cmd.ExecuteNonQuery();
                    }
                }
                return (rowsAffected == 1);
            }
            catch (SQLiteException e)
            {
                //throw fault exception
                return false;
            }
        }

        public bool CreateToDoListTask(int userID, ToDoListDataModel data)
        {
            try
            {
                int rowsAffected = 0;
                using (SQLiteConnection dbConnection = new SQLiteConnection(m_connectionString))
                {
                    dbConnection.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(dbConnection))
                    {
                        cmd.CommandText = "INSERT INTO ToDoListDataTable(Mode, Title, Notes, UserID, DateModified, StartTime, EndTime) " +
                                          "VALUES("+data.ListMode+",'"+data.Title+"','"+data.Notes+"',"+userID+",'"+data.StartDate+"','"+data.EndDate+"');";
                        rowsAffected = cmd.ExecuteNonQuery();
                    }
                }
                return (rowsAffected == 1);
            }
            catch (SQLiteException e)
            {
                //throw fault exception
                return false;
            }
        }

        public bool DeleteToDoListTask(int userID, int taskID)
        {
            try
            {
                int rowsAffected = 0;
                using (SQLiteConnection dbConnection = new SQLiteConnection(m_connectionString))
                {
                    dbConnection.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(dbConnection))
                    {
                        cmd.CommandText = "DELETE FROM ToDoListDataTable WHERE UserID = '" + userID + "' AND TaskID = '" + taskID + "';";
                        rowsAffected = cmd.ExecuteNonQuery();
                    }
                }
                return (rowsAffected == 1);
            }
            catch (SQLiteException e)
            {
                //throw fault exception
                return false;
            }
        }

        public bool UpdateToDoListTask(int userID, ToDoListDataModel data)
        {
            try
            {
                int rowsAffected = 0;
                using (SQLiteConnection dbConnection = new SQLiteConnection(m_connectionString))
                {
                    dbConnection.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(dbConnection))
                    {
                        cmd.CommandText = "UPDATE ToDoListDataTable SET Mode = "+data.ListMode+" AND Title = '"+data.Title+"' AND Notes = '"+data.Notes+"' AND StartTime = '"+data.StartDate+"' AND EndTime = '"+data.EndDate+"'" +
                                          "WHERE UserID = '" + userID + "' AND TaskID = '" + data.TaskID + "';";
                        rowsAffected = cmd.ExecuteNonQuery();
                    }
                }
                return (rowsAffected == 1);
            }
            catch (SQLiteException e)
            {
                //throw fault exception
                return false;
            }
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
            try
            {
                int rowsAffected = 0;
                using (SQLiteConnection dbConnection = new SQLiteConnection(m_connectionString))
                {
                    dbConnection.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(dbConnection))
                    {
                        cmd.CommandText = "INSERT INTO TaskReminderTable(TaskID, ReminderType, Repeat, ReminderTime, RepeatDays) " +
                                          "VALUES(" + taskID + "," + reminderData.ReminderType + "," + reminderData.Repeat + "," + reminderData.ReminderTime + ",'" + reminderData.RepeatDays + "');";
                        rowsAffected = cmd.ExecuteNonQuery();
                    }
                }
                return (rowsAffected == 1);
            }
            catch (SQLiteException e)
            {
                //throw fault exception
                return false;
            }
        }

        public bool UpdateReminder(int taskID, Reminder reminderData)
        {
            try
            {
                int rowsAffected = 0;
                using (SQLiteConnection dbConnection = new SQLiteConnection(m_connectionString))
                {
                    dbConnection.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(dbConnection))
                    {
                        cmd.CommandText = "INSERT INTO TaskReminderTable(TaskID, ReminderType, Repeat, ReminderTime, RepeatDays) " +
                                          "VALUES(" + taskID + "," + reminderData.ReminderType + "," + reminderData.Repeat + "," + reminderData.ReminderTime + ",'" + reminderData.RepeatDays + "');";
                        rowsAffected = cmd.ExecuteNonQuery();
                    }
                }
                return (rowsAffected == 1);
            }
            catch (SQLiteException e)
            {
                //throw fault exception
                return false;
            }
        }

        public bool DeleteReminder(int taskID, int reminderID)
        {
            try
            {
                int rowsAffected = 0;
                using (SQLiteConnection dbConnection = new SQLiteConnection(m_connectionString))
                {
                    dbConnection.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(dbConnection))
                    {
                        cmd.CommandText = "DELETE FROM TaskReminderTable WHERE TaskID = '" + taskID + "' AND ReminderID = '" + reminderID + "';";
                        rowsAffected = cmd.ExecuteNonQuery();
                    }
                }
                return (rowsAffected == 1);
            }
            catch (SQLiteException e)
            {
                //throw fault exception
                return false;
            }
        }

        public List<Reminder> ReadAllReminders(int taskID)
        {
            var query = "SELECT * FROM TaskReminderTable WHERE TaskID = '" + taskID + "'";
            var reminders = SqlTools.SqlRemindersReader.Read(m_connectionString, query);

            return reminders;
        }

        public Reminder ReadReminder(int taskID, int reminderID)
        {
            var query = "SELECT * FROM TaskReminderTable WHERE TaskID = '" + taskID + "' AND ReminderID = '" + reminderID + "' LIMIT 1";
            var reminders =  SqlTools.SqlRemindersReader.Read(m_connectionString, query);

            if (reminders.Any())
                return reminders.First();

            return new Reminder();
        }

        private readonly string m_connectionString;

    }
}
