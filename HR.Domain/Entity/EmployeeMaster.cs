namespace HR.Domain.Entity
{
    public class EmployeeMaster
    {
        public int id { get; set; }
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
        public string Profile { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Designation { get; set; }

        public string Branch { get; set; }

        public string Devision { get; set; }
        public string UserGroup { get; set; }
        public bool LoginStatus { get; set; }
        public int CreatedBy { get; set; }
        public int DevisionId { get; set; }
        public int BranchId { get; set; }
        public int DesignationId { get; set; }
        public object EmployeeTypeId { get; set; }
    }
}
