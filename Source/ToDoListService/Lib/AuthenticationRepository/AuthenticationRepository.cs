﻿using System;
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
        private string m_databasePath;
        public AuthenticationRepository(bool test = false)
        {
            if (test)
                m_databasePath = "C:\\ToDoListDatabase\\Test\\ToDoListDatabase.sqlite";
            else
                m_databasePath = "C:\\ToDoListDatabase\\ToDoListDatabase.sqlite";



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
                encryptedPassword= encryptedPassword+encryptionSet.ElementAt(index);
            }

            return encryptedPassword;
        }

        private bool AddUser(string username, string password)
        {
            SQLiteConnection dbConnection = new SQLiteConnection("Data Source=" + m_databasePath + ";Version=3;"); 
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
            throw new NotImplementedException();
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
