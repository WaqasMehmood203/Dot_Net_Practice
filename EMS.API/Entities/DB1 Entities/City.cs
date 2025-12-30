namespace EMS.API.Entities
{
    public class City
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? State { get; set; }
        public string Country { get; set; }
        public string? Region { get; set; }
    }
}
