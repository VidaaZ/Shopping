using OnlineShop.Data;

namespace OnlineShop.Repository.Order
{
    public class OrderRepository:IOrderRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public OrderRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async  Task<entities.Order> CreateOrderAsync(entities.Order order)
        {
            await _dbContext.Orders.AddAsync(order);
            _dbContext.SaveChanges();
            return order;

        }
    }
}
