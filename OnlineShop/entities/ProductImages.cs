namespace OnlineShop.entities
{
    public class ProductImages
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public byte[] ImageData { get; set; }
        public string ContentType { get; set; }
        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}
