namespace HR.Application.Features.Employee.Commands.CreateEmployeeMaster
{
    public class CreateEmployeeMasterDto
    {
        public string Profile { get; set; }
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int DesignationId { get; set; }

        public int BranchId { get; set; }

        public int DevisionId { get; set; }
        public int UserGroup { get; set; }
        public int EmployeeTypeId { get; set; }
        public bool LoginStatus { get; set; }
        public int CreatedBy { get; set; }

    }
}
