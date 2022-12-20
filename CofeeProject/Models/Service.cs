using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CofeeProject.Models
{
    public class Service
    {
        public int Id { get; set; }
        [StringLength(maximumLength: 100)]
        public string ImageUrl { get; set; }
        [StringLength(maximumLength: 100)]
        public string IconUrl { get; set; }
        [Required]
        [StringLength(maximumLength: 100)]
        public string Title { get; set; }
        public string Description { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }

    }
}
