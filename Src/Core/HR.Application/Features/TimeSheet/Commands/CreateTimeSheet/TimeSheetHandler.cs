using AutoMapper;
using HR.Application.Contracts.Persistence;
using MediatR;

namespace HR.Application.Features.TimeSheet.Commands.CreateTimeSheet
{
    public class TimeSheetHandler : IRequestHandler<AddTimeSheetCommand, TimeSheetDto>
    {
        readonly IMapper _mapper;
        readonly ITimeSheetRepository _timeSheetRepository;

        public TimeSheetHandler(IMapper mapper, ITimeSheetRepository iTimeSheetRepository)
        {
            _mapper = mapper;
            _timeSheetRepository = iTimeSheetRepository;

        }



        public async Task<TimeSheetDto> Handle(AddTimeSheetCommand request, CancellationToken cancellationToken)
        {
            var timesheet = await _timeSheetRepository.AddTimeSheet(request.TimeSheet);
            return _mapper.Map<TimeSheetDto>(timesheet);
        }
    }
}
