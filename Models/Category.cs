using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kASHOP.Models
{
    public class Category
    {

        public int Id { get; set; }
        [Column("varchar(50)")]
        [Required]
        [MinLength(5)]
        public string Name { get; set; }

        //تجاهل هاي الخاصية تمامًا أثناء الـ Model Validation
        [ValidateNever]
        public List<Product> Products { get; set; }

    }
}
