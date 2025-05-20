using Microsoft.EntityFrameworkCore;
using WoodWorkshop.Repositories;
using WoodWorkshop.Services;
using WoodWorkshop.Models;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<WoodWorkshopContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));

//// Đăng ký Repository và Service
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IInformationUserRepository, InformationUserRepository>();

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
