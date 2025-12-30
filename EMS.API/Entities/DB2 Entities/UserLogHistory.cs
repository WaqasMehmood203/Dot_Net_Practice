namespace EMS.API.Entities.DB2_Entities
{
    public class UserLogHistory
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime ActionTime { get; set; }
        public string? ActionType { get; set; }
        public string? Description { get; set; }

    }
}
