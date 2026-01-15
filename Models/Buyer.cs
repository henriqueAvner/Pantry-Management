using System.ComponentModel.DataAnnotations;

namespace PantryManagement.Models;

public class Buyer
{
    [Key]
    public int BuyerId {get; set;}

    public string? BuyerName {get; set;}

    public string? BuyerContactInfo {get; set;}

    public ICollection<Product>? ListProducts {get;set;}
}