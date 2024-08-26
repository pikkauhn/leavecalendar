using api.Data;
using api.Interfaces;
using api.Repository;
using api.Services;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var configuration = builder.Configuration;
        var connectionString = configuration.GetConnectionString("defaultConnection");
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new ArgumentException("Missing connection string: defaultConnection");
        }
        // Register AutoMapper
        builder.Services.AddAutoMapper(typeof(api.Mappers.MapperConfig));

        // Register DbContext
        builder.Services.AddDbContext<ApplicationDBContext>(options =>
        {
            options.UseMySql(connectionString,
                ServerVersion.AutoDetect(new MySqlConnection(
                    connectionString)));
        });

        // Add Swagger
        builder.Services.AddSwaggerGen();
        builder.Services.AddMvcCore().AddApiExplorer();

        // Configure Cors
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("MyCorsPolicy",
                builder =>
                {
                    builder.WithOrigins("http://localhost:3000", "http://localhost:5031")
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
        });

        // Register Services
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<IDepartmentService, DepartmentService>();
        builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        builder.Services.AddScoped<IInvitationCodeService, InvitationCodeService>();
        builder.Services.AddScoped<IInvitationCodeRepository, InvitationCodeRepository>();
        builder.Services.AddScoped<ILeaveRequestService, LeaveRequestService>();
        builder.Services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();
        builder.Services.AddScoped<ILeaveBalanceService, LeaveBalanceService>();
        builder.Services.AddScoped<ILeaveBalanceRepository, LeaveBalanceRepository>();


        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        // app.UseHttpsRedirection();

        app.UseCors("MyCorsPolicy");

        app.UseRouting();

        app.MapControllers();

        app.Run();
    }
}