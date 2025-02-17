using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Entities;
using api.Services.Interfaces;
using api.TextClassification.Comment;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace api.Services.Implementations
{
    public class CommentsServiceImpl : CommentsService
    {
                private readonly ApplicationDBContext _context;
                private readonly Prediction _prediction;
                public CommentsServiceImpl(ApplicationDBContext context, Prediction prediction)
                {
                    _context = context;
                    _prediction = prediction;
                    
                }

        public async Task<Comments> CreateCommentAsync(Comments comment)
        {
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
            return comment;
        }

        public async Task<List<Comments>> GetAllCommentsAsync()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<Comments?> GetCommentByIdAsync(int id)
        {
            return await _context.Comments.FirstOrDefaultAsync(i => i.Id == id);
        }

        public int Predicte(string comment)
        {
            int score= _prediction.CommentPrediction(comment);
            return score;
        }
    }
}