using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public enum LeaveStatus 
    {
        Pending = 1,
        Approved = 2,
        Rejected = 3
    }
    public enum LeaveType
    {
        Vacation = 1,
        Sick = 2
    }
    
    public class LeaveRequest
    {
        [Key]
        public int idLeaveRequest { get; set; }
        public required int userLeaveRequest { get; set; }
        public required string Reason { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public required LeaveStatus Status { get; set; }
        public required LeaveType LeaveType { get; set; }
        public string? Comment { get; set; }
        public int? ResponseByUserId { get; set; }
    }
}