using System.ComponentModel.DataAnnotations;

namespace OnlineShop.entities
{
    public class Brand
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        public string LogoUrl { get; set; }

        public string Website { get; set; }

        public string CountryOfOrigin { get; set; }

        public int EstablishedYear { get; set; }

        public bool IsActive { get; set; }

        public ICollection<Product> Products { get; set; }
       
    }

}
