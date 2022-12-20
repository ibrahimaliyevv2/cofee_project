using System.ComponentModel.DataAnnotations;

namespace CofeeProject.Models
{
    public class Subscriber
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Email { get; set; }
    }
}
