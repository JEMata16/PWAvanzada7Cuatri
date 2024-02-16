using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class UnidadDeTrabajo : IUnidadDeTrabajo
    {

        public ICategoryDAL _categoryDAL { get; }
        public IShipperDAL _shipperDAL { get; }
        public ISupplierDAL _supplierDAL { get; }
        public IEmployeeDAL _employeeDAL {  get; }
        public ICustomerDAL _customerDAL { get; }
        public IOrdersDAL _ordersDAL { get; }

        private readonly NorthwindContext _context;

        public UnidadDeTrabajo(NorthwindContext northWindContext,
                                ICategoryDAL categoryDAL,
                                IShipperDAL shipperDAL,
                                ISupplierDAL supplierDAL,
                                IEmployeeDAL employeeDAL,
                                ICustomerDAL customerDAL,
                                IOrdersDAL ordersDAL
                                )
        {
            _context = northWindContext;
            _categoryDAL = categoryDAL;
            _shipperDAL = shipperDAL;
            _supplierDAL = supplierDAL;
            _employeeDAL = employeeDAL;
            _customerDAL = customerDAL;
            _ordersDAL = ordersDAL;
        }


        public bool Complete()
        {
            try
            {
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

               return false;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
