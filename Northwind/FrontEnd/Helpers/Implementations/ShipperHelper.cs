using FrontEnd.ApiModels;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class ShipperHelper : IShipperHelper
    {

        IServiceRepository ServiceRepository;

        public ShipperHelper(IServiceRepository serviceRepository)
        {
            ServiceRepository = serviceRepository;
        }

        Shipper Convertir(ShipperViewModel shipper)
        {
            return new Shipper
            {
                ShipperId = shipper.ShipperId,
                CompanyName = shipper.CompanyName,
                Phone = shipper.Phone,
            };
        }
        ShipperViewModel Convertir(Shipper shipper)
        {
            return new ShipperViewModel
            {
                ShipperId = shipper.ShipperId,
                CompanyName = shipper.CompanyName,
                Phone = shipper.Phone,
            };
        }

        public ShipperViewModel AddShipper(ShipperViewModel shipper)
        {
            HttpResponseMessage responseMessage = ServiceRepository.PostResponse("api/Shipper", Convertir(shipper));
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                // var  categoryAPI = JsonConvert.DeserializeObject<Category>(content);
            }

            return shipper;
        }

        public ShipperViewModel DeleteShipper(int id)
        {
            HttpResponseMessage responseMessage = ServiceRepository.DeleteResponse("api/Shipper/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;

            }

            return new ShipperViewModel();
        }

        public ShipperViewModel GetShipper(int id)
        {
            ShipperViewModel shipper = new ShipperViewModel();
            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/Shipper/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                shipper = Convertir(JsonConvert.DeserializeObject<Shipper>(content));
            }

            return shipper;
        }

        public List<ShipperViewModel> GetShippers()
        {
            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/Shipper");
            List<Shipper> resultado = new List<Shipper>();
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                resultado = JsonConvert.DeserializeObject<List<Shipper>>(content);
            }

            List<ShipperViewModel> lista = new List<ShipperViewModel>();

            if (resultado != null && resultado.Count > 0)
            {
                foreach (var item in resultado)
                {
                    lista.Add(Convertir(item));
                }
            }

            return lista;
        }

        public ShipperViewModel UpdateShipper(ShipperViewModel shipper)
        {

            HttpResponseMessage responseMessage = ServiceRepository.PutResponse("api/Shipper", Convertir(shipper));
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                // var  categoryAPI = JsonConvert.DeserializeObject<Category>(content);
            }

            return shipper;
        }
    }
}
