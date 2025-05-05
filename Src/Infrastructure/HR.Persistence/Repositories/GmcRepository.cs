using HR.Application.Contracts.Persistence;
using HR.Application.Features.GMC.Commands.AddFamilyDetails;
using HR.Domain.Entities;
using HR.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Persistence.Repositories
{
    public class GmcRepository : IGmcRepository
    {
        readonly AppDbContext _appDbContext;
        public GmcRepository(AppDbContext dbContext)
        {

            _appDbContext = dbContext;

        }
        public Task<int> AddEmpDetailsAsync(EmployeeMaster employee)
        {
            throw new NotImplementedException();
        }

        public async Task<AddFamilyDetailsCommandDto> CreateFamilyMemberAsync(AddFamilyDetailsCommandDto dto)
        {
            string sql = "EXEC SP_InsertFamilyMember @Fk_FamilyMemberTypeId = {0}, @Fk_Id = {1}, @FamilyMemberName = {2}, @BirthDate = {3}, @Age = {4}, @RelationWithEmployee = {5}, @CreatedBy = {6}, @FamilyStatus = {7}";

            // Execute the stored procedure to insert a family member
            await _appDbContext.Database.ExecuteSqlRawAsync(sql,
                dto.Fk_FamilyMemberTypeId,
                dto.Fk_Id,
                dto.FamilyMemberName,
                dto.BirthDate,
                dto.Age,
                dto.RelationWithEmployee,
                dto.CreatedBy,
                dto.FamilyStatus
            );

            // After insertion, return the DTO with created date and other values
            return new AddFamilyDetailsCommandDto
            {
                Fk_FamilyMemberTypeId = dto.Fk_FamilyMemberTypeId,
                Fk_Id = dto.Fk_Id,
                FamilyMemberName = dto.FamilyMemberName,
                BirthDate = dto.BirthDate,
                Age = dto.Age,
                RelationWithEmployee = dto.RelationWithEmployee,
                CreatedBy = dto.CreatedBy,
                CreatedDate = DateTime.UtcNow,
                FamilyStatus = dto.FamilyStatus
            };
        }
    }
}
