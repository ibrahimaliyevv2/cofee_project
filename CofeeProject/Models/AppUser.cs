using Microsoft.AspNetCore.Identity;

namespace CofeeProject.Models
{
    public class AppUser:IdentityUser
    {
        public string FullName { get; set; }
    }
}
