using System.Text.Json.Serialization;

namespace EMS.API.Entities
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Address { get; set; }
        public long CardNumber{ get; set; }  
        public Guid DepartmentId { get; set; }
        public string? Department{ get; set; }
    }
}
