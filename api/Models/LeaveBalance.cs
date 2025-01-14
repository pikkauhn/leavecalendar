using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class LeaveBalance
    {
        [Key]
        public int idLeaveBalance { get; set; }
        public int UserId { get; set; }
        public int LeaveTypeId { get; set; }
        public int AvailableDays { get; set; }
        public int AccruedDays { get; set; }
        public int UsedDays { get; set; }
        public required User User { get; set; }
        public required LeaveType LeaveType { get; set; }
    }
}