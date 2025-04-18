
using Microsoft.AspNetCore.Identity;

namespace HR.Identity.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string? Otp { get; set; } = string.Empty;
        public DateTime? OtpExpiryTime { get; set; }
    }
}

