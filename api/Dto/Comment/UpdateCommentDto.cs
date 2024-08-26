using System.ComponentModel.DataAnnotations;

namespace api.Dto.Comment
{
    public class UpdateCommentDto
    {
        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, ErrorMessage = "Title can't be longer than 100 characters")]
        [MinLength(5, ErrorMessage = "Title must be longer than 5 characters")]

        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Content is required")]
        [StringLength(1000, ErrorMessage = "Content can't be longer than 1000 characters")]
        [MinLength(5, ErrorMessage = "Title must be longer than 5 characters")]

        public string Content { get; set; } = string.Empty;

    }
}