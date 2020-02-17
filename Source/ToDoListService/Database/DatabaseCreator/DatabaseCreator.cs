﻿using System.Data.SQLite;

namespace ToDoListService.DatabaseCreator
{
    class DatabaseCreator
    {
        static void Main(string[] args)
        {
            SQLiteConnection.CreateFile("ToDoListDatabase.sqlite");
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=ToDoListDatabase.sqlite;Version=3;");
            m_dbConnection.Open();

            string sql = "create table highscores (name varchar(20), score int)";

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            sql = "insert into highscores (name, score) values ('Me', 9001)";

            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            m_dbConnection.Close();
        }
    }
}
