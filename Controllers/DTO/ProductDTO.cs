namespace PantryManagement.Controllers.DTO;

public class ProductDTO
{
    public int ProductId { get; set; }
    public string? ProductName { get; set; }
    public int ProductQuantity { get; set; }
    public int BuyerId { get; set; }
    public DateTime ExpiresIn { get; set; }
    // Buyer navigation property omitida para evitar referências circulares
}
