namespace PantryManagement.Repository.Interfaces;
using PantryManagement.Models;
public interface IProductRepository
{
    IEnumerable<Product> GetProducts();
    Product GetProductById(int productId);
    Product AddProduct (Product product);

    void DeleteProduct(int productId);
}