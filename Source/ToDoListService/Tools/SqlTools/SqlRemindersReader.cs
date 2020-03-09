using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListService.Data.ToDoListData;

namespace SqlTools
{
    public static class SqlRemindersReader
    {
        public static List<Reminder> Read(string connectionString, string query)
        {
            List<Reminder> reminders = new List<Reminder>();
            try
            {
                using (SQLiteConnection dbConnection = new SQLiteConnection(connectionString))
                {
                    dbConnection.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(dbConnection))
                    {
                        cmd.CommandText = query;
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                reminders.Add(new Reminder
                                {
                                    ReminderID = reader.GetInt32(0),
                                    ReminderType = (ReminderType)reader.GetInt32(2),
                                    Repeat = reader.GetBoolean(3),
                                    ReminderTime = reader.GetDateTime(4),
                                    RepeatDays = reader.GetString(5)
                                });
                            }
                        }
                    }
                }
                return reminders;
            }
            catch (SQLiteException e)
            {
                //throw fault exception
                return new List<Reminder>();
            }
        }
    }
}
