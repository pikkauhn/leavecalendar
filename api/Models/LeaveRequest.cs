namespace api.Models
{
    public enum LeaveStatus 
    {
        Pending = 1,
        Approved = 2,
        Rejected = 3
    }
    
    public class LeaveRequest
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public required string Reason { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public required LeaveStatus Status { get; set; }
        public required LeaveType LeaveType { get; set; }
        public string? Comment { get; set; }
        public required User User { get; set; }
    }
}