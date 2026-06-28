using MySql.Data.MySqlClient;
using ShopApi.Models;

namespace ShopApi.Repositories;

public interface ICartRepository
{
    Task AddProductAsync(Product product);
    Task RemoveProductAsync(int productId);
    Task<List<Product>> GetProductsAsync();
}
