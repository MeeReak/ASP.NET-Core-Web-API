using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.dtos.stock
{
    public class CreateStockDto
    {
        [Required(ErrorMessage = "Symbol is required")]
        [MaxLength(10, ErrorMessage = "Symbol can't be longer than 10 characters")]
        [MinLength(5, ErrorMessage = "Title must be longer than 5 characters")]

        public string Symbol { get; set; } = string.Empty;
        [Required(ErrorMessage = "Company Name is required")]
        [MaxLength(100, ErrorMessage = "Company Name can't be longer than 100 characters")]
        [MinLength(5, ErrorMessage = "Title must be longer than 5 characters")]

        public string CompanyName { get; set; } = string.Empty;

        [Range(0, double.MaxValue, ErrorMessage = "Purchase price must be a positive number")]
        public decimal Purchase { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Last Dividend must be a positive number")]
        public decimal LastDiv { get; set; }

        [StringLength(50, ErrorMessage = "Industry can't be longer than 50 characters")]
        public string Industry { get; set; } = string.Empty;

        [Range(0, long.MaxValue, ErrorMessage = "Market Cap must be a positive number")]
        public long MarketCap { get; set; }
    }
}