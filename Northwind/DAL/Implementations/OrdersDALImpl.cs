using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class OrdersDALImpl : DALGenericoImpl<Order>, IOrdersDAL
    {
        public OrdersDALImpl(NorthwindContext northWindContext) : base(northWindContext)
        {
        }
    }
}
