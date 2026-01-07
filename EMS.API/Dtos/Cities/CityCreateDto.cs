    using System.ComponentModel.DataAnnotations;

namespace EMS.API.Dtos.Cities
{
    public class CityCreateDto
    {
        [Required]
        public string Name { get; set; }
        public string? CityCode { get; set; }
        public string? Downtown { get; set; }
        public string? Country { get; set; }
        public long? Population { get; set; }
    }
}
