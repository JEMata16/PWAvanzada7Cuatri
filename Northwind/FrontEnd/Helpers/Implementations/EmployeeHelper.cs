using FrontEnd.ApiModels;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class EmployeeHelper : IEmployeeHelper
    {

        IServiceRepository _repository;

        public EmployeeHelper(IServiceRepository repository)
        {
            _repository = repository;
        }


        EmployeeViewModel Convertir(Employee employee)
        {
            return new EmployeeViewModel
            {
                EmployeeId = employee.EmployeeId,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
            };
        }

        public List<EmployeeViewModel> GetAll()
        {
            List<EmployeeViewModel> lista = new List<EmployeeViewModel>();
            List<Employee> result = new List<Employee>();
            HttpResponseMessage response = _repository.GetResponse("api/employee");

            if(response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                result = JsonConvert.DeserializeObject<List<Employee>>(content); 
            }

            foreach(var item in result)
            {
                lista.Add(Convertir(item));
            }

            return lista;
        }
    }
}
