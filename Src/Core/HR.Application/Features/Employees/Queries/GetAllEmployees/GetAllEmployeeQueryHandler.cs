﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HR.Application.Contracts.Persistence;
using HR.Application.Contracts.Models.Common;


namespace HR.Application.Features.Employee.Queries.GetAllEmployees
{
    //public class GetAllEmployeeQueryHandler : IRequestHandler<GetAllEmployeeQuery, Pag<GetAllEmployeeVm>>
    public class GetAllEmployeeQueryHandler : IRequestHandler<GetAllEmployeeQuery, PaginatedResult<GetAllEmployeeVm>>
    {
        private readonly IEmployeeRepository _repo;
        private readonly IMapper _mapper;


        public GetAllEmployeeQueryHandler(IEmployeeRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

       
        public async Task<PaginatedResult<GetAllEmployeeVm>> Handle(GetAllEmployeeQuery request, CancellationToken cancellationToken)
        {
            var result = await _repo.GetAllEmployeeSummaryPagedAsync(request.PageNumber, request.PageSize);

             var mappedData = _mapper.Map<List<GetAllEmployeeVm>>(result.Data);
            return new PaginatedResult<GetAllEmployeeVm>(mappedData, result.TotalCount, result.PageNumber, result.PageSize);
           
        }
    }
}
