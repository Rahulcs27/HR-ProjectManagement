using MediatR;

namespace HR.Application.Features.TimeSheet.Commands.CreateTimeSheet
{
    public record AddTimeSheetCommand(TimeSheetDto TimeSheet) : IRequest<TimeSheetDto>;

}
