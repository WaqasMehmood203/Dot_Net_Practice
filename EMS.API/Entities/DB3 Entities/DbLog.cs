namespace EMS.API.Entities.DB3_Entities
{
    public class DbLog
    {
        public Guid Id { get; set; }
        public string? LogType { get; set; }
        public string? Message { get; set; }
        public DateTime LogTime { get; set; }
        public string? Details { get; set; }
    }
}
