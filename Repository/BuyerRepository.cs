namespace PantryManagement.Repository;


using PantryManagement.Models;
using PantryManagement.Repository.Interfaces;

public class BuyerRepository(PantryManagementContext context) : IBuyerRepository
{
    private readonly PantryManagementContext pmContext = context;

    public Buyer AddBuyer(Buyer buyer)
    {
        var currBuyer = pmContext.Buyers.FirstOrDefault(b => b.BuyerId == buyer.BuyerId);

        if(currBuyer != null)
        {
            throw new InvalidOperationException("Buyer already exists");
        }
        pmContext.Buyers.Add(buyer);
        pmContext.SaveChanges();

        return buyer;
    }

    public void DeleteBuyer(int buyerId)
    {
        var findBuyer = pmContext.Buyers.Find(buyerId) ?? throw new KeyNotFoundException("Buyer not found");

        pmContext.Buyers.Remove(findBuyer);
        pmContext.SaveChanges();
    }

    public Buyer GetBuyerById(int buyerId)
    {
        var findBuyer = pmContext.Buyers.Find(buyerId) ?? throw new KeyNotFoundException("Buyer not found");

        return findBuyer;
    }

    public IEnumerable<Buyer> GetBuyers()
    {
        return pmContext.Buyers.ToList();
    }

    public List<Product> FindProductsByBuyer(int buyerId)
    {
        var findBuyerList = pmContext.Buyers?.Find(buyerId)?.ListProducts ?? throw new KeyNotFoundException("Buyer not found");

        return [.. findBuyerList];
    }

    public Buyer AddProductToABuyer(int productId, int buyerId)
    {
        Product findProduct = pmContext.Products.Find(productId) ?? throw new KeyNotFoundException("Product not found");
        Buyer findBuyer = pmContext.Buyers.Find(buyerId) ?? throw new KeyNotFoundException ("Buyer not found");

        findProduct.BuyerId = buyerId;
        pmContext.SaveChanges();

        return findBuyer;


    }
}