using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.Products
{
    public class UpdateProductRequestDTO
    {
        [MaxLength(5, ErrorMessage = "Name cannot be over 5 over characters")]
         public string? Name { get; set; }
        [MaxLength(5, ErrorMessage = "Description cannot be over 5 over characters")]
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public int? QuantityStock { get; set; }
        public int? CategoryId { get; set; }
    }
}