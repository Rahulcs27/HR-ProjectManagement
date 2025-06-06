﻿using HR.Application.Contracts.Models;
using HR.Application.Contracts.Persistence;
using HR.Domain.Entities;
using HR.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using HR.Application.Exceptions;
using Microsoft.Extensions.Caching.Memory;
using HR.Persistence.Context;
using Microsoft.AspNetCore.Http;


namespace HR.Identity.Services
{
    public class LoginServices : ILoginService
    {
        readonly AppDbContext _context;
        readonly IEmailService _emailService;
        private readonly IMemoryCache _cache;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public LoginServices(AppDbContext context, IEmailService emailService, IMemoryCache cache, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _emailService = emailService;
            _cache = cache;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<LoginResponse> Login(LoginRequest loginRequest)
        {
            var user = await _context.Tbl_LoginMaster
                .FirstOrDefaultAsync(u => u.UserName == loginRequest.UserName);

            if (user == null)
            {
                throw new NotFoundException($"User with username {loginRequest.UserName} does not exist");
            }

            //  Role-based restriction: only HRs can log in
            if (!string.Equals(user.RoleName, "HR", StringComparison.OrdinalIgnoreCase))
            {
                throw new UnauthorizedAccessException("Only users with the 'HR' role are allowed to log in.");
            }

            var passwordCheck = await _context.Tbl_LoginMaster
                .FirstOrDefaultAsync(u => u.UserName == loginRequest.UserName && u.Password == loginRequest.Password);

            if (passwordCheck == null)
            {
                throw new UserNotFoundException("Invalid credentials, please try again!!");
            }

            var otp = GenerateRandomNumber();
            StoreOtp(user.UserName, otp);
            await SendOtpMail(user.Email, otp, user.UserName);

            var response = new LoginResponse
            {
                Email = user.Email,
                UserName = user.UserName,
                Otp = otp,
                OtpExpiryTime = DateTime.Now.AddMinutes(3)
                
            };

            return response;
        }


        public async Task SendOtpMail(string useremail, string otpText, string name)
        {
            var mailRequest = new MailRequest
            {
                Email = useremail,
                Subject = "Thanks for Verifying : OTP",
                EmailBody = GenerateEmailBody(name, otpText)
            };
            await _emailService.SendEmail(mailRequest);
        }

        private string GenerateEmailBody(string name, string otpText)
        {
            string emailBody = string.Empty;
            emailBody = "<div style='width:100%;background-color:yellow'>";
            emailBody += $"<h1>Hi {name}, Thanks for Signing Up</h1>";
            emailBody += "<h2>Please enter the OTP to complete login verification.</h2>";
            emailBody += $"<h2>OTP: {otpText}</h2>";
            emailBody += "</div>";
            return emailBody;
        }

        private string GenerateRandomNumber()
        {
            Random random = new Random();
            string randomNo = random.Next(1000, 9999).ToString("D4");
            return randomNo;
        }

        public void StoreOtp(string userName, string otp)
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(3));
            _cache.Set(userName, otp, cacheEntryOptions);
        }

        public string? GetOtp(string userName)
        {
            _cache.TryGetValue(userName, out string? otp);
            return otp;
        }

        public async Task<OtpResponse> VerifyOtp(OtpRequest otpRequest)
        {
            var user = await _context.Tbl_LoginMaster.FirstOrDefaultAsync(u => u.UserName == otpRequest.UserName);
            if (user == null)   
            {
                throw new NotFoundException($"User with Username {otpRequest.UserName} does not exist");
            }

            var cacheOtp = GetOtp(user.UserName);
            if (cacheOtp == null || cacheOtp != otpRequest.Otp)
            {
                throw new OtpNotFoundException("You have entered an incorrect or expired OTP.");
            }

            RemoveOtp(user.UserName);

            var response = new OtpResponse
            {
                UserName = user.UserName,
                Email = user.Email,
                OtpExpiryTime = DateTime.Now.AddMinutes(3)
            };

            return response;
        }

        public void RemoveOtp(string userName)
        {
            _cache.Remove(userName);
        }

        //   Send OTP for changing password
        public async Task<bool> SendChangePasswordOtp(string username)
        {
            var user = await _context.Tbl_LoginMaster.FirstOrDefaultAsync(u => u.UserName == username);
            if (user == null)
            {
                throw new UserNotFoundException("User not found");
            }

            var otp = GenerateRandomNumber();
            StoreOtp(user.UserName, otp);
            await SendOtpMail(user.Email, otp, user.UserName);

            return true;
        }

        //public async Task<bool> ChangePassword(ChangePassword changePasswordRequest)
        //{
        //    var user = await _context.Tbl_LoginMaster.FirstOrDefaultAsync(cp => cp.UserName == changePasswordRequest.UserName);
        //    if (user == null)
        //    {
        //        throw new UserNotFoundException("User with this username not found");
        //    }

        //    var otpRequest = new OtpRequest
        //    {
        //        UserName = changePasswordRequest.UserName,
        //        Otp = changePasswordRequest.Otp
        //    };

        //    var otpVerificationResult = await VerifyOtp(otpRequest);

        //    if (otpVerificationResult == null)
        //    {
        //        throw new OtpNotFoundException("Invalid or expired OTP.");
        //    }

        //    if (changePasswordRequest.NewPassword != changePasswordRequest.ConfirmNewPassword)
        //    {
        //        throw new Exception("New and Confirm Password must be the same");
        //    }


        //    var hasher = new PasswordHasher<Tbl_LoginMaster>();
        //    var hashedPassword = hasher.HashPassword(user, changePasswordRequest.NewPassword);

        //    user.Password = changePasswordRequest.NewPassword;
            
        //    _context.Tbl_LoginMaster.Update(user);
        //    await _context.SaveChangesAsync();

        //    RemoveOtp(user.UserName);

        //    return true;
        //}

        //public async Task<bool> UpdatePassword(UpdatePasswordRequest updatePasswordRequest)
        //{
        //    var user = await _context.Tbl_LoginMaster.FirstOrDefaultAsync(u => u.UserName == updatePasswordRequest.UserName);
        //    if (user==null)
        //    {
        //        throw new UserNotFoundException("user with this username is not exist");
        //    }

        //    if (updatePasswordRequest.NewPassword==updatePasswordRequest.OldPassword)
        //    {
        //        throw new Exception("New password Can't be as same as older one ");
        //    }

        //    if (updatePasswordRequest.OldPassword!=user.Password)
        //    {
        //        throw new Exception("Entered Password should be as nsame as existing Password");
        //    }

        //    if (updatePasswordRequest.NewPassword!=updatePasswordRequest.ConfirmPassword)
        //    {
        //        throw new PasswordNotMatchException("“Old password types are wrong");
        //    }
        //    user.Password=updatePasswordRequest.NewPassword;
        //    _context.Tbl_LoginMaster.Update(user);
        //    await _context.SaveChangesAsync();

        //    return true;
        //}
    }
}
