using BackEnd.Models;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class OrderService : IOrderService
    {

        public IUnidadDeTrabajo _unidadDeTrabajo;

        public OrderService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        OrderModel Convertir(Order order)
        {
            return new OrderModel
            {
                OrderId = order.OrderId,
                CustomerId = order.CustomerId,
                EmployeeId = order.EmployeeId,
                OrderDate = order.OrderDate,
                RequiredDate = order.RequiredDate,
                ShippedDate = order.ShippedDate,
                ShipVia = order.ShipVia,
            };
        }

        Order Convertir(OrderModel order)
        {
            return new Order
            {
                OrderId = order.OrderId,
                CustomerId = order.CustomerId,
                EmployeeId = order.EmployeeId,
                OrderDate = order.OrderDate,
                RequiredDate = order.RequiredDate,
                ShippedDate = order.ShippedDate,
                ShipVia = order.ShipVia,
            };
        }


        public Task<bool> Add(OrderModel order)
        {
            _unidadDeTrabajo._ordersDAL.Add(Convertir(order));
            var result = _unidadDeTrabajo.Complete();

            return Task.FromResult(result);
        }

        public Task<bool> Delete(int id)
        {
            Order order = new Order { OrderId = id };
            _unidadDeTrabajo._ordersDAL.Remove(order);
            var result = _unidadDeTrabajo.Complete();
            
            return Task.FromResult(result);
        }

        public Task<OrderModel> GetById(int id)
        {
            Order order = _unidadDeTrabajo._ordersDAL.Get(id);
            return Task.FromResult(Convertir(order));
        }

        public Task<List<OrderModel>> GetOrders()
        {
            var Orders = _unidadDeTrabajo._ordersDAL.GetAll();
            List<OrderModel> lista = new List<OrderModel>();
            foreach(var order in Orders)
            {
                lista.Add(Convertir(order));
            }

            return Task.FromResult(lista);
        }

        public Task<bool> Update(OrderModel order)
        {
            _unidadDeTrabajo._ordersDAL.Update(Convertir(order));
            var result = _unidadDeTrabajo.Complete();
            return Task.FromResult(result);
        }
    }
}
