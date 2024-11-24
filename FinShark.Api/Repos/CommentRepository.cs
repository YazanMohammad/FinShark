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

        public Task<Comment> CreateAsync(Comment commentModel)
        {
            throw new NotImplementedException();
        }

        public Task<Comment?> DeleteAsync(int id)
        {
            throw new NotImplementedException();
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

        public Task<Comment?> UpdateAsync(int id, Comment commentModel)
        {
            throw new NotImplementedException();
        }
    }
}
