using System.ComponentModel.DataAnnotations;

namespace CofeeProject.Models
{
    public class Message
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        [Required]
        [MaxLength(150)]
        public string Body { get; set; }
    }
}
