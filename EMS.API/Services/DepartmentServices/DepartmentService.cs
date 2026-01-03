using AutoMapper;
using EMS.API.DbContexts;
using EMS.API.Dtos.Departments;
using EMS.API.Entities;
using EMS.API.Entities.DB2_Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace EMS.API.Services.DepartmentServices
{
    public class DepartmentService: IDepartmentService
    {
        private readonly LogsDbContext _context;
        private readonly IMapper _mapper;
        public DepartmentService(LogsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DepartmentReadDto> AddAsync(DepartmentCreateDto dto)
        {
            var entity = _mapper.Map<Department>(dto);
            entity.Id = Guid.NewGuid();
            _context.Departments.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<DepartmentReadDto>(entity);
        }

        public async Task<DepartmentReadDto?> UpdateAsync(Guid id, DepartmentUpdateDto dto)
        {
            var excisting = await _context.Departments.FindAsync(id);
            if (excisting == null)
            {
                return null;
            }
            _mapper.Map(dto, excisting);
            await _context.SaveChangesAsync();
            return _mapper.Map<DepartmentReadDto>(excisting);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var result = await _context.Departments.FindAsync(id);
            if (result == null)
            {
                return false;
            }
            _context.Departments.Remove(result);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<DepartmentReadDto?> GetByIdAsync(Guid id)
        {
            var existing = await _context.Departments.FindAsync(id);
            if (existing == null)
            {
                return null;
            }
            return _mapper.Map<DepartmentReadDto>(existing);
        }

        public async Task<IEnumerable<DepartmentReadDto>> GetAllAsync()
        {
            var result = await _context.Departments.ToListAsync();
            return _mapper.Map<IEnumerable<DepartmentReadDto>>(result);
        }
    }
}
