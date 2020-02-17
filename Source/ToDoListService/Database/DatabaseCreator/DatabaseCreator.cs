using System.Data.SQLite;

namespace ToDoListService.DatabaseCreator
{
    class DatabaseCreator
    {
        static void Main(string[] args)
        {
            SQLiteConnection.CreateFile("ToDoListDatabase.sqlite");
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=ToDoListDatabase.sqlite;Version=3;");
            m_dbConnection.Open();

            string sql = "CREATE TABLE ToDoListData ("       +
                            "Mode INT NOT NULL, "            +
                            "Title VARCHAR(50) NOT NULL, "   +
                            "Notes VARCHAR(MAX), "           +
                            "Reminder DATETIME, "            +
                            "Username VARCHAR(20) NOT NULL FOREIGN_KEY REFERENCES ToDoListAuthentication(Username))";

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            sql = "CREATE TABLE ToDoListAuthentication (" +
                    "Username VARCHAR(20) NOT NULL" + 
                    "Password VARCHAR(20) NOT NULL)";

            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            m_dbConnection.Close();
        }
    }
}
