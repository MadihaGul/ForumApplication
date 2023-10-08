using System.ComponentModel.DataAnnotations;

namespace ForumApplication.API.Models
{
    public class UpdateCommentDto
    {
        [Required(ErrorMessage = "Providing a comment text is required")]
        [MaxLength(500, ErrorMessage = "Length of a comment must not exceed 500 characters")]
        public string Text { get; set; } = string.Empty;
    }
}
