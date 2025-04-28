using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Application.Features.GMC.Commands.AddFamilyDetails
{
    public class AddFamilyDetailsCommand:IRequest<AddFamilyDetailsCommandDto>
    {
        public AddFamilyDetailsCommandDto FamilyMaster { get; set; }

    }
}
