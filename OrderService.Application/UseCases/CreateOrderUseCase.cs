using OrderService.Application.Ports;
using OrderService.Domain.Entities;

namespace OrderService.Application.UseCases
{
    public class CreateOrderUseCase
    {
        private readonly IOrderRepository _repository;

        public CreateOrderUseCase(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> ExecuteAsync(decimal total)
        {
            var order = new Order(total);
            await _repository.AddAsync(order);
            return order.Id;
        }
    }
}
