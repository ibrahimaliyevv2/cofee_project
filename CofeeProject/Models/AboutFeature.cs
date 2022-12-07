using System.ComponentModel.DataAnnotations;

namespace CofeeProject.Models
{
    public class AboutFeature
    {
        public int Id { get; set; } 
        [Required]
        [StringLength(maximumLength: 25)]
        public string Title1 { get; set; }
        [Required]
        [StringLength(maximumLength: 25)]
        public string Title2 { get; set; }
        [Required]
        [StringLength(maximumLength: 25)]
        public string Title3 { get; set; }
        public string Description1 { get; set; }
        public string Description2 { get; set; }
        public string Description3 { get; set; }
        public string AddedText1 { get; set; }
        public string AddedText2 { get; set; }
        public string AddedText3 { get; set; }
        [StringLength(maximumLength: 100)]
        public string ImageUrl { get; set; }
    }
}
