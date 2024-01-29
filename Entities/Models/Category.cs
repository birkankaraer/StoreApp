using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Required is category name.")]
        public String? CategoryName { get; set; } = String.Empty;
        //public ICollection<Product> Products { get; set; }
    }
}
