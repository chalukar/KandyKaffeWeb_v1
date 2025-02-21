using Microsoft.AspNetCore.Identity;

namespace KandyKaffe.Services.AuthAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
