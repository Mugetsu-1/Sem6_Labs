using Microsoft.AspNetCore.Identity;

namespace Lab10.Models
{
    // Custom user class created by extending IdentityUser.
    // UserName, Email, PasswordHash, etc. are inherited from IdentityUser.
    public class AppUser : IdentityUser
    {
        // Any additional application specific properties can be added here.
    }
}