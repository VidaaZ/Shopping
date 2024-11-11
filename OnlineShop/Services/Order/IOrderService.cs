namespace OnlineShop.Services.Order
{
    public interface IOrderService
        
    {
        Task Order(int ptoductId, int count);
    }
}
