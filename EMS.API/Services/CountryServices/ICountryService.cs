using EMS.API.Dtos.Country;

namespace EMS.API.Services.CountryServices
{
    public interface ICountryService
    {
        Task<CountryReadDto> CreateAsync(CountryCreateDto dto);
        Task<CountryReadDto?> UpdateAsync(Guid Id, CountryUpdateDto dto);
        Task<bool> DeleteAsync(Guid Id);
        Task<CountryReadDto?> GetByIdAsync(Guid Id);
        Task<IEnumerable<CountryReadDto>> GetAllAsync();
    }
}
