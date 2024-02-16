using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class SupplierDALImpl : DALGenericoImpl<Supplier>, ISupplierDAL
    {

        NorthwindContext _context;
        public SupplierDALImpl(NorthwindContext context) : base(context)
        {
            _context = context;
        }
    }
}
