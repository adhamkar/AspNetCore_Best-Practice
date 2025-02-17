using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.Comments;
using api.Entities;
using api.Mappers;
using api.Services.Interfaces;
using api.TextClassification.Comment;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;


namespace api.Controllers
{
    [Route("/api/comments")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly ProductsService _productsService;
        private readonly CommentsService _commentsService;
        private readonly Prediction _prediction;


        public CommentController(ApplicationDBContext context, CommentsService commentsService, ProductsService productsService, Prediction prediction)
        {
            _context = context;
            _commentsService = commentsService;
            _productsService = productsService;
            _prediction = prediction;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllComments()
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            var comments =await _commentsService.GetAllCommentsAsync();
            var commentsDTO=comments.Select(s=>s.ToCommentsDTO());
            return Ok(commentsDTO);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCommentById([FromRoute] int id)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            var comment = await _commentsService.GetCommentByIdAsync(id);
            if (comment != null) return Ok(comment.ToCommentsDTO());
            return NotFound();
        }
        [HttpPost("{productId:int}")]
        public async Task<IActionResult> CreateComment([FromBody] CreateCommentDTO commentDTO,[FromRoute] int productId)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            if (!await _productsService.ProductExists(productId)) return BadRequest("Product does not exist");
            var comment=commentDTO.ToCommentsFromCreate(productId);
            await _commentsService.CreateCommentAsync(comment);
            return CreatedAtAction(nameof(GetCommentById), new { id = comment.Id }, comment.ToCommentsDTO());

        }
        [HttpGet("/predict/{commentId:int}")]
        public async Task<IActionResult> PredictComment([FromRoute] int commentId){
            Comments comment=await _commentsService.GetCommentByIdAsync(commentId);
            if (comment == null) return NotFound();

//            int result = _prediction.CommentPrediction(comment.Content);
            int result = _commentsService.Predicte(comment.Content);

            if (result==1) return Ok("Good");
            else return Ok("Bad");
        }
        [HttpGet("/predictionscore")]
        public async Task<IActionResult> CommentsScore(){
            var comments=await _commentsService.GetAllCommentsAsync();
            var positifScore=0;
            var negatifScore=0;

            foreach (var comment in comments)
            {
                int result = _commentsService.Predicte(comment.Content);
                if (result==1) positifScore++;
                else negatifScore++;
            }
            return Ok(new {positifScore,negatifScore});
            
        }
        
    }
}