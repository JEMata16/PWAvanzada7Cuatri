using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnidadDeTrabajo : IDisposable
    {
        ICategoryDAL _categoryDAL { get; }
        IShipperDAL _shipperDAL { get; }
        ISupplierDAL _supplierDAL { get; }
        IEmployeeDAL _employeeDAL { get; }
        ICustomerDAL _customerDAL { get; }
        IOrdersDAL _ordersDAL { get; }
        bool Complete();
    }
}
