using System.ComponentModel.DataAnnotations;

namespace ForumApplication.API.Models
{
    public class UpdatePostDto
    {
        [Required(ErrorMessage = "Providing a title for a post is required")]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        [MaxLength(1000, ErrorMessage = "The length of a post must not exceed 1000 characters")]
        public string? Detail { get; set; }
    }
}
