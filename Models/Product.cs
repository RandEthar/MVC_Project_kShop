using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace kASHOP.Models
{
    public class Product
    {

        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(10)]
        public string Name { get; set; }
        public string? Image { get; set; }
        public string Description { get; set; }
        [ValidateNever]
        public Category Category { get; set; }
        [Range(0, 10000)]
        public double Price { get; set; }
        public double Rate { get; set; }
        [Display(Name= "Category")]
        public int CategoryId { get; set; }

    }
}
