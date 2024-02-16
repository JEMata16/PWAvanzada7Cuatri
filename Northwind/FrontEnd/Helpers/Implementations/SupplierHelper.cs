using FrontEnd.ApiModels;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class SupplierHelper : ISupplierHelper
    {
        IServiceRepository ServiceRepository;

        public SupplierHelper(IServiceRepository serviceRepository)
        {
            ServiceRepository = serviceRepository;
        }

        Supplier Convertir(SupplierViewModel supplier)
        {
            return new Supplier
            {
                SupplierId = supplier.SupplierId,
                CompanyName = supplier.CompanyName,
                ContactName = supplier.ContactName,
                ContactTitle = supplier.ContactTitle,
                Address = supplier.Address,
                City = supplier.City,
                Region = supplier.Region,
                PostalCode = supplier.PostalCode,
                Country = supplier.Country,
                Phone = supplier.Phone,
                Fax = supplier.Fax,
                HomePage = supplier.HomePage

            };
        }

        SupplierViewModel Convertir(Supplier supplier)
        {
            return new SupplierViewModel
            {
                SupplierId = supplier.SupplierId,
                CompanyName = supplier.CompanyName,
                ContactName = supplier.ContactName,
                ContactTitle = supplier.ContactTitle,
                Address = supplier.Address,
                City = supplier.City,
                Region = supplier.Region,
                PostalCode = supplier.PostalCode,
                Country = supplier.Country,
                Phone = supplier.Phone,
                Fax = supplier.Fax,
                HomePage = supplier.HomePage

            };
        }

        public SupplierViewModel AddSupplier(SupplierViewModel supplier)
        {
            HttpResponseMessage responseMessage = ServiceRepository.PostResponse("api/Supplier", Convertir(supplier));
            if(responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
            }
            return supplier;
        }

        public SupplierViewModel DeleteSupplier(int id)
        {
            HttpResponseMessage responseMessage = ServiceRepository.DeleteResponse("api/Supplier/" + id.ToString());
            if(responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
            }
            return new SupplierViewModel();
        }

        public SupplierViewModel GetSupplier(int id)
        {
            SupplierViewModel supplier = new SupplierViewModel();
            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/Supplier/" + id.ToString());
            if(responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                supplier = Convertir(JsonConvert.DeserializeObject<Supplier>(content));
            }
            return supplier;
        }

        public List<SupplierViewModel> GetSuppliers()
        {
            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/Supplier");
            List<Supplier> resultado = new List<Supplier>();
            if(responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                resultado = JsonConvert.DeserializeObject <List<Supplier>>(content);
            }
            List<SupplierViewModel> lista = new List<SupplierViewModel>();

            if(resultado != null && resultado.Count > 0)
            {
                foreach( var item in resultado)
                {
                    lista.Add(Convertir(item));
                }
            }

            return lista;
        }

        public SupplierViewModel UpdateSupplier(SupplierViewModel supplier)
        {
            HttpResponseMessage responseMessage = ServiceRepository.PutResponse("api/Category", Convertir(supplier));
            if(responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
            }

            return supplier;
        }
    }
}
