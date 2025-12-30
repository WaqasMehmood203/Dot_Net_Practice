namespace EMS.API.Entities.DB3_Entities
{
    public class ApiLog
    {
        public Guid Id { get; set; }
        public string? Endpoint { get; set; }
        public string? HttpMethod { get; set; }
        public int ResponseStatus { get; set; }
        public DateTime RequestTime { get; set; }
        public DateTime ResponseTime { get; set; }
        public string? UserAgent { get; set; }
        public string? IpAddress { get; set; }
    }
}
