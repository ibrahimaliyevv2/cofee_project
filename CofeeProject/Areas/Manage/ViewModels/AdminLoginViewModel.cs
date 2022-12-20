using System.ComponentModel.DataAnnotations;

namespace CofeeProject.Areas.Manage.ViewModels
{
    public class AdminLoginViewModel
    {
        [Required]
        [MinLength(4)]
        [MaxLength(25)]
        public string UserName { get; set; }
        [Required]
        [MinLength(4)]
        [MaxLength(25)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
