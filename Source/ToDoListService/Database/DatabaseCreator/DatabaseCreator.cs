using System.Data.SQLite;

namespace ToDoListService.DatabaseCreator
{
    class DatabaseCreator
    {
        static void Main(string[] args)
        {
            SQLiteConnection.CreateFile("ToDoListDatabase.sqlite");
            SQLiteConnection dbConnection = new SQLiteConnection("Data Source=ToDoListDatabase.sqlite;Version=3;");
            dbConnection.Open();

            string sql = "CREATE TABLE ToDoListAuthentication ("     +
                            "Username VARCHAR(20) NOT NULL UNIQUE,"  +
                            "Password VARCHAR(50) NOT NULL)"         ;

            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();

            sql = "CREATE TABLE ToDoListData ("              +
                            "Mode INT NOT NULL, "            +
                            "Title VARCHAR(50) NOT NULL, " +
                            "Notes VARCHAR(500), " +
                            "Reminder DATETIME, "            +
                            "Username VARCHAR(20) NOT NULL," +
                            "FOREIGN KEY(Username) REFERENCES ToDoListAuthentication(Username))";

            command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();

            dbConnection.Close();
        }
    }
}
