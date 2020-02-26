using System.Data.SQLite;
using ToDoListService.Interfaces.IAuthenticationRepository;

namespace ToDoListService.Lib.AuthenticationRepository
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        public AuthenticationRepository(bool test = false)
        {
            if (test)
                m_connectionString = "Data Source=C:\\ToDoListDatabase\\Test\\ToDoListDatabase.sqlite;Version=3;";
            else
                m_connectionString = "Data Source=C:\\ToDoListDatabase\\ToDoListDatabase.sqlite;Version=3;";
        }

        public bool RegisterUser(string username, string password)
        {
            if (UserExists(username))
            {
                return false;
            }
            return AddUser(username, password);
        }
        public int Login(string username, string password)
        {
            try
            {
                var userID = 0;
                using (var dbConnection = new SQLiteConnection(m_connectionString))
                {
                    dbConnection.Open();
                    using (var cmd = new SQLiteCommand(dbConnection))
                    {
                        cmd.CommandText = "SELECT ID FROM ToDoListAuthenticationTable WHERE Username = '" + username + "' AND Password = '" + Encrypt(password) + "';";
                        userID = AuthenticateQuery(cmd);
                    }
                }
                return userID;
            }
            catch (SQLiteException e)
            {
                //throw fault exception
                return 0;
            }
        }

        public bool Logout(string username)
        {
            if (UserExists(username))
                return true;
            return false;
        }

        public bool DeleteUser(string username, string password)
        {
            try
            {
                int rows = 0;
                using (SQLiteConnection dbConnection = new SQLiteConnection(m_connectionString))
                {
                    dbConnection.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(dbConnection))
                    {
                        cmd.CommandText = "DELETE FROM ToDoListAuthenticationTable WHERE Username = '" + username + "' AND Password = '" + Encrypt(password) + "';";
                        rows = cmd.ExecuteNonQuery();
                    }
                }
                return (rows>0);
            }
            catch (SQLiteException e)
            {
                //throw fault exception
                return false;
            }
        }

        public bool UpdateUsername(string oldUsername, string password, string newUsername)
        {
            if (UserExists(newUsername))
                return false;
            try
            {
                int rows = 0;
                using (SQLiteConnection dbConnection = new SQLiteConnection(m_connectionString))
                {
                    dbConnection.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(dbConnection))
                    {
                        cmd.CommandText = "UPDATE ToDoListAuthenticationTable SET Username = '"+newUsername+"' WHERE Username = '"+oldUsername+"' AND Password = '"+ Encrypt(password) + "';";
                        rows = cmd.ExecuteNonQuery();
                    }
                }
                return (rows>0);
            }
            catch (SQLiteException e)
            {
                //throw fault exception
                return false;
            }
        }

        public bool UpdatePassword(string username, string oldPassword, string newPassword)
        {
            try
            {
                int rows = 0;
                using (SQLiteConnection dbConnection = new SQLiteConnection(m_connectionString))
                {
                    dbConnection.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(dbConnection))
                    {
                        cmd.CommandText = "UPDATE ToDoListAuthenticationTable SET Password = '" + Encrypt(newPassword) + "' WHERE Username = '" + username + "' AND Password = '" + Encrypt(oldPassword) + "';";
                        rows = cmd.ExecuteNonQuery();
                    }
                }
                return (rows>0);
            }
            catch (SQLiteException e)
            {
                //throw fault exception
                return false;
            }
        }


        private string Encrypt(string password)
        {
            const string characterSet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890!@#$%&*<>?";
            const string encryptionSet = "CIUEYVDOZNLTXMRPSAQHWJKBFGiopjxaqbmlucedrfsgvtyzkwnh8426395107>&$!*<@%?#";

            string encryptedPassword = "";

            foreach (char c in password)
            {
                var index = characterSet.IndexOf(c);
                encryptedPassword += encryptionSet[index];
            }

            return encryptedPassword;
        }

        private bool AddUser(string username, string password)
        {
            try
            {
                int rows = 0;
                using (SQLiteConnection dbConnection = new SQLiteConnection(m_connectionString))
                {
                    dbConnection.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(dbConnection))
                    {
                        cmd.CommandText = "INSERT INTO ToDoListAuthenticationTable(Username, Password) VALUES('" + username + "','" + Encrypt(password) + "');";
                        rows = cmd.ExecuteNonQuery();
                    }
                }
                return (rows==1);
            }
            catch (SQLiteException e)
            {
                //throw fault exception
                return false;
            }

        }

        private bool UserExists(string username)
        {
            try
            {
                var userExists = false;
                using (var dbConnection = new SQLiteConnection(m_connectionString))
                {
                    dbConnection.Open();
                    using (var cmd = new SQLiteCommand(dbConnection))
                    {
                        cmd.CommandText = "SELECT ID FROM ToDoListAuthenticationTable WHERE Username = '" + username + "';";
                        userExists = (AuthenticateQuery(cmd)>0);
                    }
                }
                return userExists;
            }
            catch (SQLiteException e)
            {
                //throw fault exception
                return false;
            }
        }

        private static int AuthenticateQuery(SQLiteCommand cmd)
        {
            using (var reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    return reader.GetInt32(0);
                }
            }
            return 0;
        }

        private readonly string m_connectionString;

    }
}
