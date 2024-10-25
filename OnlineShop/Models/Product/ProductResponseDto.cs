namespace OnlineShop.Models.Product
{
    public class ProductResponseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public int StockQuantity { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public int CategoryId { get; set; }
    }
}
