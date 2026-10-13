using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

public class ProductService : IProductService
{
    private readonly AppDbContext _context;
    public ProductService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Product>> GetAllProductsAsync()
    {
         var products = await _context.Products.ToListAsync();
         return products;
    }

    public async Task<Product> GetProductByIdAsync(int id)
    {
         var products = await _context.Products.FindAsync(id);
         return products;
    }

    public async Task<Product> AddProductAsync(ProductCreateDto dto)
    {
        Product product = new Product();
        product.Name = dto.Name;
        product.Price = dto.Price;
        product.StockQuantity = dto.StockQuantity;
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<Product> UpdateProductAsync(int id, ProductCreateDto dto)
    {
        var product = await _context.Products.FindAsync(id);
    if(product == null)
        {
            return null;
        }
    product.Name = dto.Name;
    product.Price = dto.Price;
    product.StockQuantity = dto.StockQuantity;
    await _context.SaveChangesAsync();
    return product;
    }

       public async Task<bool> DeleteProductAsync(int id)
    {
         var product = await _context.Products.FindAsync(id);
    if(product == null)
        {
            return false;
        }
    _context.Products.Remove(product);
     await _context.SaveChangesAsync();
     return true;
    }

    public async Task<List<Product>> GetProductsAsync(decimal? maxPrice, string? sortBy)
    {
        var query = _context.Products.AsQueryable();
        if (maxPrice.HasValue)
        {
            query = query.Where(p => p.Price <= maxPrice.Value);
        }
        if(sortBy == "price")
        {
            query = query.OrderBy(p => p.Price);
        }

        return await query.ToListAsync();
        }
    }