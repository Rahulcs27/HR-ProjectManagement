using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.Application.Contracts.Models;

namespace HR.Application.Contracts.Persistence
{
    public interface ILoginService
    {
        Task<LoginResponse> Login(LoginRequest loginRequest);
        Task<OtpResponse> VerifyOtp(OtpRequest otpRequest);
        public void StoreOtp(string UserName, string otp);
        Task<bool> SendChangePasswordOtp(string username);
    }
}
