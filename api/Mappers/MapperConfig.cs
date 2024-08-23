using api.Dtos.Department;
using api.Dtos.InvitationCode;
using api.Dtos.LeaveBalance;
using api.Dtos.LeaveRequest;
using api.Dtos.User;
using api.Models;
using AutoMapper;

namespace api.Mappers
{
    public static class MapperConfig
    {
        public static IMapper Initialize()
        {
            var config = new MapperConfiguration(cfg =>
            {
                // User
                cfg.CreateMap<User, UserDto>();
                cfg.CreateMap<UserDto, User>();
                cfg.CreateMap<CreateUserRequestDto, User>();
                cfg.CreateMap<UpdateUserRequestDto, User>();

                // InvitationCode
                cfg.CreateMap<InvitationCode, InvitationCodeDto>();
                cfg.CreateMap<InvitationCodeDto, InvitationCode>();

                // Department
                cfg.CreateMap<Department, DepartmentDto>();
                cfg.CreateMap<DepartmentDto, Department>();

                // LeaveRequest
                cfg.CreateMap<LeaveRequest, LeaveRequestDto>();
                cfg.CreateMap<LeaveRequestDto, LeaveRequest>();

                // LeaveBalance
                cfg.CreateMap<LeaveBalance, LeaveBalanceDto>();
                cfg.CreateMap<LeaveBalanceDto, LeaveBalance>();
                cfg.CreateMap<CreateLeaveBalanceDto, LeaveBalance>();
                cfg.CreateMap<UpdateLeaveBalanceDto, LeaveBalance>();
            });
            return config.CreateMapper();
        }
    }
}