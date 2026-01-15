namespace PantryManagement.Repository.Interfaces;
using PantryManagement.Models;
public interface IUser
{
    IEnumerable<User> GetUsers();
    User GetUserById(int userId);
    User AddUser (User user);

    void DeleteUser(int userId);
}