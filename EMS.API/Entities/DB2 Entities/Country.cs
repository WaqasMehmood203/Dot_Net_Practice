using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EMS.API.Entities.DB2_Entities
{
    public class Country
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
