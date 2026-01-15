using Microsoft.AspNetCore.Mvc;
using PantryManagement.Models;
using PantryManagement.Repository;
using PantryManagement.Repository.Interfaces;
using PantryManagement.Controllers.DTO;

namespace PantryManagement.Controllers;

[ApiController]
[Route("products")]
public class ProductController : Controller
{
    private readonly IProductRepository productRepository;

    public ProductController(IProductRepository repository)
    {
        productRepository = repository;
    }

    [HttpGet]
    public IActionResult GetProducts()
    {
        var products = productRepository.GetProducts();
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

    [HttpGet("/{productId}")]
    public IActionResult GetProductById(int productId)
    {
        try
        {
            var product = productRepository.GetProductById(productId);
            var productDTO = new ProductDTO
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                ProductQuantity = product.ProductQuantity,
                BuyerId = product.BuyerId,
                ExpiresIn = product.ExpiresIn
            };
            return Ok(productDTO);
        }
        catch (Exception ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    [HttpPost]
    public IActionResult AddProduct(Product product)
    {
        try
        {
            var createdProduct = productRepository.AddProduct(product);
            var productDTO = new ProductDTO
            {
                ProductId = createdProduct.ProductId,
                ProductName = createdProduct.ProductName,
                ProductQuantity = createdProduct.ProductQuantity,
                BuyerId = createdProduct.BuyerId,
                ExpiresIn = createdProduct.ExpiresIn
            };
            return Created("", productDTO);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpDelete("/{productId}")]
    public IActionResult DeleteProduct(int productId)
    {
        try
        {
            productRepository.DeleteProduct(productId);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    [HttpGet("/{productId}/buyer")]
    public IActionResult FindBuyerByProductId(int productId)
    {
        try
        {
            var buyer = productRepository.FindBuyerByProductId(productId);
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