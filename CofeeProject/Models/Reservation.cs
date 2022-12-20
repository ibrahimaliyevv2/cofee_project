using System;
using System.ComponentModel.DataAnnotations;

namespace CofeeProject.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public DateTime Time { get; set; }
    }
}
