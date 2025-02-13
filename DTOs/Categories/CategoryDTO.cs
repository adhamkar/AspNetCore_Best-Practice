using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Entities.DTOs.Categories
{
    public class CategoryDTO
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }=string.Empty;
    }
}