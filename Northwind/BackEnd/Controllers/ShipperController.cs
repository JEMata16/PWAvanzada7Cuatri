using BackEnd.Models;
using BackEnd.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipperController : ControllerBase
    {

        IShipperService ShipperService;

        public ShipperController(IShipperService shipperService)
        {
            ShipperService = shipperService;
        }


        // GET: api/<ShipperController>
        [HttpGet]
        public IEnumerable<ShipperModel> Get()
        {
            return ShipperService.GetShips();
        }

        // GET api/<ShipperController>/5
        [HttpGet("{id}")]
        public ShipperModel Get(int id)
        {
            return ShipperService.GetById(id);
        }

        // POST api/<ShipperController>
        [HttpPost]
        public string Post([FromBody] ShipperModel shipper)
        {
            var result = ShipperService.AddShipper(shipper);

            if (result)
            {
                return "Shipper Agregado Correctamente.";
            }
            return "Hubo un error al agregar la entidad.";
        }

        // PUT api/<ShipperController>/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] ShipperModel shipper)
        {
            var result = ShipperService.UpdateShipper(shipper);

            if (result)
            {
                return "Shipper Editado Correctamente.";
            }
            return "Hubo un error al editar la entidad";
        }

        // DELETE api/<ShipperController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            ShipperModel shipper = new ShipperModel {ShipperId = id};
            var result = ShipperService.DeteleShipper(shipper);

            if (result)
            {
                return "Shipper Eliminado Correctamente.";
            }
            return "Hubo un error al eliminar la entidad";
        }
    }
}
