using Microsoft.AspNetCore.Mvc;
using PantryManagement.Models;
using PantryManagement.Repository;
using PantryManagement.Repository.Interfaces;
using PantryManagement.Controllers.DTO;

namespace PantryManagement.Controllers;

[ApiController]
[Route("buyers")]
public class BuyerController : Controller
{
    private readonly IBuyerRepository buyerRepository;

    public BuyerController(IBuyerRepository repository)
    {
        buyerRepository = repository;
    }

    [HttpGet]
    public IActionResult GetBuyers()
    {
        var buyers = buyerRepository.GetBuyers();
        var buyerDTOs = buyers.Select(b => new BuyerDTO
        {
            BuyerId = b.BuyerId,
            BuyerName = b.BuyerName,
            BuyerContactInfo = b.BuyerContactInfo
        });
        return Ok(buyerDTOs);
    }

    [HttpGet("/{buyerId}")]
    public IActionResult GetBuyerById(int buyerId)
    {
        try
        {
            var buyer = buyerRepository.GetBuyerById(buyerId);
            var buyerDTO = new BuyerDTO
            {
                BuyerId = buyer.BuyerId,
                BuyerName = buyer.BuyerName,
                BuyerContactInfo = buyer.BuyerContactInfo
            };
            return Ok(buyerDTO);
        }
        catch (Exception ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    [HttpPost]
    public IActionResult AddBuyer(BuyerDTO buyerDTO)
    {
        try
        {
            var buyer = new Buyer
            {
                BuyerName = buyerDTO.BuyerName,
                BuyerContactInfo = buyerDTO.BuyerContactInfo
            };
            var createdBuyer = buyerRepository.AddBuyer(buyer);
            var responseDTO = new BuyerDTO
            {
                BuyerId = createdBuyer.BuyerId,
                BuyerName = createdBuyer.BuyerName,
                BuyerContactInfo = createdBuyer.BuyerContactInfo
            };
            return Created("", responseDTO);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpDelete("/{buyerId}")]
    public IActionResult DeleteBuyer(int buyerId)
    {
        try
        {
            buyerRepository.DeleteBuyer(buyerId);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    [HttpGet("/{buyerId}/products")]
    public IActionResult FindProductsByBuyer(int buyerId)
    {
        try
        {
            var products = buyerRepository.FindProductsByBuyer(buyerId);
            var productDTOs = products.Select(p => new ProductDTO
            {
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                ProductQuantity = p.ProductQuantity,
                BuyerId = p.BuyerId,
                ExpiresIn = p.ExpiresIn
            });
            return Ok(productDTOs);
        }
        catch (Exception ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    [HttpPost("/{buyerId}/products/{productId}")]
    public IActionResult AddProductToBuyer(int buyerId, int productId)
    {
        try
        {
            var buyer = buyerRepository.AddProductToABuyer(productId, buyerId);
            var buyerDTO = new BuyerDTO
            {
                BuyerId = buyer.BuyerId,
                BuyerName = buyer.BuyerName,
                BuyerContactInfo = buyer.BuyerContactInfo
            };
            return Ok(buyerDTO);
        }
        catch (Exception ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }
}