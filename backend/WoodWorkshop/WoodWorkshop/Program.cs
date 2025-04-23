using Microsoft.EntityFrameworkCore;
using WoodWorkshop.Models;
using WoodWorkshop.Repositories;
using WoodWorkshop.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<WoodWorkshop2025Context>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 34)) // hoặc version MySQL của bạn
    ));

// Đăng ký Repository và Service
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

//Đăng ký AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost", policy =>
    {
        policy.WithOrigins("http://localhost:3000")  // Địa chỉ frontend React
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials();  // Cho phép cookie/credentials
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();
app.UseCors("AllowLocalhost");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
