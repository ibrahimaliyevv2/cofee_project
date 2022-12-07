using System.ComponentModel.DataAnnotations;

namespace CofeeProject.Models
{
    public class Contact
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength:250)]
        public string LocationAdress { get; set; }
        [StringLength(maximumLength: 100)]
        public string PhoneNumber { get; set; }
        [StringLength(maximumLength: 150)]
        public string EmailAdress { get; set; }
    }
}
