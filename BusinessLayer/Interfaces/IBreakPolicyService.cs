using BusinessLayer.Common;
using BusinessLayer.DTOs;


namespace BusinessLayer.Interfaces
{
    public interface IBreakPolicyService
    {
        Task<ApiResponse<IEnumerable<BreakPolicyDto>>> GetAll(int userId);
        Task<ApiResponse<BreakPolicyDto?>> GetById(int id);
        Task<ApiResponse<string>> CreateAsync(BreakPolicyDto dto);
        Task<ApiResponse<string>> UpdateAsync(BreakPolicyDto dto);
        Task<ApiResponse<string>> DeleteAsync(int id);
    }
}
