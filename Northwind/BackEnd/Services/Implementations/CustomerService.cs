using BackEnd.Models;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class CustomerService : ICustomerService
    {
        IUnidadDeTrabajo _unidadDeTrabajo;

        public CustomerService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        CustomerModel Convertir(Customer customer)
        {
            return new CustomerModel
            {
                CustomerId = customer.CustomerId,
                CompanyName = customer.CompanyName,
            };

        }

        public Task<List<CustomerModel>> GetCustomers()
        {
            var customers = _unidadDeTrabajo._customerDAL.GetAll();
            List<CustomerModel> resultado = new List<CustomerModel>();
            foreach (var customer in customers)
            {
                resultado.Add(Convertir(customer));
            }
            return Task.FromResult(resultado);
        }
    }
}
