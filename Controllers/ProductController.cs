using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.Products;
using api.Entities;
using api.Helpers;
using api.Mappers;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
        [Route("/api/products")]
        [ApiController]
        [EnableCors("AllowAllOrigins")] 
        public class ProductController: ControllerBase
        {
            private readonly ApplicationDBContext _context;
            private readonly ProductsService _productsService;
            public ProductController(ApplicationDBContext context,ProductsService productsService)
            {
                _context=context;
                _productsService=productsService;
            }

       /*      [HttpGet]
            public async Task<IActionResult> GetAll(){

                var products=await _productsService.GetProductsAsync();
                var productDTO= products.Select(s=>s.ToProductDtos());
                return Ok(productDTO);
            } */
            [HttpGet]
            public async Task<IActionResult> GetAllProducts([FromQuery] ProductQueryObject productQueryObject){

                var products=await _productsService.GetProductsAsync(productQueryObject);
                var productDTO= products.Select(s=>s.ToProductDtos());
                return Ok(productDTO);
            }
            [HttpGet("{id:int}")]
            public async Task<IActionResult> GetById([FromRoute] int id){
                var product=await _productsService.GetProductByIdAsync(id);
                if(product !=null)  return Ok(product.ToProductDtos());
                return NotFound();
            }
            [HttpPost]
            public async Task<IActionResult> CreateProduct([FromBody]CreateProductDTO productDTO){
                if(!ModelState.IsValid) return BadRequest(ModelState);
                var product=productDTO.ToProduct();
                await _productsService.CreateProductAsync(product);
                return CreatedAtAction(nameof(GetById),new {id=product.Id},product.ToProductDtos());
            }
            [HttpDelete("{id:int}")]
            public async void DeleteProduct([FromRoute] int id){
                var product=await _context.Products.FindAsync(id);
                if(product!=null){
                    _context.Products.Remove(product);
                    await _context.SaveChangesAsync();
                }               
            }
            
            [HttpPatch]
            [Route("{id:int}")]
            public async Task<IActionResult> UpodateProduct([FromRoute] int id,[FromBody] UpdateProductRequestDTO productRequestDTO){
                if(!ModelState.IsValid) return BadRequest(ModelState);
                var product=await _productsService.UpdateProductAsync(id,productRequestDTO);
                if(product==null) return NotFound();
                return Ok(product.ToProductDtos());
            }
        }
}