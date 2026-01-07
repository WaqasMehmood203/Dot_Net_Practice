using AutoMapper;
using EMS.API.DbContexts;
using EMS.API.Dtos.Cities;
using EMS.API.Entities.DB2_Entities;
using Microsoft.EntityFrameworkCore;

namespace EMS.API.Services.CityServices
{
    public class CityService : ICityService
    {
        private readonly LogsDbContext _context;
        private readonly IMapper _mapper;
        public CityService(LogsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CityReadDto> AddAsync(CityCreateDto dto)
        {
            var entity = _mapper.Map<City>(dto);
            entity.Id = Guid.NewGuid();
            _context.Cities.Add(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<CityReadDto>(entity);
        }

        public async Task<CityReadDto?> UpdateAsync(Guid Id, CityUpdateDto dto)
        {
            var excisting = await _context.Cities.FindAsync(Id);
            if (excisting == null)
            {
                return null;
            }
            _mapper.Map(dto, excisting);
            await _context.SaveChangesAsync();
            return _mapper.Map<CityReadDto>(excisting);
        }

        public async Task<bool> DeleteAsync(Guid Id)
        {
            var excisting = await _context.Cities.FindAsync(Id);
            if (excisting == null)
            {
                return false;
            }
            _context.Cities.Remove(excisting);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<CityReadDto?> GetByIdAsync(Guid Id)
        {
            var excisting = await _context.Cities.FindAsync(Id);
            if (excisting == null)
            {
                return null;
            }
            return _mapper.Map<CityReadDto>(excisting);
        }

        public async Task<IEnumerable<CityReadDto>> GetAllAsync()
        {
            var cities = await _context.Cities.ToListAsync();
            return _mapper.Map<IEnumerable<CityReadDto>>(cities);
        }
    }
}
