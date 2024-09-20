using AutoMapper;
using api.Models;
using api.Dtos.InvitationCode;
using api.Dtos.LeaveBalance;
using api.Dtos.LeaveRequest;
using api.Dtos.User;

namespace api.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // User
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<CreateUserRequestDto, User>();
            CreateMap<UpdateUserRequestDto, User>();
            CreateMap<UpdateUserRequestDto, User>()
               .ForAllMembers(opt => opt.Condition((src, dest, value) =>
               value != null && !string.IsNullOrEmpty(value.ToString()) && !value.Equals(0)));

            // InvitationCode
            CreateMap<InvitationCode, InvitationCodeDto>();
            CreateMap<InvitationCodeDto, InvitationCode>();

            // LeaveRequest
            CreateMap<LeaveRequest, LeaveRequestDto>();
            CreateMap<LeaveRequestDto, LeaveRequest>();
            CreateMap<LeaveRequest, LeaveResponseDto>();
            CreateMap<LeaveResponseDto, LeaveRequest>();

            // LeaveBalance
            CreateMap<LeaveBalance, LeaveBalanceDto>();
            CreateMap<LeaveBalanceDto, LeaveBalance>();
            CreateMap<CreateLeaveBalanceDto, LeaveBalance>();
            CreateMap<UpdateLeaveBalanceDto, LeaveBalance>();

        }
    }
}