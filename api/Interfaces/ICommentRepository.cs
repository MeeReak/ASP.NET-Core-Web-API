using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto.Comment;
using api.models;

namespace api.Interface
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAll();
        Task<Comment?> GetById(int id);
        Task<Comment> Create(Comment CreateComment);
        Task<Comment?> Update(int id, UpdateCommentDto UpdateDto);
        Task<Comment?> Delete(int id);
    }
}