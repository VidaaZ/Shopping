﻿using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Models.Product
{
    public class UpdateProductRequestDto
    {
        [Required(ErrorMessage = "Id must be filled")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name must be filled")]
        public string Name { get; set; }

        public string Description { get; set; }

       
        public string Price { get; set; }

        [Required(ErrorMessage = "Stock Quantity must be filled")]
        public int? StockQuantity { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }

        [Required(ErrorMessage = "Please enter Category Id")]
        public int CategoryId { get; set; }
    }
}
