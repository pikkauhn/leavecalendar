using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.LeaveBalance
{
    public class UpdateLeaveBalanceDto
    {
        public int Id { get; set; }
        public int AvailableDays { get; set; }
        public int AccruedDays { get; set; }
        public int UsedDays { get; set; }
    }
}