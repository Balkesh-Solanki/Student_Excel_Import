using BusinessLayer;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Implementations;
using ServiceLayer.Interfaces;
using Student_Excel_Data_Import_API.DataLayer.Entities;

var builder = WebApplication.CreateBuilder(args);

// Configure MySQL Database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))));

// Register Services
builder.Services.AddScoped<IStudentExcelService, StudentExcelService>();
builder.Services.AddScoped<StudentBLL>();

// Add services to the container.

builder.Services.AddControllers();
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
