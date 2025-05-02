using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Domain.Entities
{
    
        public class EmployeeMaster
        {
            public int EmployeeId { get; set; }
            public string EmployeeName { get; set; }
            public int? Fk_BranchId { get; set; }
            public string Address { get; set; }
            public string Mobile { get; set; }
            public string SkypeId { get; set; }
            public string CcEmail { get; set; }
            public int Fk_HeadDesignationId { get; set; }
            public DateTime? JoinDate { get; set; }
            public TimeSpan? DutyHour { get; set; }
            public bool LeftCompany { get; set; }
            public DateTime? LeftDate { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
            public string AadharNumber { get; set; }
            public string EmployeeCode { get; set; }
            public int Fk_DesignationId { get; set; }
            public int Fk_DivisionId { get; set; }
            public int Fk_LocationId { get; set; }
            public int? PinCode { get; set; }
            public string Email { get; set; }
            public string BccEmail { get; set; }
            public string PANNumber { get; set; }
            public int Fk_GenderId { get; set; }
            public DateTime? BirthDate { get; set; }
            public int Fk_ShiftId { get; set; }
            public byte[] Photo { get; set; }
            public byte[] Signature { get; set; }
            public int Fk_EmployeeTypeId { get; set; }
        public int Fk_UserGroupId { get; set; }
        public bool LoginStatus { get; set; } = true;  // Default to Active
        public string SignaturePath { get; set; }
            public int? CreatedBy { get; set; }
            public DateTime CreatedDate { get; set; }
            public DateTime? UpdatedDate { get; set; }
            public int? UpdatedBy { get; set; }

           
        }
    }



