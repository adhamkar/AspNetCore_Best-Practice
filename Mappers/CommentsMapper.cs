using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Comments;
using api.Entities;

namespace api.Mappers
{
    public static class CommentsMapper
    {
        public static CommentsDTO ToCommentsDTO(this Comments comment){
            return new CommentsDTO{
                Id=comment.Id,
                Title=comment.Title,
                CreatedOn=comment.CreatedOn,
                Content=comment.Content,
                ProductId=comment.ProductId,
                
            };
        }
        public static Comments ToCommentsFromCreate(this CreateCommentDTO createCommentsDTO,int ProductId){
            return new Comments{
                Title=createCommentsDTO.Title,
                Content=createCommentsDTO.Content,
                ProductId=ProductId
            };
        }

        public static Comments ToCommentsFromUpdate(this UpdateCommentDTO updateCommentsDTO,int ProductId){
            return new Comments{
                Title=updateCommentsDTO.Title,
                Content=updateCommentsDTO.Content,
                ProductId=ProductId
            };
        }
    }
}