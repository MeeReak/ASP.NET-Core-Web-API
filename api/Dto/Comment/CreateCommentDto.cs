using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dto.Comment
{
    public class CreateCommentDto
    {
        [Required(ErrorMessage = "Title is required")]
        [MaxLength(100, ErrorMessage = "Title can't be longer than 100 characters")]
        [MinLength(5, ErrorMessage = "Title must be longer than 5 characters")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Content is required")]
        [MaxLength(1000, ErrorMessage = "Content can't be longer than 1000 characters")]
        [MinLength(5, ErrorMessage = "Title must be longer than 5 characters")]

        public string Content { get; set; } = string.Empty;

        [Required(ErrorMessage = "StockId is required")]
        public int StockId { get; set; }
    }
}