namespace ForumApplication.API.Models
{
    public class PostWithoutCommentsDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Detail { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime? UpdatedTime { get; set; }
    }
}
