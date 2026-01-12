namespace OrderService.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; private set; }
        public decimal Total { get; private set; }

        private Order() { } // requerido por EF (infra)

        public Order(decimal total)
        {
            if (total <= 0)
                throw new ArgumentException("El total debe ser mayor a cero");

            Id = Guid.NewGuid();
            Total = total;
        }
    }
}
