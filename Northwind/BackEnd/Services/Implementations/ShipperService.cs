using BackEnd.Models;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class ShipperService : IShipperService
    {
        public IUnidadDeTrabajo _unidadDeTrabajo;

        public ShipperService(IUnidadDeTrabajo unidadDeTrabajo) 
        { 
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        ShipperModel Convertir(Shipper shipper)
        {
            return new ShipperModel
            {
                ShipperId = shipper.ShipperId,
                CompanyName = shipper.CompanyName,
                Phone = shipper.Phone
            };
        }

        Shipper Convertir(ShipperModel shipper)
        {
            return new Shipper
            {
                ShipperId = shipper.ShipperId,
                CompanyName = shipper.CompanyName,
                Phone = shipper.Phone
            };
        }

        public bool AddShipper(ShipperModel shipper)
        {
            Shipper entity = Convertir(shipper);
            _unidadDeTrabajo._shipperDAL.Add(entity);
            return _unidadDeTrabajo.Complete();
        }

        public bool DeteleShipper(ShipperModel shipper)
        {
            Shipper entity = Convertir(shipper);
            _unidadDeTrabajo._shipperDAL.Remove(entity);
            return _unidadDeTrabajo.Complete();
        }

        public ShipperModel GetById(int id)
        {
            var entity = _unidadDeTrabajo._shipperDAL.Get(id);

            ShipperModel shipperModel = Convertir(entity);
            return shipperModel;
        }

        public IEnumerable<ShipperModel> GetShips()
        {
            var result = _unidadDeTrabajo._shipperDAL.GetAll();
            List<ShipperModel> lista = new List<ShipperModel>();
            foreach( var shipper in result)
            {
                lista.Add(Convertir(shipper));
            }
            return lista;
        }

        public bool UpdateShipper(ShipperModel shipper)
        {
            Shipper entity = Convertir(shipper);
            _unidadDeTrabajo._shipperDAL.Update(entity);
            return _unidadDeTrabajo.Complete();
        }
    }
}
