using BackEnd.Models;

namespace BackEnd.Services.Interfaces
{
    public interface IOrderService
    {
        Task<List<OrderModel>> GetOrders();
        Task<bool> Add(OrderModel order);
        Task<bool> Delete(int id);
        Task<bool> Update(OrderModel order);
        Task<OrderModel> GetById(int id);
    }
}
