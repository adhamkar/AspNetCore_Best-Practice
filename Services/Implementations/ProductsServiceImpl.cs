using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.Products;
using api.Entities;
using api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Services.Implementations
{
    public class ProductsServiceImpl : ProductsService
    {
        private readonly ApplicationDBContext _context;
        public ProductsServiceImpl(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Products> CreateProductAsync(Products product)
        {
           await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();
                return product;
        }

        public async Task DeleteProductAsync(int id)
        {
            var product=await _context.Products.FindAsync(id);
            if(product!=null){
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Products?> GetProductByIdAsync(int id)
        {
            var product=await _context.Products.FirstOrDefaultAsync(i=>i.Id==id);
            if(product.Comments.Count==0 || product.Comments==null) return product;
            return await _context.Products.Include(c=>c.Comments).FirstOrDefaultAsync(i=>i.Id==id);
        }

        public Task<List<Products>> GetProductsAsync()
        {
            
            return _context.Products.Include(c=>c.Comments).ToListAsync();
        }

        public Task<bool> ProductExists(int id)
        {
            return _context.Products.AnyAsync(x=>x.Id==id);
        }

        public async Task<Products> UpdateProductAsync(int id, UpdateProductRequestDTO productToUpdate)
        {
           var product=await _context.Products.FirstOrDefaultAsync(x=>x.Id==id);
            if(product==null) return null;
            if(productToUpdate.Name!=null) product.Name=productToUpdate.Name;
            if(productToUpdate.Description!=null) product.Description=productToUpdate.Description;
            if(productToUpdate.Price.HasValue && productToUpdate.Price.Value != 0) product.Price=productToUpdate.Price.Value;
            if(productToUpdate.QuantityStock.HasValue && productToUpdate.QuantityStock.Value!=0) product.QuantityStock=productToUpdate.QuantityStock.Value;
            if(productToUpdate.CategoryId.HasValue) product.CategoryId=productToUpdate.CategoryId.Value;

            await _context.SaveChangesAsync();
            return product;
            
        }
    }
}