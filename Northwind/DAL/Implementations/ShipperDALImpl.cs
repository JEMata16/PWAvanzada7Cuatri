using DAL.Interfaces;
using Entities.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class ShipperDALImpl : DALGenericoImpl<Shipper>, IShipperDAL
    {
        NorthwindContext _context;
        public ShipperDALImpl(NorthwindContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Shipper> GetAll()
        {
            List<sp_GetAllShippers_Result> results;
            string sql = "[dbo].[sp_GetAllShippers]";

            results = _context.Sp_GetAllShippers_Results.
                FromSqlRaw(sql)
                .ToList();

            List<Shipper> shippers = new List<Shipper>();

            foreach(var item in results)
            {
                shippers.Add(
                    new Shipper
                    {
                        ShipperId = item.ShipperId,
                        CompanyName = item.CompanyName,
                        Phone = item.Phone,
                    }
                    );
            }
            return shippers;
        }

        public Shipper Get(int id)
        {
            string sql = "exec [dbo].[sp_GetShipperById] @ShipperId";
            var param = new SqlParameter
            {
                ParameterName = "@ShipperId",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Input,
                Value = id
            };
            var shipper = _context.Set<Shipper>()
                          .FromSqlRaw(sql, param)
                          .AsEnumerable()
                          .FirstOrDefault();
            return shipper;

        }

        public bool Remove(Shipper entity)
        {

            try
            {
                string sql = "exec [dbo].[sp_RemoveShipper] @ShipperId";
                var param = new SqlParameter
                {
                    ParameterName = "@ShipperId",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Direction = System.Data.ParameterDirection.Input,
                    Value = entity.ShipperId
                };
                _context.Database.ExecuteSqlRaw(sql, param);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Update(Shipper entity)
        {

            try
            {

                string sql = "exec [dbo].[sp_UpdateShipper] @ShipperId, @Phone, @CompanyName";
                var param = new SqlParameter[]
                {
                    new SqlParameter()
                    {
                        ParameterName = "@ShipperId",
                        SqlDbType = System.Data.SqlDbType.Int,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = entity.ShipperId
                    },

                    new SqlParameter()
                    {
                       ParameterName = "@Phone",
                        SqlDbType = System.Data.SqlDbType.VarChar,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = entity.Phone
                    },
                    new SqlParameter()
                    {
                       ParameterName = "@CompanyName",
                        SqlDbType = System.Data.SqlDbType.VarChar,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = entity.CompanyName
                    }
                };

                _Context.Database.ExecuteSqlRaw(sql,param);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
