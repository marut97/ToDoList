
namespace ToDoListService.Interfaces.IAuthenticationRepository
{
    public interface IAuthenticationRepository
    {
        bool RegisterUser(string username, string password);
        int Login(string username, string password);
        bool Logout(string username);
        bool DeleteUser(string username, string password);
        bool UpdateUsername(string oldUsername, string password, string newUsername);
        bool UpdatePassword(string username, string oldPassword, string newPassword);
    }
}
