using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }=string.Empty;
        public List<Products> Products {get;set;}=new List<Products>();
    }
}