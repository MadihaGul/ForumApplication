using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ForumApplication.API.Entities
{
    public class Post
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [MaxLength(1000)]
        public string? Detail { get; set; }

        [Required]
        public DateTime CreatedTime { get; set; }
        public DateTime? UpdatedTime { get; set; }

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();

        public Post(string title)
        {
            Title = title;
        }
    }
}
