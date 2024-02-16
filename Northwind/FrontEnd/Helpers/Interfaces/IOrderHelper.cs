using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface IOrderHelper
    {
        List<OrderViewModel> GetAll();
        OrderViewModel GetById(int id);
        OrderViewModel AddOrder(OrderViewModel order);
        OrderViewModel UpdateOrder(OrderViewModel order);

        void DeleteOrder(int id);

    }
}
