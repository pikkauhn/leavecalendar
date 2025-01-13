enum LeaveStatus {
  Pending = 1,
  Approved = 2,
  Rejected = 3,
}

enum LeaveType {
  Vacation = 1,
  Sick = 2,
}

interface LeaveRequest {
  id: number;
  userId: number;
  reason: string;
  startDate: Date;
  endDate: Date;
  status: LeaveStatus;
  leaveType: LeaveType;
  comment: string | null;
  responseByUserId: number | null;
}

interface CreateLeaveRequestDto {
    userId: number;
    reason: string;
    startDate: string;
    endDate: string;    
    leaveType: LeaveType;
}

interface UpdateLeaveRequestDto {    
    id: number;
    reason: string;
    startDate: Date;
    endDate: Date;
    status: LeaveStatus;
    leaveType: LeaveType;
    comment: string | null;
    responseByUserId: number | null;
}