using System.ComponentModel.DataAnnotations;

namespace ForumApplication.API.Entities
{
    public class Comment
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(500)]
        public string Text { get; set; } 
        [Required]
        public DateTime CreatedTime { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public Post? Post { get; set; }

        public int PostId { get; set; }
        public Comment(string text)
        {
            Text = text;
        }
    }
}
