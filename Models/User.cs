using System.ComponentModel.DataAnnotations;

namespace PantryManagement.Models;

public class User
{
    [Key]
    public int UserId {get; set;}
    public string? UserName {get; set;}

    public string? UserEmail {get; set;}

    public string? UserPassword {get; set;}
}