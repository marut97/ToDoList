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
        }

        private void InitializeToDoListDatabase(string path)
        {
            SQLiteConnection dbConnection = new SQLiteConnection("Data Source=" + path + "ToDoListDatabase.sqlite;Version=3;");
            dbConnection.Open();

            string sql = "CREATE TABLE ToDoListData (" +
                  "Mode INT NOT NULL, " +
                  "Title VARCHAR(50) NOT NULL, " +
                  "Notes VARCHAR(500), " +
                  "Reminder DATETIME, " +
                  "Username VARCHAR(20) NOT NULL," +
                  "FOREIGN KEY(Username) REFERENCES ToDoListAuthentication(Username))";

            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();

            dbConnection.Close();
        }

        private void InitializeAuthenticationDatabase(string path)
        {
            SQLiteConnection dbConnection = new SQLiteConnection("Data Source=" + path + "ToDoListDatabase.sqlite;Version=3;");
            dbConnection.Open();

            string sql = "CREATE TABLE ToDoListAuthentication (" +
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
