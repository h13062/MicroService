using Microsoft.EntityFrameworkCore;
using Recruiting.Core.Repository;
using Recruiting.Core.Service;
using Recruiting.Infrastructure.Data;
using Recruiting.Infrastructure.Repository;
using Recruiting.Infrastructure.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCors(option => {
    option.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
var connectionString = Environment.GetEnvironmentVariable("RecruitingDb");
builder.Services.AddDbContext<RecruitingDbContext>(option => {

    if (connectionString.Length > 1)
    {
        option.UseSqlServer(connectionString);
    }
    else
    {        
        //this need for migrations
        option.UseSqlServer(builder.Configuration.GetConnectionString("RecruitingDb")); // this line of code help Program.cs locate the connection string in appsetting.json
    }
    option.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

//Dependency injection for repositories and services
builder.Services.AddScoped<ICandidateRepositoryAsync, CandidateRepositoryAsync>();
builder.Services.AddScoped<ICandidateServiceAsync, CandidateServiceAsync>();

builder.Services.AddScoped<IJobRequirementRepositoryAsync, JobRequirementRepositoryAsync>();
builder.Services.AddScoped<IJobRequirementServiceAsync, JobRequirementServiceAsync>();

builder.Services.AddScoped<ISubmissionRepositoryAsync, SubmissionRepositoryAsync>();
builder.Services.AddScoped<ISubmissionServiceAsync, SubmissionServiceAsync>();

builder.Services.AddScoped<ISubmissionStatusRepositoryAsync, SubmissionStatusRepositoryAsync>();
builder.Services.AddScoped<ISubmissionStatusServiceAsync, SubmissionStatusServiceAsync>();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseRouting();
app.UseCors();
app.MapControllers();

app.Run();
