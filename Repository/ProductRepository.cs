namespace PantryManagement.Repository;

using PantryManagement.Models;
using PantryManagement.Repository.Interfaces;

public class ProductRepository(PantryManagementContext context) : IProductRepository
{
    private readonly PantryManagementContext pmContext = context;
    public Product AddProduct(Product product)
    {
        var productExists = pmContext.Products.FirstOrDefault(p => p.ProductId == product.ProductId);

        if(productExists != null)
        {
            throw new InvalidOperationException("Product already exists");
        }

        pmContext.Products.Add(product);
        pmContext.SaveChanges();

        return product;

    }

    public void DeleteProduct(int productId)
    {
        var findProductToDelete = pmContext.Products.Find(productId) ?? throw new KeyNotFoundException("Product not found");

        pmContext.Products.Remove(findProductToDelete);
        pmContext.SaveChanges();
    }

    public Buyer FindBuyerByProductId(int buyerId)
    {
        var findBuyer = pmContext.Products.FirstOrDefault(p => p.BuyerId == buyerId);

        Buyer currBuyer = findBuyer?.Buyer ?? throw new Exception("Buyer not found");

        return currBuyer;

        
    }

    public Product GetProductById(int productId)
    {
        Product findProduct = pmContext.Products.FirstOrDefault(p => p.ProductId == productId) ?? throw new Exception("Product not found");

        return findProduct;
    }

    public IEnumerable<Product> GetProducts()
    {
       return pmContext.Products.ToList();
    }

   
}