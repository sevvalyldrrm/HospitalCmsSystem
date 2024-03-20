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
using HospitalCmsSystem.Application.Interfaces.BlogInterfaces;
using HospitalCmsSystem.Application.Interfaces.DepartmentInterfaces;
using HospitalCmsSystem.Persistence.Repositories.Blog;
using HospitalCmsSystem.Persistence.Repositories.Department;
using HospitalCmsSystem.Application.Validators.AdminValidators;
using Microsoft.EntityFrameworkCore;
using HospitalCmsSystem.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using HospitalCmsSystem.Insfrastructre;

var builder = WebApplication.CreateBuilder(args);

// MediatR servislerini ve Behaviour'ları ekleyin
//builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));

// FluentValidation validatörlerini kaydedin

builder.Services.AddValidatorsFromAssembly(typeof(CreateAdminValidator).Assembly);//createadminin dizinindekileri otomatik esler
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());//Bu satır mevcut assembly'deki (genellikle Web API projenizdeki) tüm validatörleri tarar ve kaydeder.

//builder.Services.AddValidatorsFromAssemblyContaining<CreateAdminValidator>();
//builder.Services.AddValidatorsFromAssemblyContaining<UpdateAdminValidator>();
//builder.Services.AddScoped<ICreateAdminValidator, CreateAdminValidator>();
//builder.Services.AddScoped<IUpdateAdminValidator, UpdateAdminValidator>();

builder.Services.AddControllers().AddFluentValidation(fv => {
    fv.AutomaticValidationEnabled = true; // Eğer otomatik doğrulama istiyorsanız
});

// Uygulama servislerini ekleyin
builder.Services.AddApplicationService(builder.Configuration);
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IBlogRepository, BlogRepository>();
//builder.Services.AddScoped<AppDbContext>();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DBConStr"));
});
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
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
// Rol seed işlemi
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var roleManager = services.GetRequiredService<RoleManager<AppRole>>();

        await ApplicationDbInitializer.SeedRoles(roleManager);
    }
    catch (Exception ex)
    {
        // Rol seed işlemi sırasında bir hata oluşursa loglayabilirsiniz.
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred seeding the DB.");
    }
}

app.Run();
