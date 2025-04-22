using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Application.Features.GMC.Commands.AddEmpDetails
{
    public class AddEmpDetailsCommandDto
    {
        public string EmployeeName { get; set; }
        public string Address { get; set; }
        public string MobileNumber { get; set; }
        public DateTime JoinDate { get; set; }
        public string PersonalEmail { get; set; }
        public string EmergencyContact { get; set; }
        public string EmployeeCode { get; set; }
        public string Designation { get; set; }
        public string Gender { get; set; }
        public string PanCard { get; set; }
        public DateTime BirthDate { get; set; }
        public int Age { get; set; }
        public string AadharCardNo { get; set; }
    }
}
