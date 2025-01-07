using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Models.Email
{
    public class EmailRequestDto
    {
        [Required]
        [EmailAddress]
        public string ToEmail { get; set;  }
        [Required]
        public string Subject { get; set; }
        public string Body { get; set; }

        public List<IFormFile> Attachments { get; set; }
    }
}