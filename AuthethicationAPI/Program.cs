using Authentication.Core.Repository;
using Authentication.Core.Service;
using Authentication.Infrastructure.Data;
using Authentication.Infrastructure.Repository;
using Authentication.Infrastructure.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<AuthenticationDbContext>(option => {
    option.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    //this need for migrations
    option.UseSqlServer(builder.Configuration.GetConnectionString("AuthenticationDb")); // this line of code help Program.cs locate the connection string in appsetting.json
});
builder.Services.AddScoped<IAccountRepositoryAsync, AccountRepositoryAsync>();
builder.Services.AddScoped<IAccountServiceAsync, AccountServiceAsync>();    

builder.Services.AddScoped<IRoleRepositoryAsync, RoleRepositoryAsync>();
builder.Services.AddScoped<IRoleServiceAsync, RoleServiceAsync>();

builder.Services.AddScoped<IUserRoleRepositoryAsync,UserRoleRepositoryAsync>();
builder.Services.AddScoped<IUserRoleServiceAsync,UserRoleServiceAsync>();

//builder.Services.AddSingleton<JwtTokenHandler>();


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
