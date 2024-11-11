using System.ComponentModel.DataAnnotations;

namespace OnlineShop.entities
{
    public class Role
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } // e.g., Admin, Customer, Seller
        
        public ICollection<User> Users { get; set; }
    }
}
