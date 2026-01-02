using EMS.API.Entities.DB2_Entities;

namespace EMS.API.Dtos.Users
{
    public class AddUserDto
    {
        public string Name { get; set; }
        public string? DOB { get; set; }
        public Address? Address { get; set; }
        public ContactInformation? ContactInformation { get; set; }
    }
}
