using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]

public class ProductController: ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts(decimal? maxPrice, string? sortBy)
    {
        var products = await _productService.GetProductsAsync(maxPrice, sortBy);
        return Ok(products);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductsById(int id)
    {
        var products = await _productService.GetProductByIdAsync(id);
        if(products == null)
        {
            return NotFound();
        }
        return Ok(products);
    }

    [HttpPost]
    public async Task<IActionResult> PostProduct(ProductCreateDto productCreateDto)
    {
        await _productService.AddProductAsync(productCreateDto);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(int id, ProductCreateDto updatedProduct)
{
    
    var product = await _productService.UpdateProductAsync(id,updatedProduct);
    if(product == null)
        {
            return NotFound();
        }
    return Ok();

}


[HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
{
    var product = await _productService.DeleteProductAsync(id);
    if(product == false)
        {
            return NotFound();
        }
    return Ok();
}


}
