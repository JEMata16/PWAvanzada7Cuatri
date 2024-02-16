using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class OrderController : Controller
    {

        IOrderHelper _orderHelper;
        IEmployeeHelper _employeeHelper;
        IShipperHelper _shipperHelper;
        ICustomerHelper _customerHelper;

        public OrderController(IOrderHelper orderHelper, IEmployeeHelper employeeHelper, IShipperHelper shipperHelper,
            ICustomerHelper customerHelper)
        {
            _orderHelper = orderHelper;
            _employeeHelper = employeeHelper;
            _shipperHelper = shipperHelper;
            _customerHelper = customerHelper;
        }


        // GET: OrderController
        public ActionResult Index()
        {
            List<OrderViewModel> lista = _orderHelper.GetAll();
            return View(lista);
        }

        // GET: OrderController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrderController/Create
        public ActionResult Create()
        {

            OrderViewModel order = new OrderViewModel();
            order.Shippers = _shipperHelper.GetShippers();
            order.Customers = _customerHelper.GetAll();
            order.Employees = _employeeHelper.GetAll();
            return View(order);
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderViewModel order)
        {
            try
            {
                _orderHelper.AddOrder(order);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderController/Edit/5
        public ActionResult Edit(int id)
        {
            OrderViewModel order = _orderHelper.GetById(id);
            order.Shippers = _shipperHelper.GetShippers();
            order.Customers = _customerHelper.GetAll();
            order.Employees = _employeeHelper.GetAll();
            return View(order);
        }

        // POST: OrderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OrderViewModel order)
        {
            try
            {
                _orderHelper.UpdateOrder(order);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderController/Delete/5
        public ActionResult Delete(int id)
        {
            OrderViewModel order = _orderHelper.GetById(id);
            return View(order);
        }

        // POST: OrderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(OrderViewModel order)
        {
            try
            {
                _orderHelper.DeleteOrder(order.OrderId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
