using System.ComponentModel.DataAnnotations;

namespace HR.Domain.Entities
{
    public class BranchMaster
    {
        [Key]
        public int BranchId { get; set; }  // Ensure a primary key is present
        public string BranchName { get; set; }

    }
}