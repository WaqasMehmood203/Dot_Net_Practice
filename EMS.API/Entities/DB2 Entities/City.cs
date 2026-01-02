using System.Text.Json.Serialization;

namespace EMS.API.Entities.DB2_Entities
{
    public class City
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? CityCode { get; set; }

        [JsonIgnore]
        public Address? Address { get; set; }
    }
}
