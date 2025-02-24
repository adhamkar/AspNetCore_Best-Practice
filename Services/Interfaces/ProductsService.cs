using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Products;
using api.Entities;
using api.Helpers;

namespace api.Services.Interfaces
{
    public interface ProductsService
    {
        Task<List<Products>> GetProductsAsync(ProductQueryObject queryObj);
        Task<Products?> GetProductByIdAsync(int id);
        Task<Products> CreateProductAsync(Products product);
        Task<Products?> UpdateProductAsync(int id, UpdateProductRequestDTO product);
        Task DeleteProductAsync(int id);
        Task<bool> ProductExists(int id);

    }
}