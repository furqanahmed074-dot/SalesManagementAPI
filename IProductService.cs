    using Microsoft.EntityFrameworkCore;

    public interface IProductService
    {
        Task<List<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task<Product> AddProductAsync(ProductCreateDto dto);
        Task<Product> UpdateProductAsync(int id, ProductCreateDto dto);
        Task<bool> DeleteProductAsync(int id);
        Task<List<Product>> GetProductsAsync(decimal? maxPrice, string? sortBy);
    }