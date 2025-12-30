namespace EMS.API.Entities
{
    public class Document
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string Number { get; set; }
        public string Description { get; set; }
        public string Handler { get; set; }

    }
}
