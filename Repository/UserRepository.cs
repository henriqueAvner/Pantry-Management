namespace PantryManagement.Repository;

using System.Collections.Generic;
using PantryManagement.Models;
using PantryManagement.Repository.Interfaces;
public class UserRepository(PantryManagementContext context) : IUserRepository
{
    private readonly PantryManagementContext pmContext = context;

    public User AddUser(User user)
    {
       var userExists = pmContext.Users.FirstOrDefault(u => u.UserId == user.UserId);

       if(userExists != null)
        {
            throw new InvalidOperationException("User already exists.");
        }
        pmContext.Add(user);
        pmContext.SaveChanges();

        return user;
        
    }

    public void DeleteUser(int userId)
    {
        var findUser = pmContext.Users.Find(userId) ?? throw new KeyNotFoundException("User not found");
        pmContext.Users.Remove(findUser);
        pmContext.SaveChanges();
    }

    public User GetUserById(int userId)
    {
        var findUser = pmContext.Users.Find(userId) ?? throw new KeyNotFoundException("User not found");

        return findUser;
        
    }

    public IEnumerable<User> GetUsers()
    {
        return pmContext.Users.ToList();
    }
}