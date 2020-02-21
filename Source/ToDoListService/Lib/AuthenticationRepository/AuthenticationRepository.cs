using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using ToDoListService.Interfaces.IAuthenticationRepository;

namespace ToDoListService.Lib.AuthenticationRepository
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly string m_connectionString;
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
            return AddUser(username, Encrypt(password));
        }

        private string Encrypt(string password)
        {
            const string characterSet  = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890!@#$%&*<>?";
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
            SQLiteConnection dbConnection = new SQLiteConnection(m_connectionString); 
            try
            {
                dbConnection.Open();
                var cmd = new SQLiteCommand(dbConnection)
                {
                    CommandText = "INSERT INTO ToDoListAuthentication(Username, Password) VALUES("+username+","+password+")"
                };

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                //throw fault exception
                dbConnection.Close();
                return false;
            }
            
        }

        private bool UserExists(string username)
        {
            bool userExists = false;
            SQLiteConnection dbConnection = new SQLiteConnection(m_connectionString);
            try
            {
                dbConnection.Open();
                var cmd = new SQLiteCommand(dbConnection)
                {
                    CommandText = "SELECT ID FROM ToDoListAuthentication WHERE Username = "+username
                };

                SQLiteDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    userExists = true;
                }
                reader.Close();
                dbConnection.Close();
                return userExists;
            }
            catch (Exception e)
            {
                //throw fault exception
                dbConnection.Close();
                return false;
            }
        }

        public bool Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public bool Logout(string username)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUser(string username, string password)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUsername(string oldUsername, string password, string newUsername)
        {
            throw new NotImplementedException();
        }

        public bool UpdatePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }
    }
}
