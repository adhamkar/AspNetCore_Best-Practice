using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.Comments;
using api.Entities;
using api.Mappers;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;


namespace api.Controllers
{
    [Route("/api/comments")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly ProductsService _productsService;
        private readonly CommentsService _commentsService;

        public CommentController(ApplicationDBContext context, CommentsService commentsService, ProductsService productsService)
        {
            _context = context;
            _commentsService = commentsService;
            _productsService = productsService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllComments()
        {
            var comments =await _commentsService.GetAllCommentsAsync();
            var commentsDTO=comments.Select(s=>s.ToCommentsDTO());
            return Ok(commentsDTO);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCommentById([FromRoute] int id)
        {
            var comment = await _commentsService.GetCommentByIdAsync(id);
            if (comment != null) return Ok(comment.ToCommentsDTO());
            return NotFound();
        }
        [HttpPost("{productId}")]
        public async Task<IActionResult> CreateComment([FromBody] CreateCommentDTO commentDTO,[FromRoute] int productId)
        {
            if (!await _productsService.ProductExists(productId)) return BadRequest("Product does not exist");
            var comment=commentDTO.ToCommentsFromCreate(productId);
            await _commentsService.CreateCommentAsync(comment);
            return CreatedAtAction(nameof(GetCommentById), new { id = comment.Id }, comment.ToCommentsDTO());

        }
    }
}