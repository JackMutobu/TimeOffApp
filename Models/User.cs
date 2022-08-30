using Microsoft.AspNetCore.Identity;

namespace TimeOffApp.Models
{
    public class User:IdentityUser
    {
        public string Firstname { get; set; } = null!;

        public string Lastname { get; set; } = null!;
    }
}
