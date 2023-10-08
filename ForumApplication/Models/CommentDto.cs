namespace ForumApplication.API.Models
{
    public class CommentDto
    {
        public int Id { get; set; }

        public int PostId { get; set; }
        public string Text { get; set; } = string.Empty;
        public DateTime CreatedTime { get; set; }
        public DateTime? UpdatedTime { get; set; }
    }
}
