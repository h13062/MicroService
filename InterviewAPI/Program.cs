using InterviewCore.Repository;
using InterviewCore.Service;
using InterviewInfrastructure.Data;
using InterviewInfrastructure.Repository;
using InterviewInfrastructure.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<InterViewDbContext>(option => {
    option.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    //this need for migrations
    option.UseSqlServer(builder.Configuration.GetConnectionString("InterviewTrainningDb")); // this line of code help Program.cs locate the connection string in appsetting.json
});

//dependecies injection
builder.Services.AddScoped<IInterviewRepositoryAsync, InterviewRepositoryAsync>();
builder.Services.AddScoped<IInterviewServiceAsync, InterviewServiceAsync>();

builder.Services.AddScoped<IInterviewerRepositoryAsync, InterviewerRepositoryAsync>();
builder.Services.AddScoped<IInterviewerServiceAsync, InterviewerServiceAsync>();

builder.Services.AddScoped<IInterviewFeedBackRepositoryAsync, InterviewFeedBackRepositoryAsync>();
builder.Services.AddScoped<IInterviewFeedBackServiceAsync, InterviewFeedBackServiceAsync>();

builder.Services.AddScoped<IInterviewTypeRepositoryAsync, InterviewTypeRepositoryAsync>();
builder.Services.AddScoped<IInterviewTypeServiceAsync, InterviewTypeServiceAsync>();

builder.Services.AddScoped<IRecruiterRepositoryAsync, RecruiterRepositoryAsync>();
builder.Services.AddScoped<IRecruiterServiceAsync, RecruiterServiceAsync>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
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

app.MapControllers();

app.Run();
