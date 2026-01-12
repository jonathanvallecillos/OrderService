using Microsoft.EntityFrameworkCore;
using OrderService.Application.Ports;
using OrderService.Domain.Entities;

namespace OrderService.Infrastructure.Persistence
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderDbContext _context;

        public OrderRepository(OrderDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
        }

        public Task<Order?> GetByIdAsync(Guid id)
        {
            return _context.Orders.AsNoTracking().FirstOrDefaultAsync(o => o.Id == id);
        }
    }
}
