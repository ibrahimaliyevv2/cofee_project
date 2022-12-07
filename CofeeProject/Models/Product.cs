using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace CofeeProject.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength:150)]
        public string Name { get; set; }
        [Required]
        [StringLength(maximumLength:200)]
        public string Description { get; set; }
        [Required]
        [StringLength(maximumLength:100)]
        public string ImageUrl { get; set; }
        public int Price { get; set; }
        public int CategoryId { get; set; }
        public ProductCategory Category { get; set; }
    }
}
