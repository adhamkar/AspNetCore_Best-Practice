using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.Products
{
    public class CreateProductDTO
    {
        [Required]
        //[MaxLength(10, ErrorMessage = "Name cannot be over 5 over characters")]
        public string Name { get; set; }=string.Empty;
        [Required]
        //[MinLength(5, ErrorMessage = "Description cannot be under 5 over characters")]
        public string Description { get; set; }=string.Empty;
        [Required]
        [Range(1, 1000000000)]
        public decimal Price { get; set; }
        [Required]
        public int QuantityStock { get; set; }
        public int? CategoryId { get; set; }
    }
}