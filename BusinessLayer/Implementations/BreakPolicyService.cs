using BusinessLayer.Common;
using BusinessLayer.DTOs;
using BusinessLayer.Interfaces;
using DataAccessLayer.DBContext;
using DataAccessLayer.Repositories.GeneralRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Implementations
{
    public class BreakPolicyService: IBreakPolicyService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BreakPolicyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET ALL
        public async Task<ApiResponse<IEnumerable<BreakPolicyDto>>> GetAll(int userId)
        {
            var list = (await _unitOfWork.Repository<BreakPolicy>()
                .FindAsync(x => !x.IsDeleted && x.UserId == userId))
                .OrderByDescending(x => x.BreakPolicyId)
                .Select(x => new BreakPolicyDto
                {
                    BreakPolicyId = x.BreakPolicyId,
                    CompanyId = x.CompanyId,
                    RegionId = x.RegionId,
                    PolicyCode = x.PolicyCode,
                    PolicyName = x.PolicyName,
                    BreakType = x.BreakType,
                    DurationMinutes = x.DurationMinutes,
                    MaxBreaksPerDay = x.MaxBreaksPerDay,
                    GraceMinutes = x.GraceMinutes,
                    ShiftId = x.ShiftId,
                    IsActive = x.IsActive,
                    UserId = x.UserId
                });

            return new ApiResponse<IEnumerable<BreakPolicyDto>>(list, "Break Policies fetched");
        }

        // GET BY ID
        public async Task<ApiResponse<BreakPolicyDto?>> GetById(int id)
        {
            var x = await _unitOfWork.Repository<BreakPolicy>()
                .GetByIdAsync(id);

            if (x == null || x.IsDeleted)
                return new ApiResponse<BreakPolicyDto?>
                (
                    null,
                    "Break Policy not found",
                    false
                );

            return new ApiResponse<BreakPolicyDto?>
            (
                new BreakPolicyDto
                {
                    BreakPolicyId = x.BreakPolicyId,
                    CompanyId = x.CompanyId,
                    RegionId = x.RegionId,
                    PolicyCode = x.PolicyCode,
                    PolicyName = x.PolicyName,
                    BreakType = x.BreakType,
                    DurationMinutes = x.DurationMinutes,
                    MaxBreaksPerDay = x.MaxBreaksPerDay,
                    GraceMinutes = x.GraceMinutes,
                    ShiftId = x.ShiftId,
                    IsActive = x.IsActive,
                    UserId = x.UserId
                }
            );
        }

        // CREATE
        public async Task<ApiResponse<string>> CreateAsync(BreakPolicyDto dto)
        {
            var duplicate = (await _unitOfWork.Repository<BreakPolicy>()
                .FindAsync(x =>
                    !x.IsDeleted &&
                    x.CompanyId == dto.CompanyId &&
                    x.RegionId == dto.RegionId &&
                    x.PolicyName.ToLower() == dto.PolicyName.ToLower()))
                .Any();

            if (duplicate)
                return new ApiResponse<string>
                (
                    null!,
                    "Duplicate Break Policy exists",
                    false
                );

            var entity = new BreakPolicy
            {
                CompanyId = dto.CompanyId,
                RegionId = dto.RegionId,
                PolicyCode = dto.PolicyCode,
                PolicyName = dto.PolicyName,
                BreakType = dto.BreakType,
                DurationMinutes = dto.DurationMinutes,
                MaxBreaksPerDay = dto.MaxBreaksPerDay,
                GraceMinutes = dto.GraceMinutes,
                ShiftId = dto.ShiftId,
                IsActive = dto.IsActive,
                UserId = dto.UserId,
                IsDeleted = false,
                CreatedDate = DateTime.UtcNow,
                CreatedBy = dto.UserId
            };

            await _unitOfWork.Repository<BreakPolicy>()
                .AddAsync(entity);

            await _unitOfWork.CompleteAsync();

            return new ApiResponse<string>
            (
                "Break Policy created successfully"
            );
        }

        // UPDATE
        public async Task<ApiResponse<string>> UpdateAsync(BreakPolicyDto dto)
        {
            var entity = await _unitOfWork.Repository<BreakPolicy>()
                .GetByIdAsync(dto.BreakPolicyId);

            if (entity == null || entity.IsDeleted)
                return new ApiResponse<string>
                (
                    null!,
                    "Break Policy not found",
                    false
                );

            var duplicate = (await _unitOfWork.Repository<BreakPolicy>()
                .FindAsync(x =>
                    !x.IsDeleted &&
                    x.BreakPolicyId != dto.BreakPolicyId &&
                    x.CompanyId == dto.CompanyId &&
                    x.RegionId == dto.RegionId &&
                    x.PolicyName.ToLower() == dto.PolicyName.ToLower()))
                .Any();

            if (duplicate)
                return new ApiResponse<string>
                (
                    null!,
                    "Duplicate Break Policy exists",
                    false
                );

            entity.CompanyId = dto.CompanyId;
            entity.RegionId = dto.RegionId;
            entity.PolicyCode = dto.PolicyCode;
            entity.PolicyName = dto.PolicyName;
            entity.BreakType = dto.BreakType;
            entity.DurationMinutes = dto.DurationMinutes;
            entity.MaxBreaksPerDay = dto.MaxBreaksPerDay;
            entity.GraceMinutes = dto.GraceMinutes;
            entity.ShiftId = dto.ShiftId;
            entity.IsActive = dto.IsActive;

            entity.UpdatedDate = DateTime.UtcNow;
           // entity.ModifiedBy = dto.UserId;

            _unitOfWork.Repository<BreakPolicy>()
                .Update(entity);

            await _unitOfWork.CompleteAsync();

            return new ApiResponse<string>
            (
                "Break Policy updated successfully"
            );
        }

        // DELETE
        public async Task<ApiResponse<string>> DeleteAsync(int id)
        {
            var entity = await _unitOfWork.Repository<BreakPolicy>()
                .GetByIdAsync(id);

            if (entity == null || entity.IsDeleted)
                return new ApiResponse<string>
                (
                    null!,
                    "Break Policy not found",
                    false
                );

            entity.IsDeleted = true;
            entity.UpdatedDate = DateTime.UtcNow;
           // entity.ModifiedBy = entity.UserId;

            _unitOfWork.Repository<BreakPolicy>()
                .Update(entity);

            await _unitOfWork.CompleteAsync();

            return new ApiResponse<string>
            (
                "Break Policy deleted successfully"
            );
        }
    }
}
