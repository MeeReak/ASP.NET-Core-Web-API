using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto.Comment;
using api.dtos.comment;
using api.models;

namespace api.mappers
{
    public static class CommentMapper
    {
        public static CommentDto ToCommentDto(this Comment CommentModel)
        {
            return new CommentDto
            {
                Id = CommentModel.Id,
                Content = CommentModel.Content,
                StockId = CommentModel.StockId,
                Title = CommentModel.Title
            };
        }

        public static Comment ToCommentFromCreate(this CreateCommentDto commentDto, int id)
        {
            return new Comment
            {
                StockId = id,
                Content = commentDto.Content,
                Title = commentDto.Title
            };
        }

    }
}