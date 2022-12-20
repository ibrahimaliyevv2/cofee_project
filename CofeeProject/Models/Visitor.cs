using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CofeeProject.Models
{
    public class Visitor
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength: 60)]
        public string Name { get; set; }
        [StringLength(maximumLength: 100)]
        public string Job { get; set; }
        public string Comment { get; set; }
        [StringLength(maximumLength: 100)]
        public string ImageUrl { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }
    }
}
