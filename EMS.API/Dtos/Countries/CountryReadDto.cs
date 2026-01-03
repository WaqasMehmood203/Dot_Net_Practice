namespace EMS.API.Dtos.Country
{
    public class CountryReadDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Continent { get; set; }
        public string? Capital { get; set; }
        public string? Population { get; set; }
        public int? CountryCode { get; set; }
        public string Language { get; set; }
    }
}
