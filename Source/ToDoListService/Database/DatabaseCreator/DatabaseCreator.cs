using System;
using System.Data.Entity;
using System.Data.SQLite;
using System.IO;
using System.Runtime.CompilerServices;

namespace ToDoListService.DatabaseCreator
{
    class DatabaseCreator
    {
        static void Main(string[] args)
        {
            string databasePath = "C:\\ToDoListDatabase\\";
            DatabaseCreator databaseCreator = new DatabaseCreator();
            databaseCreator.SetupDatabase(databasePath);
        }

        private void SetupDatabase(string databasePath)
        {
            string testDatabasePath = databasePath + "Test\\";
            InitializeDatabase(databasePath, testDatabasePath);
            InitializeAuthenticationDatabase(databasePath);
            InitializeAuthenticationDatabase(testDatabasePath);
            InitializeToDoListDatabase(databasePath);
            InitializeToDoListDatabase(testDatabasePath);
            InitializeReminderDatabase(databasePath);
            InitializeReminderDatabase(testDatabasePath);
        }

        private void InitializeReminderDatabase(string path)
        {
            SQLiteConnection dbConnection = new SQLiteConnection("Data Source=" + path + "ToDoListDatabase.sqlite;Version=3;");
            dbConnection.Open();

            string sql = "CREATE TABLE TaskReminderTable (" +
                          "ReminderID INTEGER PRIMARY KEY AUTOINCREMENT,"   +
                          "TaskID INTEGER NOT NULL,"                        +
                          "ReminderType INTEGER NOT NULL,"                  +
                          "Repeat INTEGER NOT NULL,"                        +
                          "ReminderTime DATETIME NOT NULL,"                 +
                          "RepeatDays VARCHAR(7) NOT NULL,"                 +
                          "FOREIGN KEY(TaskID) REFERENCES ToDoListDataTable(TaskID))";

            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();

            dbConnection.Close();
        }

        private void InitializeToDoListDatabase(string path)
        {
            SQLiteConnection dbConnection = new SQLiteConnection("Data Source=" + path + "ToDoListDatabase.sqlite;Version=3;");
            dbConnection.Open();

            string sql = "CREATE TABLE ToDoListDataTable ("             +
                         "TaskID INTEGER PRIMARY KEY AUTOINCREMENT,"    +
                         "Mode INTEGER NOT NULL, "                      +
                         "Title VARCHAR(50) NOT NULL, "                 +
                         "Notes VARCHAR(500), "                         +
                         "UserID INTEGER NOT NULL,"                     +
                         "UnderModification INTEGER NOT NULL DEFAULT 0,"+
                         "DateModified DATETIME NOT NULL,"              +
                         "StartTime DATETIME NOT NULL,"                 +
                         "EndTime DATETIME NOT NULL,"                   +
                         "FOREIGN KEY(UserID) REFERENCES ToDoListAuthenticationTable(UserID))";

            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();

            dbConnection.Close();
        }

        private void InitializeAuthenticationDatabase(string path)
        {
            SQLiteConnection dbConnection = new SQLiteConnection("Data Source=" + path + "ToDoListDatabase.sqlite;Version=3;");
            dbConnection.Open();

            string sql = "CREATE TABLE ToDoListAuthenticationTable (" +
                         "UserID INTEGER PRIMARY KEY AUTOINCREMENT," +
                         "Username VARCHAR(20) NOT NULL UNIQUE," +
                         "Password VARCHAR(50) NOT NULL)";

            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
            dbConnection.Close();
        }

        private void InitializeDatabase(string databasePath, string testDatabasePath)
        {
            if (Directory.Exists(databasePath))
            {
                Directory.Delete(databasePath, true);
            }

            Directory.CreateDirectory(databasePath);
            SQLiteConnection.CreateFile(databasePath+"ToDoListDatabase.sqlite");

            Directory.CreateDirectory(testDatabasePath);
            SQLiteConnection.CreateFile(testDatabasePath+"ToDoListDatabase.sqlite");
        }
    }
}
