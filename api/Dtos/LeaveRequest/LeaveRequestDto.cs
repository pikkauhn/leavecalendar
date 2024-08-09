using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.LeaveRequest
{
    public class LeaveRequestDto
    {
        public int UserId { get; set; }
        public required string Reason { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public required int LeaveType { get; set; }
        public required int Status { get; set; }
        public string? Comment { get; set; }
    }
}