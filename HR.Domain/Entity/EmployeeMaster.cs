using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR.Domain.Entity
{
    [Table("Tbl_EmployeeMaster")]
    public class EmployeeMaster
    {
        [Key]
        public int EmployeeId { get; set; }
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
        //public string Profile { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeCode { get; set; }
        //public string Designation { get; set; }

        //public string Branch { get; set; }

        //public string Division { get; set; }
        //public string UserGroup { get; set; }
        public bool LoginStatus { get; set; }
        public int CreatedBy { get; set; }
        public int Fk_DivisionId { get; set; }
        public int Fk_BranchId { get; set; }
        public int Fk_DesignationId { get; set; }
        public int Fk_EmployeeTypeId { get; set; }
        public int FK_UserGroupId { get; set; }
    }
}
