namespace EMS.API.Dtos.Departments
{
    public class DepartmentUpdateDto
    {
        public string Name { get; set; }
        public long? Students { get; set; }
        public long? Teachers { get; set; }
        public string? HeadOfDepartment { get; set; }
    }
}
