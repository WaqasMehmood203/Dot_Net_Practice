using EMS.API.Dtos.Departments;

namespace EMS.API.Services.DepartmentServices
{
    public interface IDepartmentService
    {
        Task<DepartmentReadDto> AddAsync(DepartmentCreateDto dto);
        Task<DepartmentReadDto?> UpdateAsync(Guid id, DepartmentUpdateDto dto);
        Task<bool> DeleteAsync(Guid id);
        Task<DepartmentReadDto?> GetByIdAsync(Guid id);
        Task<IEnumerable<DepartmentReadDto>> GetAllAsync();
    }
}
