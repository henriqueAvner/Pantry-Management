using PantryManagement.Controllers.DTO;
using PantryManagement.Models;

namespace PantryManagement.Repository.Interfaces;
public interface IBuyerRepository
{
    IEnumerable<BuyerDTO> GetBuyers();
    BuyerDTO GetBuyerById(int buyerId);
    Buyer AddBuyer (Buyer buyer);

    void DeleteBuyer(int buyerId);

    public List<Product> FindProductsByBuyer(int buyerId);

    public Buyer AddProductToABuyer (int productId, int buyerId);

}