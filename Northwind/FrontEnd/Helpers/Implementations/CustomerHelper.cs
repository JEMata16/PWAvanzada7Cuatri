using FrontEnd.ApiModels;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class CustomerHelper : ICustomerHelper
    {
        IServiceRepository _repository;

        public CustomerHelper(IServiceRepository repository)
        {
            _repository = repository;
        }

        CustomerViewModel Convertir(Customer customer)
        {
            return new CustomerViewModel
            {
                CustomerId = customer.CustomerId,
                CompanyName = customer.CompanyName,
            };
        }


        public List<CustomerViewModel> GetAll()
        {
            List<CustomerViewModel> lista = new List<CustomerViewModel>();
            List<Customer> result = new List<Customer>();
            HttpResponseMessage response = _repository.GetResponse("api/customer");

            if(response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                result = JsonConvert.DeserializeObject<List<Customer>>(content);
            }

            foreach(var item in result)
            {
                lista.Add(Convertir(item));
            }

            return lista;
        }
    }
}
