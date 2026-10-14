using Microsoft.EntityFrameworkCore;

public class CustomerService : ICustomerService
{
    private readonly AppDbContext _context;


    public CustomerService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Customer>> GetAllCustomerAsync()
    {
        var customers = await _context.Customers.ToListAsync();
        return customers;
    }

    public async Task<Customer> GetCustomerByIdAsync(int id)
    {
        var customer = await _context.Customers.FindAsync(id);
        return customer;
    }
    public async Task<Customer> AddCustomerAsync(CustomerCreateDto createDto)
    {
        Customer customer = new Customer();
        customer.Name = createDto.Name;
        customer.Email = createDto.Email;
        await _context.Customers.AddAsync(customer);
        await _context.SaveChangesAsync();
        return customer;
    }
    public async Task<Customer> UpdateCustomerAsync(int id, CustomerCreateDto createDto)
    {
        var customer = await _context.Customers.FindAsync(id);
        if(customer == null)
        {
            return null;
        }
        customer.Email = createDto.Email;
        customer.Name = createDto.Name;
        await _context.SaveChangesAsync();
        return customer;
        
    }
    public async Task<bool> DeleteCustomerAsync(int id)
    {
        var customer = await _context.Customers.FindAsync(id);
        if(customer == null)
        {
            return false;
        }
        _context.Customers.Remove(customer);
        await _context.SaveChangesAsync();
        return true;
        
    }
}