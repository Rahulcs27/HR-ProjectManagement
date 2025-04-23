using HR.Application.Contracts.Models;
using HR.Application.Contracts.Persistence;
using HR.Domain.Entity;
using HR.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using HR.Application.Exceptions;
using HR.Persistence.Helper;

namespace HR.Identity.Services
{
    public class LoginServices : ILoginService 
    {
        readonly AppDbContext _context;
        readonly IEmailService _emailService;
      
        public LoginServices(AppDbContext context, IEmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }

        public async Task<LoginResponse> Login(LoginRequest loginRequest)
        {
            var hasher = new PasswordHasher<Tbl_LoginMaster>();
          
            var user = await _context.Tbl_LoginMaster.FirstOrDefaultAsync(u => u.UserName == loginRequest.UserName);
            if (user == null) 
            {
                throw new NotFoundException($"user with email{loginRequest.UserName}is not exist");
            }
            
            //var password=hasher.VerifyHashedPassword(user,user.Password,loginRequest.Password);
            var password = await _context.Tbl_LoginMaster.FirstOrDefaultAsync(u => u.UserName == loginRequest.UserName && u.Password == loginRequest.Password);
            if (/*password!=PasswordVerificationResult.Success*/password == null)
            {
                throw new UserNotFoundException("Invalid credentials,please try again!!");

            }
            var otp = GenerateRandomNumber();

           
            TempOtpStore.Otps[user.Email] = otp;
 
            await SendOtpMail(user.Email, otp, user.UserName);
            var response = new LoginResponse
            {
                Email = user.Email,
                UserName=user.UserName
            };
            return response;

        }

      
        public async Task SendOtpMail(string useremail,string OtpText,string Name)
        {
            var mailRequest = new MailRequest();
            mailRequest.Email = useremail;
            mailRequest.Subject = "Thanks for Verifying : OTP";
            mailRequest.EmailBody=GenerateEmailBody(Name,OtpText);
            await this._emailService.SendEmail(mailRequest);
        }
        private string GenerateEmailBody(string name,string otpText)
        {
            string emailBody=string.Empty;
            emailBody = "<div style='width:100%;background-color:yellow'>";
            emailBody += "<h1>Hi " + name + ", Thanks for Signing Up</h1>";
            emailBody += "<h2>please Enter the OTP and Complete the Login Verification </h2>";
            emailBody += "<h2> OTP is :" + otpText + "</h2>";
            emailBody += "</div>";
            return emailBody;
        }
        private string GenerateRandomNumber()
        {
            Random random = new Random();
            string randomNo = random.Next(0, 1000).ToString("D4");
            return randomNo;
        }

    }
}
