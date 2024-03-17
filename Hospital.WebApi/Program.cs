using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using HospitalCmsSystem.Application.Services;
using HospitalCmsSystem.Application.Interfaces;
using HospitalCmsSystem.Persistence.Repositories;
using HospitalCmsSystem.Persistence.Context;
using HospitalCmsSystem.Application.Interfaces.DoctorInterfaces;
using HospitalCmsSystem.Persistence.Repositories.Doctor;
using FluentValidation.AspNetCore;
using System.Reflection;
using HospitalCmsSystem.Application.Interfaces.DepartmentInterfaces;
using HospitalCmsSystem.Persistence.Repositories.Department;
using HospitalCmsSystem.Application.Interfaces.BlogInterfaces;
using HospitalCmsSystem.Persistence.Repositories.Blog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationService(builder.Configuration);
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IBlogRepository ,BlogRepository>();
builder.Services.AddScoped<AppDbContext>();

builder.Services.AddControllers().AddFluentValidation(x =>
{
    x.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
});
// Add services to the container.

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
