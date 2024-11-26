using FinShark.Api.Data;
using FinShark.Api.Interfaces;
using FinShark.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace FinShark.Api.Repos
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDBContext _context;
        public CommentRepository(ApplicationDBContext Context)
        {
            _context = Context;
        }

        public async Task<Comment> CreateAsync(Comment commentModel)
        {
            await _context.Comments.AddAsync(commentModel);
            await _context.SaveChangesAsync();
            return commentModel;
        }

        public async Task<Comment?> DeleteAsync(int id)
        {
            var comment = await _context.Comments.FirstOrDefaultAsync(c => c.Id == id);
            if (comment == null) { return null; }
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
            return comment;
        }

        public async Task<List<Comment>> GetAllAsync()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
            var result = await _context.Comments.FirstOrDefaultAsync(c => c.Id == id);
            if (result == null) { return null; }
            return result;
        }

        public async Task<Comment?> UpdateAsync(int id, Comment commentModel)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment == null) { return null; }

            comment.Title = commentModel.Title;
            comment.Content = commentModel.Content;

            await _context.SaveChangesAsync();
            return comment;

        }
    }
}
