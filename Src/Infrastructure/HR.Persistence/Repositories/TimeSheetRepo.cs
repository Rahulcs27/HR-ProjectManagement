using HR.Application.Contracts.Persistence;
using HR.Application.Features.TimeSheet.Commands.CreateTimeSheet;
using HR.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace HR.Persistence.Repositories
{
    public class TimeSheetRepo : ITimeSheetRepository
    {
        readonly AppDbContext _appDbContext;
        public TimeSheetRepo(AppDbContext dbContext)
        {

            _appDbContext = dbContext;

        }


        public async Task<TimeSheet> AddTimeSheet(TimeSheetDto timeSheetDto)
        {
            string sql = "EXEC SP_TimeSheetInsert  @Fk_EmployeeId = {0}, @Fk_JobId = {1},@StartDate = {2}, @EndDate = {3}, @CreatedBy = {4}, @TimeSheetStatus = {5}";
            await _appDbContext.Database.ExecuteSqlRawAsync(sql, timeSheetDto.EmployeeId, timeSheetDto.JobId, timeSheetDto.StartDate, timeSheetDto.EndDate, timeSheetDto.CreatedBy, timeSheetDto.TimeSheetStatus);

            return new TimeSheet
            {
                EmployeeId = timeSheetDto.EmployeeId,
                JobId = timeSheetDto.JobId,
                StartDate = timeSheetDto.StartDate,
                EndDate = timeSheetDto.EndDate,
                CreatedBy = timeSheetDto.CreatedBy,
                TimeSheetStatus = timeSheetDto.TimeSheetStatus


            };

        }


    }
}

