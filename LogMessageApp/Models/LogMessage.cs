namespace LogMessageApp.Models
{
    public class LogMessage
    {        
        public int Id { get; set; }
        public int? LogId { get; set; }
        public string? Message { get; set; }
        public string? Name { get; set; }
        public DateTime Created { get; set; }
        
    }
}
