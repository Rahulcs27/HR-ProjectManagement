
namespace HR.Identity.Contracts.Models.Identity
{
    public class LoginRequest
    {
        //public string UserId { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        
        public string Password { get; set; } = string.Empty;
    }
}
