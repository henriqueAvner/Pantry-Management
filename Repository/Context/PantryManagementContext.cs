using Microsoft.EntityFrameworkCore;
using PantryManagement.Models;

public class PantryManagementContext : DbContext, IPantryManagementContext
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Product> Products { get ; set; } = null!;
    public DbSet<Buyer> Buyers { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = "Server=127.0.0.1;Database=PantryManagementDB;User=SA;Password=PantryManagementDB123!;TrustServerCertificate=true";

            optionsBuilder.UseSqlServer(connectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Buyer>()
        .HasMany(b => b.ListProducts)
        .WithOne(p => p.Buyer)
        .HasForeignKey(p => p.BuyerId);
    }
}