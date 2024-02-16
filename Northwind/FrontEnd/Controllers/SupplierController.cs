using FrontEnd.Helpers.Implementations;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class SupplierController : Controller
    {
        ISupplierHelper SupplierHelper;

        public SupplierController(ISupplierHelper supplierHelper)
        {
            SupplierHelper = supplierHelper;
        }

        // GET: SupplierController
        public ActionResult Index()
        {
            List<SupplierViewModel> lista = SupplierHelper.GetSuppliers();
            return View(lista);
        }

        // GET: SupplierController/Details/5
        public ActionResult Details(int id)
        {
            SupplierViewModel supplier = SupplierHelper.GetSupplier(id);
            return View(supplier);
        }

        // GET: SupplierController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SupplierController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SupplierViewModel supplier)
        {
            try
            {
                SupplierHelper.AddSupplier(supplier);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SupplierController/Edit/5
        public ActionResult Edit(int id)
        {
            SupplierViewModel supplier = SupplierHelper.GetSupplier(id);
            return View(supplier);
        }

        // POST: SupplierController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SupplierViewModel supplier)
        {
            try
            {
                SupplierHelper.UpdateSupplier(supplier);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SupplierController/Delete/5
        public ActionResult Delete(int id)
        {
            SupplierViewModel supplier = SupplierHelper.GetSupplier(id);
            return View(supplier);
        }

        // POST: SupplierController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(SupplierViewModel supplier)
        {
            try
            {
                SupplierHelper.DeleteSupplier(supplier.SupplierId);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
