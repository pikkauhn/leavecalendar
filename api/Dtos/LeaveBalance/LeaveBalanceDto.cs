namespace api.Dtos.LeaveBalance
{
    public class LeaveBalanceDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int LeaveTypeId { get; set; }
        public int AvailableDays { get; set; }
        public int AccruedDays { get; set; }
        public int UsedDays { get; set; }
    }
        public class CreateLeaveBalanceDto
    {
        public int UserId { get; set; }
        public int LeaveTypeId { get; set; }
        public int AvailableDays { get; set; }
        public int AccruedDays { get; set; }
        public int UsedDays { get; set; }
    }
        public class UpdateLeaveBalanceDto
    {
        public int Id { get; set; }
        public int AvailableDays { get; set; }
        public int AccruedDays { get; set; }
        public int UsedDays { get; set; }
    }
}