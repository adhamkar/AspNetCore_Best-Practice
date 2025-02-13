using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.Products
{
    public class UpdateProductRequestDTO
    {
         public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public int? QuantityStock { get; set; }
        public int? CategoryId { get; set; }
    }
}