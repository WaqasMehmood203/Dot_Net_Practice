using AutoMapper;
using EMS.API.DbContexts;
using EMS.API.Dtos.Country;
using EMS.API.Entities.DB2_Entities;
using Microsoft.EntityFrameworkCore;

namespace EMS.API.Services.CountryServices
{
    public class CountryService : ICountryService
    {
        private readonly LogsDbContext _context;
        private readonly IMapper _mapper;
        public CountryService(LogsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<CountryReadDto> CreateAsync(CountryCreateDto dto)
        {
            var entity = _mapper.Map<Country>(dto);
            entity.Id =     Guid.NewGuid();
            _context.Countries.Add(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<CountryReadDto>(entity);
        }

        public async Task<CountryReadDto?> UpdateAsync(Guid Id, CountryUpdateDto dto)
        {
            var existing = await _context.Countries.FindAsync(Id);
            if (existing == null)
            {
                return null;
            }
            _mapper.Map(dto, existing);
            await _context.SaveChangesAsync();
            return _mapper.Map<CountryReadDto>(existing);
        }

        public async Task<bool> DeleteAsync(Guid Id)
        {
            var existing = await _context.Countries.FindAsync(Id);
            if (existing == null)
            {
                return false;
            }
            _context.Countries.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<CountryReadDto?> GetByIdAsync(Guid Id)
        {
            var existing = await _context.Countries.FindAsync(Id);
            if(existing == null)
            {
                return null;
            }
            return _mapper.Map<CountryReadDto>(existing);
        }
        public async Task<IEnumerable<CountryReadDto>> GetAllAsync()
        {
            var countries = await _context.Countries.ToListAsync();
            return _mapper.Map<IEnumerable<CountryReadDto>>(countries);
        }
    }
}
