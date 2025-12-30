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
        public int CityCode { get; set; }
        public int CountyCode { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? State { get; set; }
        public string? StreetNumber { get; set; }
        [JsonIgnore]
        public Guid UserId {  get; set; }
        [JsonIgnore]
        public User? User { get; set; }
    }
}
