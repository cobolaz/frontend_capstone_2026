using Microsoft.AspNetCore.Mvc;
using ShopApi.Models;
using ShopApi.Services;

namespace ShopApi.Controllers;

[ApiController]
[Route("api/cart")]
public class CartController : ControllerBase
{
    private readonly CartService _service;

    public CartController(CartService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts()
        => Ok(await _service.GetProductsAsync());

    [HttpPost]
    public async Task<IActionResult> AddProduct(Product product)
    {
        await _service.AddProductAsync(product);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveProduct(int id)
    {
        await _service.RemoveProductAsync(id);
        return Ok();
    }
}
