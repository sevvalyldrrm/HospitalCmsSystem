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
using HospitalCmsSystem.Infrastructure;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Cors politikasını ekleyin
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("https://localhost:7153")
                          .AllowAnyHeader()
                          .AllowAnyMethod());
});

// MediatR services and behaviors
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));

builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddSingleton<IEmailService, EmailService>();

// FluentValidation validatörlerini kaydedin

builder.Services.AddValidatorsFromAssembly(typeof(CreateAdminValidator).Assembly);//Bu satir CreateAdminValidator un dizinindeki tüm validatörleri tarar ve kaydeder.
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());//Bu satır mevcut assembly'deki (genellikle Web API projenizdeki) tüm validatörleri tarar ve kaydeder.
builder.Services.AddControllers().AddFluentValidation(fv => fv.AutomaticValidationEnabled = true);

// Application services
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
builder.Services.AddIdentity<AppUser, AppRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();
// Logger servisini ekleyin
builder.Services.AddLogging();

// Swagger'ı ekleyin
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddTransient<IFileStorageService, FileStorageService>();

// Serilog yapılandırması
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File("logs/myapp.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog();
builder.Services.Configure<IdentityOptions>(options =>
{
    // Password requirements (can be adjusted based on your needs)
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    // ... other password options

    options.User.RequireUniqueEmail = true;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;

    options.SignIn.RequireConfirmedEmail = true;
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey
        (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true
    };
});

builder.Services.AddAuthorization();

//swagger üzerine auth butonu eklendi
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

    // JWT Token için Bearer şeması tanımlama
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,
            },
            new List<string>()
        }
    });
});
var app = builder.Build();
var environment = app.Environment;

// Geliştirme ortamı için Swagger UI'ı etkinleştirin
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
app.UseStaticFiles();

// 'uploads' klasörü için statik dosya hizmetini yapılandırın
var uploadsFolderPath = Path.Combine(environment.ContentRootPath, "HospitalCmsSystem.Infrastructure", "Uploads");
if (!Directory.Exists(uploadsFolderPath))
{
    Directory.CreateDirectory(uploadsFolderPath);
}

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(uploadsFolderPath),
    RequestPath = "/uploads"
});
app.UseCors("AllowSpecificOrigin"); // Use the CORS policy

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthentication();
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
