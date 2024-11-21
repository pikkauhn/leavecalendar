namespace api.Dtos.LeaveRequest
{
    public class LeaveRequestDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public required string Reason { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Status { get; set; }
        public String? Comment { get; set; }
        public required int LeaveType { get; set; }
        public required int ResponseByUserId { get; set; }
    }
    public class LeaveResponseDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public required string Reason { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Status { get; set; }
        public required int LeaveType { get; set; }
        public string? Comment { get; set; }
        public required int ResponseByUserId { get; set; }
    }    
        public class CreateLeaveRequestDto
    {
        public int UserId { get; set; }
        public required string Reason { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public required int LeaveType { get; set; }
    }
}