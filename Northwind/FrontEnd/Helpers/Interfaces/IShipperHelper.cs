using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface IShipperHelper
    {
        List<ShipperViewModel> GetShippers();
        ShipperViewModel GetShipper(int id);
        ShipperViewModel AddShipper(ShipperViewModel shipper);
        ShipperViewModel DeleteShipper(int id);
        ShipperViewModel UpdateShipper(ShipperViewModel shipper);
    }
}
