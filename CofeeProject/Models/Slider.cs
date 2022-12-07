using System.ComponentModel.DataAnnotations;

namespace CofeeProject.Models
{
    public class Slider
    {
        public int Id { get; set; }
        [StringLength(maximumLength: 300)]
        public string Description { get; set; }
        [Required]
        [StringLength(maximumLength: 70)]
        public string Title { get; set; }
        [StringLength(maximumLength: 20)]
        public string Subtitle { get; set; }
        [StringLength(maximumLength: 100)]
        public string ImageUrl { get; set; }
    }
}
