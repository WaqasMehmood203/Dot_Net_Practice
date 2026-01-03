namespace EMS.API.Dtos.Departments
{
    public class DepartmentReadDto
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
