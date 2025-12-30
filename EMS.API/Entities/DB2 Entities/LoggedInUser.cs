namespace EMS.API.Entities.DB2_Entities
{
    public class LoggedInUser
    {
        public Guid Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public DateTime LoginTime { get; set; }
        public DateTime? LogoutTime { get; set; }
        public string? SessionId { get; set; }
    }
}
