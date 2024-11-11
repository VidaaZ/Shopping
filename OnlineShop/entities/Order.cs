namespace OnlineShop.entities
{
    public class Order
    {
        public int  OrderId { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string PostalCode { get; set; }
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        
    }
}
