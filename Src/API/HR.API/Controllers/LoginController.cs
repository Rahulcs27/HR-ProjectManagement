﻿using HR.Application.Contracts.Models;
using HR.Application.Contracts.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace HR.API.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        readonly ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;   
        }


        //login first
        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>>Login(LoginRequest loginRequest)
        {
            var response=await _loginService.Login(loginRequest);
            return Ok(response);
        }

        //verfying otp got on mail
        [HttpPost("otpVerify")]
        public async Task<ActionResult<OtpResponse>>VerifyOtp(OtpRequest otpRequest)
        {
            var response = await _loginService.VerifyOtp(otpRequest);
            return Ok(response);
        }


        //again sending otp for changing the password
        [HttpPost("send-otp")]
        public async Task<IActionResult> SendOtpToEmail(string username)
        {
            try
            {
                await _loginService.SendChangePasswordOtp(username);

                return Ok(new { message = "OTP has been sent to your email address." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

       // verifying the otp and chnaging the password if the otp is correct

        //[HttpPost("verify-otp")]
        //public async Task<IActionResult> VerifyOtpAndChangePassword( ChangePassword changePasswordRequest)
        //{
        //    try
        //    {
                
        //        bool isPasswordChanged = await _loginService.ChangePassword(changePasswordRequest);

        //        if (isPasswordChanged)
        //        {
        //            return Ok(new { message = "Password changed successfully!!!" });
        //        }
        //        else
        //        {
        //            return BadRequest(new { message = "OTP verification failed." });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new { message = ex.Message });
        //    }
        //}


        ////update password
        //[HttpPost("update_password")]
        //public async Task<IActionResult> UpdatePasswrd(UpdatePasswordRequest updatePasswordRequest)
        //{
        //    var result = await _loginService.UpdatePassword(updatePasswordRequest);
        //    if (!result)
        //    {
        //        return BadRequest("Password update failed. Check your input and try again.");                
        //    }
        //    return Ok("Password Updated Successfully");
        //}
    }
}


