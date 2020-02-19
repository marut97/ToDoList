using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListService.IDatabase
{
    public interface IAuthenticationRepository
    {
        bool RegisterUser(string username, string password);
        bool Login(string username, string password);
        bool Logout(string username);
        bool DeleteUser(string username, string password);
        bool UpdateUsername(string oldUsername, string password, string newUsername);
        bool UpdatePassword(string username, string oldPassword, string newPassword);
    }
}
