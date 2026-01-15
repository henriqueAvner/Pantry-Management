using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PantryManagement.Models;

public class Product
{
    [Key]
    public int ProductId {get; set;}

    public string? ProductName {get; set;}

    public int ProductQuantity {get; set;}

    [ForeignKey("BuyerId")]
    public int BuyerId {get; set;}

    public DateTime ExpiresIn {get; set;}

    public Buyer? Buyer {get;set;}
}