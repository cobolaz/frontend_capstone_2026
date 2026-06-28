using ShopApi.Models;
using ShopApi.Repositories;

namespace ShopApi.Services;

public class CartService
{
    private readonly ICartRepository _repo;

    public CartService(ICartRepository repo)
    {
        _repo = repo;
    }

    public Task<List<Product>> GetProductsAsync() => _repo.GetProductsAsync();
    public Task AddProductAsync(Product product) => _repo.AddProductAsync(product);
    public Task RemoveProductAsync(int id) => _repo.RemoveProductAsync(id);
}
