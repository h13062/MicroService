using Microsoft.EntityFrameworkCore;
using RecruitingCore.Repository;
using RecruitingCore.Service;
using RecrutingInfrastructure.Repository;
using RecrutingInfrastructure.Service;
using RecrutingInfrasturcutre.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<RecrutingDbContext>(option => {
    option.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);//faster to query
    //this need for migrations
    option.UseSqlServer(builder.Configuration.GetConnectionString("RecrutingDbContext")); // this line of code help Program.cs locate the connection string in appsetting.json
});
//Dependency injection for repositories and services
builder.Services.AddScoped<ICandidateRepository, CandidateRepository>();
builder.Services.AddScoped<ICandidateService, CandidateService>();

builder.Services.AddScoped<IJobRequirementRepository, JobRequirementRepository>();
builder.Services.AddScoped<IJobRequirementService, JobRequirementService>();

builder.Services.AddScoped<ISubmissionRepository, SubmissionRepository>();
builder.Services.AddScoped<ISubmissionService, SubmissionService>();

builder.Services.AddScoped<ISubmissionStatusRepository, SubmssionStatusRepository>();
builder.Services.AddScoped<ISubmissionStatusService, SubmissionStatusService>();
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
