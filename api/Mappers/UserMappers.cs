using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.User;
using api.Models;

namespace api.Mappers
{
    public static class UserMappers
    {
        public static UserDto ToUserDto(this User userModel)
        {
            return new UserDto
            {
                Id = userModel.Id,
                Username = userModel.Username,
                Name = userModel.Name,
                Role = userModel.Role,
                AvailableVacationDays = userModel.AvailableVacationDays,
                AvailableSickDays = userModel.AvailableSickDays,
                DepartmentId = userModel.DepartmentId
            };
        }

        public static User ToUserFromCreateDTO(this CreateUserRequestDto userDto)
        {
            return new User
            {
                Username = userDto.Username,
                Password = userDto.Password,
                Name = userDto.Name,
                Role = userDto.Role,
                AvailableVacationDays = userDto.AvailableVacationDays,
                AvailableSickDays = userDto.AvailableSickDays,
                DepartmentId = userDto.DepartmentId
            };
        }

                public static User ToUserFromUpdateDTO(this UpdateUserRequestDto userDto)
        {
            return new User
            {
                Username = userDto.Username,
                Password = userDto.Password,
                Name = userDto.Name,
                Role = userDto.Role,
                AvailableVacationDays = userDto.AvailableVacationDays,
                AvailableSickDays = userDto.AvailableSickDays,
                DepartmentId = userDto.DepartmentId
            };
        }
    }
}