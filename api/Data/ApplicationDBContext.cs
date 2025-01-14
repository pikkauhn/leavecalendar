using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        public required DbSet<User> Users { get; set; }
        public required DbSet<LeaveRequest> LeaveRequests { get; set; }
        public required DbSet<Department> Departments { get; set; }        
        public required DbSet<InvitationCode> InvitationCodes { get; set; }
        public required DbSet<LeaveBalance> LeaveBalances { get; set; }

    }
}