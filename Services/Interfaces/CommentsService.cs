using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Entities;

namespace api.Services.Interfaces
{
    public interface CommentsService
    {
        Task<List<Comments>> GetAllCommentsAsync();
        Task<Comments> CreateCommentAsync(Comments comment);
        Task<Comments> GetCommentByIdAsync(int id);
        int Predicte(string comment);
    }
}