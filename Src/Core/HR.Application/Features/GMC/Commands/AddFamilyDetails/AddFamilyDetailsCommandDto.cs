using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Application.Features.GMC.Commands.AddFamilyDetails
{
    public class AddFamilyDetailsCommandDto
    {
        public int Fk_FamilyMemberTypeId { get; set; }
        public int Fk_Id { get; set; }
        public string FamilyMemberName { get; set; }
        public DateTime BirthDate { get; set; }
        public int Age { get; set; }
        public string RelationWithEmployee { get; set; }
        public int CreatedBy { get; set; }
        public bool FamilyStatus { get; set; }
        public DateTime CreatedDate { get; set; }
    
    }
}

