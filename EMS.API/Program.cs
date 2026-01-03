using EMS.API.DbContexts;
using EMS.API.Mapping_Profile;
using EMS.API.Services.CountryServices;
using EMS.API.Services.EmployeeServices;
using EMS.API.Services.TeacherService;
using EMS.API.Services.UserServices;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using EMS.API.Services.DepartmentServices;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<ITeacherService, Teacherservice>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();

builder.Services.AddAutoMapper(typeof(MappingProfile));

//Creation of DbContexts
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AppDb")));

builder.Services.AddDbContext<LogsDbContext>(options =>
 options.UseSqlServer(builder.Configuration.GetConnectionString("LogsDb")));

builder.Services.AddDbContext<UserDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("UserDb")));

builder.Services.AddDbContext<StudentDbContext>(options =>
options.UseSqlite(builder.Configuration.GetConnectionString("Student.db")));


// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
