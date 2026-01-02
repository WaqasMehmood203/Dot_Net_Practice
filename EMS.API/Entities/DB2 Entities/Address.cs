using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
namespace EMS.API.Entities.DB2_Entities
{
    public class Address
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public string? HomeAddress { get; set; }
        public string? CurrentAddress { get; set; }
        public string? StreetNumber { get; set; }

        public Guid? CountryId { get; set; }
        public Country? Country { get; set; }
        public Guid? CityId { get; set; }
        public City? City { get; set; }
        public Guid? StateId { get; set; }
        public State? State { get; set; }
        [JsonIgnore]
        public Guid UserId {  get; set; }
        [JsonIgnore]
        public User? User { get; set; }
    }
}
