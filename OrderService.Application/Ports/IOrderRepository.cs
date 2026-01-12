using OrderService.Domain.Entities;

namespace OrderService.Application.Ports
{
    public interface IOrderRepository
    {
        Task AddAsync(Order order);
        Task<Order?> GetByIdAsync(Guid id);
    }
}
