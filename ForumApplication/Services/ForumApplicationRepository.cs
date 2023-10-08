using ForumApplication.API.DbContexts;
using ForumApplication.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace ForumApplication.API.Services
{
    public class ForumApplicationRepository : IForumApplicationRepository
    {
        private readonly ForumApplicationContext _context;

        public ForumApplicationRepository(ForumApplicationContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<Comment?> GetCommentAsync(int postId, int commentId)
        {
            return await _context.Comments
                .Where(c => c.PostId == postId && c.Id == commentId).FirstOrDefaultAsync();
        }
        public async Task<bool> PostExistsAsync(int postId)
        {
            return await _context.Posts.AnyAsync(c => c.Id == postId); // returns true if id is found else false
        }
        public async Task<IEnumerable<Comment>> GetCommentsAsync(int postId)
        {
            return await _context.Comments.OrderByDescending(c => c.CreatedTime)
                .Where(c => c.PostId == postId).ToListAsync();
        }

        public async Task<Post?> GetPostAsync(int postId)
        {
            return await _context.Posts.Include(p => p.Comments)
                .Where(p => p.Id == postId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Post>> GetPostsAsync()
        {
            return await _context.Posts.OrderByDescending(p => p.CreatedTime).ToListAsync();
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0); // returns the amount of entities changed
        }

        public async Task AddPostAsync(Post post)
        { 
            await _context.Posts.AddAsync(post);
        }
        public async Task AddCommmentforPostAsync(int postId, Comment comment)
        {
            var post = await GetPostAsync(postId);
            if (post != null)
            {
                post.Comments.Add(comment);
            }
        }


        public void DeletePost(Post post)
        {
            _context.Posts.Remove(post);
        }
    }
}
