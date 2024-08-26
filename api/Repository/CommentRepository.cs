using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.data;
using api.Dto.Comment;
using api.Interface;
using api.models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDBContext _context;

        public CommentRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Comment> Create(Comment CreateComment)
        {
            await _context.Comments.AddAsync(CreateComment);
            await _context.SaveChangesAsync();
            return CreateComment;
        }

        public async Task<Comment?> Delete(int id)
        {
            var comment = await _context.Comments.FindAsync(id);

            if (comment == null)
            {
                return null;
            }

            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();

            return comment;
        }

        public async Task<List<Comment>> GetAll()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<Comment?> GetById(int id)
        {
            return await _context.Comments.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Comment?> Update(int id, UpdateCommentDto UpdateDto)
        {
            var comment = await _context.Comments.FindAsync(id);

            if (comment == null)
            {
                return null;
            }

            comment.Content = UpdateDto.Content;
            comment.CreateAt = DateTime.Now;
            comment.Title = UpdateDto.Title;

            await _context.SaveChangesAsync();

            return comment;
        }
    }
}