using OrderService.Application.Ports;
using OrderService.Domain.Entities;

namespace OrderService.Application.UseCases
{
    public class GetOrderByIdUseCase
    {
        private readonly IOrderRepository _repository;

        public GetOrderByIdUseCase(IOrderRepository repository)
        {
            _repository = repository;
        }

        public Task<Order?> ExecuteAsync(Guid id)
        {
            return _repository.GetByIdAsync(id);
        }
    }
}
