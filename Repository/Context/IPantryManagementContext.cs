using Microsoft.EntityFrameworkCore;
using PantryManagement.Models;

public interface IPantryManagementContext
{
    public DbSet<User> Users {get; set;}
    public DbSet<Product> Products {get; set;}
    public DbSet<Buyer> Buyers {get; set;}

    public int SaveChanges();
}