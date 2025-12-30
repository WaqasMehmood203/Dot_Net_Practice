namespace EMS.API.Entities.DB3_Entities
{
    public class ApplicationLog
    {
        public Guid Id { get; set; }
        public string? ApplicationName { get; set; }
        public string? LogLevel { get; set; }
        public string? Message { get; set; }
        public DateTime LogTime { get; set; }
        public string? ExceptionDetails { get; set; }
    }
}
