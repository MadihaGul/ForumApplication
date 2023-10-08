namespace ForumApplication.API.Models
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Detail { get; set; }
        public DateTime CreatedTime { get; set; } 
        public DateTime? UpdatedTime { get; set; }

        public int NumberOfComment { get { return Comments.Count; } }

        public ICollection<CommentDto> Comments { get; set; } = new List<CommentDto>();


    }
}
