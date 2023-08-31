using JituUdemy.Data;
using JituUdemy.Services;
using JituUdemy.Services.IServiecs;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DB connection
builder.Services.AddDbContext<JituUdemyDbContext>(options => 
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"));
});

// Register services  --- Dependency Injection
builder.Services.AddScoped<IUserService, UserService>();

//AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
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
