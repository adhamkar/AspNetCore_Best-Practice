using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Helpers
{
    public class ProductQueryObject
    {
        public string? Name { get; set; }=null;
        public int? QuantityStock { get; set; }=null;
        public decimal? Price { get; set; }=null;
        public int PageNumber { get; set; }=1;
        public int PageSize { get; set; }=10;
        public string? Description { get; set; }=null;


    }
}