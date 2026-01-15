namespace PantryManagement.Controllers.DTO;

public class BuyerDTO
{
    public int BuyerId { get; set; }
    public string? BuyerName { get; set; }
    public string? BuyerContactInfo { get; set; }
    // ListProducts omitida para evitar referências circulares
}
