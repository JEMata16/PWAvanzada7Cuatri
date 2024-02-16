using FrontEnd.ApiModels;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class OrderHelper : IOrderHelper
    {

        IServiceRepository _repository;

        public OrderHelper(IServiceRepository repository)
        {
            _repository = repository;
        }

        OrderViewModel Convertir(Order order)
        {
            return new OrderViewModel
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

        Order Convertir(OrderViewModel order)
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

        public OrderViewModel AddOrder(OrderViewModel order)
        {
            HttpResponseMessage responseMessage = _repository.PostResponse("api/order", order);
            if(responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
            }
            return new OrderViewModel { };
        }

        public void DeleteOrder(int id)
        {
            HttpResponseMessage responseMessage = _repository.DeleteResponse("api/order/"+id.ToString());
            if(responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
            }
        }

        public List<OrderViewModel> GetAll()
        {
            List<OrderViewModel> lista = new List<OrderViewModel>();
            List<Order> result = new List<Order>();
            HttpResponseMessage responseMessage = _repository.GetResponse("api/order");
            if( responseMessage != null )
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                result = JsonConvert.DeserializeObject<List<Order>>(content);
            }

            foreach(var item in result)
            {
                lista.Add(Convertir(item));
            }

            return lista;
        }

        public OrderViewModel GetById(int id)
        {
            OrderViewModel order = new OrderViewModel();
            Order resultado = new Order();
            HttpResponseMessage responseMessage = _repository.GetResponse("api/order/" + id.ToString());
            if(responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                resultado = JsonConvert.DeserializeObject<Order>(content);
            }
            order = Convertir(resultado);
            return order;
        }

        public OrderViewModel UpdateOrder(OrderViewModel order)
        {
            HttpResponseMessage responseMessage = _repository.PutResponse("api/order", order);
            if( responseMessage != null )
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
            }
            return order;
        }
    }
}
