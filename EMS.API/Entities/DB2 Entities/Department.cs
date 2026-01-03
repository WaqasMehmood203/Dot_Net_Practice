using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace EMS.API.Entities.DB2_Entities
{
    public class Department
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public long? Students { get; set; }
        public long? Teachers { get; set; }
        public string? HeadOfDepartment { get; set; }
        public string? Uiversity { get; set; }
        public string? UniversityNumber { get; set; }
    }
}
