using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Department;
using api.Dtos.InvitationCode;
using api.Dtos.LeaveBalance;
using api.Dtos.LeaveRequest;
using api.Dtos.LeaveType;
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
            return config.CreateMapper();
        }
    }
}