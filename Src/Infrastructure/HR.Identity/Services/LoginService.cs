
using System.Security.Cryptography;
using HR.Identity.Contracts.Models.Identity;
using HR.Identity.Contracts.Models.Persistence.Identity;
using HR.Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace HR.Identity.Services
{
    public class LoginService : ILoginService
    {
        readonly SignInManager<ApplicationUser> _signInManager;
        readonly UserManager<ApplicationUser> _userManager;
        readonly hrIdentityDbContext _idbcontext;
        public LoginService(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, hrIdentityDbContext idbcontext)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _idbcontext = idbcontext;
        }
        public async Task<LoginResponse> Login(LoginRequest loginRequest)
        {
            var userexists = await _userManager.FindByIdAsync(loginRequest.UserName);
            //FindByEmailAsync(loginRequest.UserName)
            if (userexists == null)
            {
                throw new Exception($"User with {loginRequest.UserName} not found");
            }
            var checkPswd = await _signInManager.CheckPasswordSignInAsync(userexists, loginRequest.Password, false);
            if(checkPswd.Succeeded)
            {
                var generateOtp = await GenerateOTP();
                var response = new LoginResponse()
                {
                    Id = userexists.Id,
                    Email = userexists.Email,
                    UserName = userexists.UserName,
                    Otp = generateOtp,
                    OtpExpiryTime = DateTime.Now.AddMinutes(3)
                };
                userexists.Otp = generateOtp;
                userexists.OtpExpiryTime = DateTime.Now.AddMinutes(3);
                await _userManager.UpdateAsync(userexists);
                //_idbcontext.Users.Update(userexists);
                //await _userManager.SaveChanges
            }
            return null;
        }

        private async Task<string> GenerateOTP()
        {
            var randomBytes = new byte[4];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomBytes);
            return Convert.ToBase64String(randomBytes);
        }
    }
}
