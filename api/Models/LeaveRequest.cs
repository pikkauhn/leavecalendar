using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class LeaveRequest
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public required string Reason { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public required string Status { get; set; }
        public required string LeaveType { get; set; }
        public string Comment { get; set; } = string.Empty;
    }
}