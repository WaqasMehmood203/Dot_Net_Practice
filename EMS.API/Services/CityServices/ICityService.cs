using EMS.API.Dtos.Cities;
namespace EMS.API.Services.CityServices
{
    public interface ICityService
    {
        Task<CityReadDto> AddAsync(CityCreateDto dto);
        Task<CityReadDto?> UpdateAsync(Guid Id, CityUpdateDto dto);
        Task<bool> DeleteAsync(Guid Id);
        Task<CityReadDto> GetByIdAsync(Guid Id);
        Task<IEnumerable<CityReadDto>> GetAllAsync();
    }
}
