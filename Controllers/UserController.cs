using Microsoft.AspNetCore.Mvc;
using PantryManagement.Models;
using PantryManagement.Repository.Interfaces;
using PantryManagement.Controllers.DTO;

namespace PantryManagement.Controllers;

[ApiController]
[Route("users")]
public class UserController : Controller
{
    private readonly IUserRepository userRepository;

    public UserController(IUserRepository repository)
    {
        userRepository = repository;
    }

    [HttpGet]
    public IActionResult GetUsers()
    {
        var users = userRepository.GetUsers();
        var userDTOs = users.Select(u => new UserDTO
        {
            UserId = u.UserId,
            UserName = u.UserName,
            UserEmail = u.UserEmail
        });
        return Ok(userDTOs);
    }

    [HttpGet("/{userId}")]
    public IActionResult GetUserById(int userId)
    {
        try
        {
            var user = userRepository.GetUserById(userId);
            var userDTO = new UserDTO
            {
                UserId = user.UserId,
                UserName = user.UserName,
                UserEmail = user.UserEmail
            };
            return Ok(userDTO);
        }
        catch (Exception ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    [HttpPost]
    public IActionResult AddUser(UserCreateDTO userDTO)
    {
        try
        {
            var user = new User
            {
                UserName = userDTO.UserName,
                UserEmail = userDTO.UserEmail,
                UserPassword = userDTO.UserPassword
            };
            var createdUser = userRepository.AddUser(user);
            var responseDTO = new UserDTO
            {
                UserId = createdUser.UserId,
                UserName = createdUser.UserName,
                UserEmail = createdUser.UserEmail
            };
            return Created("", responseDTO);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpDelete("/{userId}")]
    public IActionResult DeleteUser(int userId)
    {
        try
        {
            userRepository.DeleteUser(userId);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }
}
