using EMS.API.Entities;
using EMS.API.Entities.DB2_Entities;

namespace EMS.API.Services.EmployeeServices
{
    public interface IEmployeeService
    {
        public Task<Employee> AddEmployeeAsync(Employee employee);
        public Task<Employee> UpdateEmployeeAsync(Guid id, Employee employee);
        public Task<bool> DeleteEmployeeAsync(Guid id);
        public Task<Employee> GetEmployeeByIdAsync(Guid id);
        public Task<List<Employee>> GetAllEmployeeAsync();
    }
}
