using MediatR;

namespace HR.Application.Features.Query
{
    public record GetAllEmployeeQuery : IRequest<IEnumerable<GetEmployeeVm>>
    {

    }
}
