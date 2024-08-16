using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace api.Mappers
{
    public static class MapperConfig
    {
        public static IMapper Initialize()
        {
            var config = new Mapperconfiguration(cfg => 
            {
                cfg.CreateMap<User, UserDto>();
                cfg.CreateMap<UserDto, User>();
                cfg.CreateMap<InvitationCode, InvitationCodeDto>();
                cfg.CreateMap<InvitationCodeDto, InvitationCode>();
                cfg.CreateMap<Department, DepartmentDto>();
                cfg.CreateMap<DepartmentDto, Department>();
                cfg.CreateMap<LeaveRequest, LeaveRequestDto>();
                cfg.CreateMap<LeaveRequestDto, LeaveRequest>();
                cfg.CreateMap<LeaveBalance, LeaveBalanceDto>();
                cfg.CreateMap<LeaveBalanceDto, LeaveBalance>();
                cfg.CreateMap<LeaveType, LeaveTypeDto>();
                cfg.CreateMap<LeaveTypeDto, LeaveType>();
            });
            return config.CreateMapper():
        }
    }
}