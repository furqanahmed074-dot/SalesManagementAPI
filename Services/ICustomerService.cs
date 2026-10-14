using Microsoft.EntityFrameworkCore;

public interface ICustomerService
{
    Task<List<Customer>> GetAllCustomerAsync();
    Task<Customer> GetCustomerByIdAsync(int id);
    Task<Customer> AddCustomerAsync(CustomerCreateDto createDto);
    Task<Customer> UpdateCustomerAsync(int id, CustomerCreateDto createDto);
    Task<bool> DeleteCustomerAsync(int id);
}