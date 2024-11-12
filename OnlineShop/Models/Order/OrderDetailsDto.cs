namespace OnlineShop.Models.Order
{
    public class OrderDetailsDto
    {
        public int ProductId { get; set; }           
        public int Count { get; set; }             
        public int UserId { get; set; }           
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }      
        public string PostalCode { get; set; }       
        public string Name { get; set; }            
        public string Family { get; set; }
    }
}
