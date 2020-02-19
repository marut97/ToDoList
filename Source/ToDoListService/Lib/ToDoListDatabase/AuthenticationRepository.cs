using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using ToDoListService.IDatabase;

namespace ToDoListService.ToDoListDatabase
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        public bool RegisterUser(string username, string password)
        {
            if (UserExists(username))
                return false;
            if (PasswordValidator(password))
                return false;
            var encryptedPassword = Encrypt(password);
            return true;
        }

        private string Encrypt(string password)
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

        private bool PasswordValidator(string password)
        {
            throw new NotImplementedException();
        }

        private bool UserExists(string username)
        {
            throw new NotImplementedException();
        }
    }
}
