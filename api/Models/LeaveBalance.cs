using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class LeaveBalance
    {
        [Key]
        public int idLeaveBalance { get; set; }
        [ForeignKey("idUser")]
        public int idUser { get; set; }
        public int LeaveTypeId { get; set; }
        public int AvailableDays { get; set; }
        public int AccruedDays { get; set; }
        public int UsedDays { get; set; }
        public required User User { get; set; }
        public required LeaveType LeaveType { get; set; }
    }
}