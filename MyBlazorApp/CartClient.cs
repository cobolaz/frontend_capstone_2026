public class CartClient
{
    private readonly HttpClient _http;

    public CartClient(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<Product>> GetProductsAsync()
        => await _http.GetFromJsonAsync<List<Product>>("api/cart");

    public async Task AddProductAsync(Product product)
        => await _http.PostAsJsonAsync("api/cart", product);

    public async Task RemoveProductAsync(int id)
        => await _http.DeleteAsync($"api/cart/{id}");
}