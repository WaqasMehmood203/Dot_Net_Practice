namespace EMS.API.Entities.DB2_Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? DOB { get; set; }
        public Address? Address { get; set; }
        public ContactInformation? ContactInformation { get; set; }
    }
}
