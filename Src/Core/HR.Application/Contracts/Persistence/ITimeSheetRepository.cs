using HR.Application.Features.TimeSheet.Commands.CreateTimeSheet;
using HR.Domain.Entities;

namespace HR.Application.Contracts.Persistence
{
    public interface ITimeSheetRepository
    {
        Task<TimeSheet> AddTimeSheet(TimeSheetDto timeSheetDto);
    }
}
