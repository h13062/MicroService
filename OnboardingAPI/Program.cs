using Microsoft.EntityFrameworkCore;
using Onboarding.Core.Contracts.Repository;
using Onboarding.Core.Contracts.Service;
using Onboarding.Infrastructure.Data;
using Onboarding.Infrastructure.Repository;
using Onboarding.Infrastructure.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddDbContext<OnboardingDbContext>(option => {
//    option.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
//    //this need for migrations
//    option.UseSqlServer(builder.Configuration.GetConnectionString("OnBoardingDb")); // this line of code help Program.cs locate the connection string in appsetting.json
//});
var connectionString = Environment.GetEnvironmentVariable("OnBoardingDb");

builder.Services.AddDbContext<OnboardingDbContext>(option => {

    if (connectionString.Length > 1)
    {
        option.UseSqlServer(connectionString);
    }
    else
    {
        //this need for migrations
        option.UseSqlServer(builder.Configuration.GetConnectionString("OnBoardingDb")); // this line of code help Program.cs locate the connection string in appsetting.json
    }
    option.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

builder.Services.AddScoped<IEmployeeRepositoryAsync, EmployeeRepositoryAsync>();
builder.Services.AddScoped<IEmployeeServiceAsync, EmployeeServiceAsync>();

builder.Services.AddScoped<IEmployeeRoleRepositoryAsync, EmployeeRoleRepositoryAsync>();
builder.Services.AddScoped<IEmployeeRoleServiceAsync, EmployeeRoleServiceAsync>();

builder.Services.AddScoped<IEmployeeCategoryRepositoryAsync, EmployeeCategoryRepositoryAsync>();
builder.Services.AddScoped<IEmployeeCategoryServiceAsync, EmployeeCategoryServiceAsync>();

builder.Services.AddScoped<IEmployeeStatusRepositoryAsync, EmployeeStatusRepositoryAsync>();
builder.Services.AddScoped<IEmployeeStatusServiceAsync, EmployeeStatusServiceAsync>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
