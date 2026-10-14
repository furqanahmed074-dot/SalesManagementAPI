using Microsoft.AspNetCore.Mvc;



[Route("api/[controller]")]
[ApiController]

    public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet]
    public async Task<IActionResult> GetCustomers()
    {
        var customers = await _customerService.GetAllCustomerAsync();
        return Ok(customers);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCustomerById(int id)
    {
        var customer = await _customerService.GetCustomerByIdAsync(id);
        if (customer == null)
        {
            return NotFound();
        }
        return Ok(customer);
    }

    [HttpPost]
    public async Task<IActionResult> PostCustomer(CustomerCreateDto createDto)
    
    {
        await _customerService.AddCustomerAsync(createDto);
        return Created();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCustomer(int id, CustomerCreateDto createDto)
    {
        var customer = await _customerService.UpdateCustomerAsync(id,createDto);
        if (customer == null)
        {
            return NotFound();
        }
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCustomer(int id)
    {
        var customer = await _customerService.DeleteCustomerAsync(id);
        if(customer == false)
        {
            return NotFound();
        }
        return Ok();
    }
}
