using BackEnd.Models;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class SupplierService : ISupplierService
    {

        public IUnidadDeTrabajo _unidadDeTrabajo;

        public SupplierService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        SupplierModel Convertir(Supplier supplier)
        {
            return new SupplierModel
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
        Supplier Convertir(SupplierModel supplier)
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

        public bool AddSupplier(SupplierModel supplier)
        {
            Supplier entity = Convertir(supplier);
            _unidadDeTrabajo._supplierDAL.Add(entity);
            return _unidadDeTrabajo.Complete();
        }

        public bool DeleteSupplier(SupplierModel supplier)
        {
            Supplier entity = Convertir(supplier);
            _unidadDeTrabajo._supplierDAL.Remove(entity);
            return _unidadDeTrabajo.Complete();
        }

        public SupplierModel GetById(int id)
        {
            var entity = _unidadDeTrabajo._supplierDAL.Get(id);

            SupplierModel supplierModel = Convertir(entity);
            return supplierModel;
        }

        public IEnumerable<SupplierModel> GetSuppliers()
        {
            var result = _unidadDeTrabajo._supplierDAL.GetAll();
            List<SupplierModel> lista = new List<SupplierModel>();
            foreach(var supplier in result)
            {
                lista.Add(Convertir(supplier));
            }
            return lista;
        }

        public bool UpdateSupplier(SupplierModel supplier)
        {
            Supplier entity = Convertir(supplier);
            _unidadDeTrabajo._supplierDAL.Update(entity);
            return _unidadDeTrabajo.Complete();
        }
    }
}
