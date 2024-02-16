using BackEnd.Models;

namespace BackEnd.Services.Interfaces
{
    public interface IShipperService
    {
        IEnumerable<ShipperModel> GetShips();
        ShipperModel GetById(int id);
        bool AddShipper(ShipperModel shipper);
        bool UpdateShipper(ShipperModel shipper);
        bool DeteleShipper(ShipperModel shipper);
    }
}
