using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Products;
using api.Entities;
using api.Entities.DTOs.Products;

namespace api.Mappers
{
    public static class ProductMapper
    {
        public static ProductsDTO ToProductDtos(this Products product){
            return new ProductsDTO{
                Id=product.Id,
                Name=product.Name,
                Description=product.Description,
                Price=product.Price,
                QuantityStock=product.QuantityStock,
                CategoryId=product.CategoryId,
                Category=product.Category,
                Comments = product.Comments.Select(c => c.ToCommentsDTO()).ToList(),                
            };
        }
        public static Products ToProduct(this CreateProductDTO createProductDTO){
            return new Products{
                Name=createProductDTO.Name,
                Description=createProductDTO.Description,
                Price=createProductDTO.Price,
                QuantityStock=createProductDTO.QuantityStock,
                CategoryId=createProductDTO.CategoryId
        };}
    }
}