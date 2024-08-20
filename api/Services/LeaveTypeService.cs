using api.Interfaces;
using api.Models;
using AutoMapper;

namespace api.Services
{
    public class LeaveTypeService : ILeaveTypeService
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
        public LeaveTypeService(ILeaveTypeRepository leaveTypeRepository, IMapper mapper )
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public Task<LeaveType> CreateLeaveTypeAsync(LeaveType leaveType)
        {
            throw new NotImplementedException();
        }

        public Task<LeaveType?> DeleteLeaveTypeAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LeaveType>> GetAllLeaveTypesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<LeaveType?> GetLeaveTypeByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<LeaveType?> UpdateLeaveTypeAsync(LeaveType leaveType)
        {
            throw new NotImplementedException();
        }
    }
}