using BackEnd.Models;

namespace BackEnd.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<List<CustomerModel>> GetCustomers();
    }
}
