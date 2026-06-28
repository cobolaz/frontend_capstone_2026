namespace ShopApi.Repositories;

public class MySqlCartRepository : ICartRepository
{
    private readonly string _connectionString;

    public MySqlCartRepository(IConfiguration config)
    {
        _connectionString = config.GetConnectionString("ShopDb");
    }

    public async Task AddProductAsync(Product product)
    {
        using var conn = new MySqlConnection(_connectionString);
        await conn.OpenAsync();

        const string sql = @"INSERT INTO Products (ProductID, Name, Price, Category)
                             VALUES (@id, @name, @price, @category)";

        using var cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@id", product.ProductID);
        cmd.Parameters.AddWithValue("@name", product.Name);
        cmd.Parameters.AddWithValue("@price", product.Price);
        cmd.Parameters.AddWithValue("@category", product.Category);

        await cmd.ExecuteNonQueryAsync();
    }

    public async Task RemoveProductAsync(int productId)
    {
        using var conn = new MySqlConnection(_connectionString);
        await conn.OpenAsync();

        const string sql = "DELETE FROM Products WHERE ProductID = @id";

        using var cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@id", productId);

        await cmd.ExecuteNonQueryAsync();
    }

    public async Task<List<Product>> GetProductsAsync()
    {
        var list = new List<Product>();

        using var conn = new MySqlConnection(_connectionString);
        await conn.OpenAsync();

        const string sql = "SELECT ProductID, Name, Price, Category FROM Products";

        using var cmd = new MySqlCommand(sql, conn);
        using var reader = await cmd.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            list.Add(new Product
            {
                ProductID = reader.GetInt32(0),
                Name = reader.GetString(1),
                Price = reader.GetDecimal(2),
                Category = reader.GetString(3)
            });
        }

        return list;
    }
}
