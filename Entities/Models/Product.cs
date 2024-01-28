using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public String? ProductName { get; set; } = String.Empty;
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        public String? Summary { get; set; } = String.Empty;
        public String? ImageUrl { get; set; }
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        public bool ShowCase { get; set; }
    }
}
