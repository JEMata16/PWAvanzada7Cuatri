using BackEnd.Models;

namespace BackEnd.Services.Interfaces
{
    public interface ISupplierService
    {
        IEnumerable<SupplierModel> GetSuppliers();
        SupplierModel GetById(int id);
        bool AddSupplier(SupplierModel supplier);
        bool UpdateSupplier(SupplierModel supplier);
        bool DeleteSupplier(SupplierModel supplier);
    }
}
