using BackEnd.Models;
using BackEnd.Services.Interfaces;
using DAL.Implementations;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        public IUnidadDeTrabajo _unidadDeTrabajo;

        public EmployeeService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        EmployeeModel Convertir(Employee employee)
        {
            return new EmployeeModel
            {
                EmployeeId = employee.EmployeeId,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
            };
        }

        public Task<List<EmployeeModel>> GetEmployees()
        {
            var employees = _unidadDeTrabajo._employeeDAL.GetAll();
            List<EmployeeModel> result = new List<EmployeeModel>();
            foreach(var employee in employees)
            {
                result.Add(Convertir(employee));
            }
            return Task.FromResult(result);
        }
    }
}
