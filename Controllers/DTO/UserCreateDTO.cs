namespace PantryManagement.Controllers.DTO;

public class UserCreateDTO
{
    public string? UserName { get; set; }
    public string? UserEmail { get; set; }
    public string? UserPassword { get; set; }
    // Usado apenas para criar usuário (aceita senha no POST)
}
