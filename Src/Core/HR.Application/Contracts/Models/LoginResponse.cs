﻿using HR.Application.Features.Employee.Queries.GetEmployeeProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Application.Contracts.Models
{
    public class LoginResponse
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Otp { get; set; }
     
        public DateTime OtpExpiryTime { get; set; }
     
    }
}
 