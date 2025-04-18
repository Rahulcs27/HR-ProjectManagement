
namespace HR.Identity.Contracts.Models.Identity
{
    public class LoginResponse
    {
        public string Id { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string? Otp { get; set; } = string.Empty;
        public DateTime? OtpExpiryTime { get; set; }
    }
}
