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
using MediatR;
using FluentValidation;
using HospitalCmsSystem.Application.Behaviors.HospitalCmsSystem.Application.Behaviors;
using HospitalCmsSystem.Application.Behaviors;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// MediatR servislerini ve Behaviour'ları ekleyin
//builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));

// FluentValidation validatörlerini kaydedin
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

builder.Services.AddControllers().AddFluentValidation(fv => {
    fv.AutomaticValidationEnabled = true; // Eğer otomatik doğrulama istiyorsanız
});

// Uygulama servislerini ekleyin
builder.Services.AddApplicationService(builder.Configuration);
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<AppDbContext>();

// Logger servisini ekleyin
builder.Services.AddLogging();

// Swagger'ı ekleyin
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Serilog yapılandırması
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File("logs/myapp.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog();


var app = builder.Build();

// Geliştirme ortamı için Swagger UI'ı etkinleştirin
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
