using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Entities
{
    public class Products
    {
        public int Id { get; set; }
        public string Name { get; set; }=string.Empty;
        public string Description { get; set; }=string.Empty;
        [Column(TypeName="decimal(18,2)")]
        public decimal Price { get; set; }
        public int QuantityStock { get; set; }
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        public List<Comments> Comments { get; set; }=new List<Comments>();

    }
}