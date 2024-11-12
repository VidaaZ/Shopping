namespace OnlineShop.Repository.Order
{
    public interface IOrderRepository
    {
        Task<entities.Order> CreateOrderAsync(entities.Order order);
    }
}
