using System.ComponentModel.DataAnnotations;

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
    }
}
