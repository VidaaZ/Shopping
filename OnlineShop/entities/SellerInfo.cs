using System.ComponentModel.DataAnnotations;

namespace OnlineShop.entities
{
    public class SellerInfo
    {
        public Guid Id { get; set; }

        public byte[] Photo { get; set; }

        public User User { get; set; }
         
        public Guid UserId { get; set; }

    }
}
