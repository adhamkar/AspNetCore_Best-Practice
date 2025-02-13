using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.Products
{
    public class CreateProductDTO
    {
        public string Name { get; set; }=string.Empty;
        public string Description { get; set; }=string.Empty;
        public decimal Price { get; set; }
        public int QuantityStock { get; set; }
        public int? CategoryId { get; set; }
    }
}