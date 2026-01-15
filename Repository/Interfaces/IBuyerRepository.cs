using PantryManagement.Models;

namespace PantryManagement.Repository.Interfaces;
public interface IBuyerRepository
{
    IEnumerable<Buyer> GetBuyers();
    Buyer GetBuyerById(int buyerId);
    Buyer AddBuyer (Buyer buyer);

    void DeleteBuyer(int buyerId);

    public List<Product> FindProductsByBuyer(int buyerId);

    public Buyer AddProductToABuyer (int productId, int buyerId);

}