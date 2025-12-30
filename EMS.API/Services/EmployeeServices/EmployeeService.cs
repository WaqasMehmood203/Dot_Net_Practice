using EMS.API.DbContexts;
using EMS.API.Entities;
using EMS.API.Entities.DB2_Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMS.API.Services.EmployeeServices
{
    public class EmployeeService : IEmployeeService
    {
        private readonly AppDbContext _context;
        private readonly LogsDbContext _logsContext;
        public EmployeeService(AppDbContext context, LogsDbContext logsContext)
        {
            _context = context;
            _logsContext = logsContext;
        }

        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            employee.Id = Guid.NewGuid();
            employee.DepartmentId = Guid.NewGuid();
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            UserLogHistory userLogHistory = new UserLogHistory
            {
                Id = Guid.NewGuid(),
                UserId = employee.Id, 
                ActionTime = DateTime.UtcNow,
                ActionType = "Add Employee",
                Description = $"Employee {employee.Name} added with ID {employee.Id}"
            };

            _logsContext.UserLogHistories.Add(userLogHistory);
            await _logsContext.SaveChangesAsync();
            return employee;
        }
        public async Task<Employee> UpdateEmployeeAsync(Guid id, Employee updatedemployee)
        {
            var employee = await _context.Employees.FindAsync(id);

            if(employee == null)
                return null;
            employee.Name = updatedemployee.Name;
            employee.Address = updatedemployee.Address;
            employee.CardNumber = updatedemployee.CardNumber;
            employee.DepartmentId = updatedemployee.DepartmentId;
            employee.Department = updatedemployee.Department;

            await _context.SaveChangesAsync();
            UserLogHistory log = new UserLogHistory
            {
                Id = Guid.NewGuid(),
                UserId = employee.Id,
                ActionTime = DateTime.UtcNow,
                ActionType = "UPDATE",
                Description = $"Employee '{employee.Name}' was updated"
            };

            _logsContext.UserLogHistories.Add(log);
            await _logsContext.SaveChangesAsync();
            return employee;
        }

        public async Task<bool> DeleteEmployeeAsync(Guid id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return false;
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            UserLogHistory log = new UserLogHistory
            {
                Id = Guid.NewGuid(),
                UserId = employee.Id,
                ActionTime = DateTime.UtcNow,
                ActionType = "DELETE",
                Description = $"Employee '{employee.Name}' was deleted"
            };
            return true;
        }
        public async Task<Employee> GetEmployeeByIdAsync(Guid id)
        {
            var result = await _context.Employees.FindAsync(id);
            return result;
        }

        public async Task<List<Employee>> GetAllEmployeeAsync()
        {
            return await _context.Employees.ToListAsync();
        }
    }
}
