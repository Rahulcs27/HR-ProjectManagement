﻿

using System.ComponentModel.DataAnnotations;

namespace HR.Domain.Entities
{
    public class Tbl_LoginMaster
    {
        public int fk_EmpId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Key]
        public int pk_LoginId { get; set; }
        public string Email {  get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool FirstLogin { get; set; }

        public string  RoleName { get; set; }
        //public int? Otp {  get; set; }
        //public DateTime? OtpExpiryTime { get; set; }





    }
}
