using ForumApplication.API.Entities;

namespace ForumApplication.API.Services
{
    public interface IForumApplicationRepository
    {
        Task<IEnumerable<Post>> GetPostsAsync();
        Task<Post?> GetPostAsync(int postId);

        Task<IEnumerable<Comment>> GetCommentsAsync(int postId);
        Task<Comment?> GetCommentAsync(int postId, int commentId);
        Task<bool> PostExistsAsync(int postId);
        
        Task<bool> SaveChangesAsync();
        Task AddCommmentforPostAsync(int postId, Comment comment);
        Task AddPostAsync( Post post);
        void DeletePost(Post post);

    }
}
