
using HR.Application.Contracts.Models;
using HR.Application.Dtos;
using MediatR;

namespace HR.Application.Features.LoginMaster.Query
{
    public record LoginQuery(LoginRequest loginRequest):IRequest<Tbl_LoginMasterDto>;
     
}
