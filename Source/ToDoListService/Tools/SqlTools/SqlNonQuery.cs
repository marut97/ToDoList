using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace SqlTools
{
    public static class SqlNonQuery
    {
        public static bool Execute(string connectionString, string command)
        {
            try
            {
                int rowsAffected = 0;
                using (SQLiteConnection dbConnection = new SQLiteConnection(connectionString))
                {
                    dbConnection.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(dbConnection))
                    {
                        cmd.CommandText = command;
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
    }
}
