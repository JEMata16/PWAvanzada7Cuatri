using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class ShipperController : Controller
    {
        IShipperHelper ShipperHelper;

        public ShipperController(IShipperHelper shipperHelper)
        {
            ShipperHelper = shipperHelper;
        }


        // GET: ShipperController
        public ActionResult Index()
        {
            List<ShipperViewModel> lista = ShipperHelper.GetShippers();
            return View(lista);
        }

        // GET: ShipperController/Details/5
        public ActionResult Details(int id)
        {
            ShipperViewModel shipper = ShipperHelper.GetShipper(id);
            return View(shipper);
        }

        // GET: ShipperController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShipperController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ShipperViewModel shipper)
        {
            try
            {
                ShipperHelper.AddShipper(shipper);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ShipperController/Edit/5
        public ActionResult Edit(int id)
        {
            ShipperViewModel shipper = ShipperHelper.GetShipper(id);
            return View(shipper);
        }

        // POST: ShipperController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ShipperViewModel shipper)
        {
            try
            {
                ShipperHelper.UpdateShipper(shipper);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ShipperController/Delete/5
        public ActionResult Delete(int id)
        {
            ShipperViewModel shipper = ShipperHelper.GetShipper(id);
            return View(shipper);
        }

        // POST: ShipperController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ShipperViewModel shipper)
        {
            try
            {
                ShipperHelper.DeleteShipper(shipper.ShipperId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
