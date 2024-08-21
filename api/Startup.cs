using api.Data;
using api.Interfaces;
using api.Repository;
using api.Services;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    public IConfiguration Configuration { get; set; }
    public void ConfigureServices(IServiceCollection services)
    {
        // Register AutoMapper
        services.AddAutoMapper(typeof(Startup));
        // Resgister DBContext
        services.AddDbContext<ApplicationDBContext>(options =>
        {
            options.UseMySql(Configuration.GetConnectionString("defaultConnection"),
                ServerVersion.AutoDetect(new MySqlConnection(
                    Configuration.GetConnectionString("defaultConnection"))));
        });

        services.AddControllers().AddApplicationServices();
        // Configure Cors
        services.AddCors(options =>
        {
            options.AddPolicy("MyCorsPolicy",
            builder =>
            {
                builder.WithOrigins("http://localhost:3000", "http://localhost5031")
                .AllowAnyMethod()
                .AllowAnyHeader();
            });
        });
    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseHttpsRedirection();
        app.UseCors("MyCorsPolicy");
        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }

}
public static class MvcBuilderExtensions
{
    public static IMvcBuilder AddApplicationServices(this IMvcBuilder builder)
    {
        // Register Services
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<IDepartmentService, DepartmentService>();
        builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        builder.Services.AddScoped<IInvitationCodeService, InvitationCodeService>();
        builder.Services.AddScoped<IInvitationCodeRepository, InvitationCodeRepository>();
        builder.Services.AddScoped<ILeaveRequestService, LeaveRequestService>();
        builder.Services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();
        builder.Services.AddScoped<ILeaveTypeService, LeaveTypeService>();
        builder.Services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();
        builder.Services.AddScoped<ILeaveBalanceService, LeaveBalanceService>();
        builder.Services.AddScoped<ILeaveBalanceRepository, LeaveBalanceRepository>();

        return builder;
    }
}