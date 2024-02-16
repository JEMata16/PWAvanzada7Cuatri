using BackEnd.Models;

namespace BackEnd.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<EmployeeModel>> GetEmployees();
    }
}
