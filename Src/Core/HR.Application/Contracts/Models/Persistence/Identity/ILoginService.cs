
using HR.Identity.Contracts.Models.Identity;

namespace HR.Identity.Contracts.Models.Persistence.Identity
{
    public interface ILoginService
    {
        Task<LoginResponse> Login(LoginRequest loginRequest);
    }
}
