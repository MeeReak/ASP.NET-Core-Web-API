using System;
using System.Collections.Generic;
using System.Linq;

namespace api.dtos.comment
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public int StockId { get; set; }
    }
}