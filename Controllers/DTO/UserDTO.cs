namespace PantryManagement.Controllers.DTO;

public class UserDTO
{
    public int UserId { get; set; }
    public string? UserName { get; set; }
    public string? UserEmail { get; set; }
    // UserPassword é omitido por ser sensível
}
