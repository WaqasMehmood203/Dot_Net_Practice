using System.Text.Json.Serialization;

namespace EMS.API.Entities.DB2_Entities
{
    public class State
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public Address? Address { get; set; }
    }
}

