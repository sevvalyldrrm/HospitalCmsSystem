using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HospitalCmsSystem.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class _1001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DepartmentDetailsId = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GitHubAcc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admins_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Categories = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blogs_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Diagnosis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDischarged = table.Column<bool>(type: "bit", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionShort = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionLong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepartmentDetails_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specialty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    IntroductionId = table.Column<int>(type: "int", nullable: false),
                    DocFacebook = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocX = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocPinterest = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocSkype = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocLinkedIn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctors_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Doctors_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "BlogComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlogId = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogComments_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_BlogComments_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "BlogImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlogId = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogImages_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentBlogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    BlogId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentBlogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepartmentBlogs_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DepartmentBlogs_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Surgeries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    SurgeryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surgeries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Surgeries_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Surgeries_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentManagers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    StartingTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndingTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentManagers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppointmentManagers_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AppointmentManagers_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "DoctorPatients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorPatients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorPatients_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DoctorPatients_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "SurgeryDoctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    SurgeryId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurgeryDoctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SurgeryDoctors_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_SurgeryDoctors_Surgeries_SurgeryId",
                        column: x => x.SurgeryId,
                        principalTable: "Surgeries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppointmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AppointmentManagerId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_AppointmentManagers_AppointmentManagerId",
                        column: x => x.AppointmentManagerId,
                        principalTable: "AppointmentManagers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Appointments_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Appointments_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Appointments_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "WorkingHours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    DayOfWeek = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    IsOffDay = table.Column<bool>(type: "bit", nullable: false),
                    AppointmentManagerId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingHours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkingHours_AppointmentManagers_AppointmentManagerId",
                        column: x => x.AppointmentManagerId,
                        principalTable: "AppointmentManagers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorkingHours_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Introductions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MySkills = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkingHourId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Introductions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Introductions_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Introductions_WorkingHours_WorkingHourId",
                        column: x => x.WorkingHourId,
                        principalTable: "WorkingHours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Educations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    University = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Explanation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    IntroductionId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Educations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Educations_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Educations_Introductions_IntroductionId",
                        column: x => x.IntroductionId,
                        principalTable: "Introductions",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "ImagePath", "IsActive", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, null, "8ab7c1e1-93e5-425c-96da-6b6d02651e80", "user1@example.com", true, null, null, true, false, null, "USER1@EXAMPLE.COM", "USER6", "HashForPassword1", null, false, "e31067a2-0caa-41ff-8de3-78e8ed55f7b5", false, "user6" },
                    { 2, 0, null, "4843b214-02f6-454b-96ba-62e2c7feec80", "user2@example.com", true, null, null, true, false, null, "USER2@EXAMPLE.COM", "USER7", "HashForPassword2", null, false, "d1696a7f-1df9-495c-b54a-15cf10d6ccbd", false, "user7" },
                    { 3, 0, null, "0f6c522d-3028-4218-a2fe-78704b689edd", "user3@example.com", true, null, null, true, false, null, "USER3@EXAMPLE.COM", "USER8", "HashForPassword3", null, false, "be7f61b9-5fad-4f65-b0e9-3a5d7857ee5c", false, "user8" },
                    { 4, 0, null, "8bb40aa3-c01a-4ce9-9006-f600eec6c93a", "user4@example.com", true, null, null, true, false, null, "USER4@EXAMPLE.COM", "USER9", "HashForPassword4", null, false, "1bb84565-4d2e-41c3-ab69-609d1a8b3a4c", false, "user9" },
                    { 5, 0, null, "121b7c9d-e81e-4b20-8654-1df440389dff", "user5@example.com", true, null, null, true, false, null, "USER5@EXAMPLE.COM", "USER10", "HashForPassword5", null, false, "8aed7cc7-6374-4c28-8738-800b3e7cbae9", false, "user10" },
                    { 6, 0, "Antalya", "a634e9a4-42a1-4514-ae50-a417c1dc6c76", "user5@example.com", true, "User Five", "path/to/image5.jpg", true, false, null, "USER5@EXAMPLE.COM", "USER5", "AQAAAAIAAYagAAAAEPtHgMgQtP4g2Icg/VPft6Jn7/vuiweuHsbU7erFZ1s7zLCEtlJIO9GfDNvy/uW8Qg==", null, false, "", false, "user5" },
                    { 7, 0, "Bursa", "dcfa9c76-ca89-4896-b086-bf4cb7dace14", "user4@example.com", true, "User Four", "path/to/image4.jpg", true, false, null, "USER4@EXAMPLE.COM", "USER4", "AQAAAAIAAYagAAAAEHK1sZcR/ccNuZ5vdzxFgf3Oa618DaKGllIZmblJz08Qsi1jAVaQ9pQ1RVwfR+9how==", null, false, "", false, "user4" },
                    { 8, 0, "Izmir", "598df1ea-df73-4875-9f90-9547de2e3adf", "user3@example.com", true, "User Three", "path/to/image3.jpg", true, false, null, "USER3@EXAMPLE.COM", "USER3", "AQAAAAIAAYagAAAAEBI0CwSdq9OR0svB0ZxrU2unws4LTJA8RnMXONkdvQ4BgSXpptkyeaWKNKhRv9SN8g==", null, false, "", false, "user3" },
                    { 9, 0, "Ankara", "fef93201-c604-4c11-a5d4-205885e7f4bb", "user2@example.com", true, "User Two", "path/to/image2.jpg", true, false, null, "USER2@EXAMPLE.COM", "USER2", "AQAAAAIAAYagAAAAEEE44eXEG2pALLQ4DclejOqTincybYlE0arSQYhzUd5meDfpESSmX+X4bFWKcVEAqA==", null, false, "", false, "user2" },
                    { 10, 0, "Istanbul", "0451bc4a-ff26-42d3-9f29-f445be4007dc", "user1@example.com", true, "User One", "path/to/image1.jpg", true, false, null, "USER1@EXAMPLE.COM", "USER1", "AQAAAAIAAYagAAAAELlIg2fG7jjQyQ3wUAgwuVuNl2HWL+psuo5wZnh3TbH1130KJWNUaFcnGVyv6VK/JQ==", null, false, "", false, "user1" }
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Email", "FullName", "Message", "Phone", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 20, 1, 9, 50, 179, DateTimeKind.Utc).AddTicks(1678), null, "john.doe@example.com", "John Doe", "I have a question about...", "123-456-7890", "Inquiry", null },
                    { 2, new DateTime(2024, 3, 20, 1, 9, 50, 179, DateTimeKind.Utc).AddTicks(1681), null, "jane.smith@example.com", "Jane Smith", "I need assistance with...", "098-765-4321", "Support", null },
                    { 3, new DateTime(2024, 3, 20, 1, 9, 50, 179, DateTimeKind.Utc).AddTicks(1683), null, "chris.johnson@example.com", "Chris Johnson", "Here's what I think...", "555-123-4567", "Feedback", null },
                    { 4, new DateTime(2024, 3, 20, 1, 9, 50, 179, DateTimeKind.Utc).AddTicks(1685), null, "patricia.brown@example.com", "Patricia Brown", "I would like to schedule a visit...", "666-789-1234", "Appointment", null },
                    { 5, new DateTime(2024, 3, 20, 1, 9, 50, 179, DateTimeKind.Utc).AddTicks(1687), null, "sam.walker@example.com", "Sam Walker", "I have another type of question...", "555-678-1234", "Other", null }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "DepartmentDetailsId", "Description", "ImagePath", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 20, 1, 9, 50, 179, DateTimeKind.Utc).AddTicks(1756), null, 1, "Heart related services", null, "Cardiology", null },
                    { 2, new DateTime(2024, 3, 20, 1, 9, 50, 179, DateTimeKind.Utc).AddTicks(1759), null, 2, "Brain and nervous system services", null, "Neurology", null },
                    { 3, new DateTime(2024, 3, 20, 1, 9, 50, 179, DateTimeKind.Utc).AddTicks(1761), null, 3, "Cancer treatment services", null, "Oncology", null },
                    { 4, new DateTime(2024, 3, 20, 1, 9, 50, 179, DateTimeKind.Utc).AddTicks(1763), null, 4, "Medical care for children", null, "Pediatrics", null },
                    { 5, new DateTime(2024, 3, 20, 1, 9, 50, 179, DateTimeKind.Utc).AddTicks(1765), null, 5, "Musculoskeletal system services", null, "Orthopedics", null }
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "AppUserId", "CreatedAt", "DeletedAt", "GitHubAcc", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://github.com/klcuur", "Uğur Kılıç", null },
                    { 2, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://github.com/sevvalyldrrm", "Şevval Yıldırım", null },
                    { 3, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://github.com/o-ozkaya", "Ogün Özkaya", null },
                    { 4, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://github.com/HdrClkl", "Hıdır Çelikel", null },
                    { 5, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "github.com/adminfive", "Admin Five", null }
                });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "AppUserId", "Categories", "Content", "CreatedAt", "DeletedAt", "Tags", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, "[]", "Some valuable health tips content...", new DateTime(2024, 3, 20, 1, 9, 50, 179, DateTimeKind.Utc).AddTicks(1403), null, "[]", "Latest Health Tips", null },
                    { 2, 1, "[]", "Deep dive into chronic diseases...", new DateTime(2024, 3, 20, 1, 9, 50, 179, DateTimeKind.Utc).AddTicks(1408), null, "[]", "Understanding Chronic Diseases", null },
                    { 3, 2, "[]", "How to stay ahead of potential health issues...", new DateTime(2024, 3, 20, 1, 9, 50, 179, DateTimeKind.Utc).AddTicks(1411), null, "[]", "Preventive Healthcare", null },
                    { 4, 2, "[]", "Exploring the relationship between diet and wellness...", new DateTime(2024, 3, 20, 1, 9, 50, 179, DateTimeKind.Utc).AddTicks(1414), null, "[]", "Nutrition and Health", null },
                    { 5, 3, "[]", "Essential tips for maintaining a fit lifestyle...", new DateTime(2024, 3, 20, 1, 9, 50, 179, DateTimeKind.Utc).AddTicks(1420), null, "[]", "Fitness Fundamentals", null }
                });

            migrationBuilder.InsertData(
                table: "DepartmentDetails",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "DepartmentId", "DescriptionLong", "DescriptionShort", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 20, 1, 9, 50, 179, DateTimeKind.Utc).AddTicks(1943), null, 1, "Long description of Cardiology", "Short description of Cardiology", "About Cardiology", null },
                    { 2, new DateTime(2024, 3, 20, 1, 9, 50, 179, DateTimeKind.Utc).AddTicks(1946), null, 2, "Long description of Neurology", "Short description of Neurology", "About Neurology", null },
                    { 3, new DateTime(2024, 3, 20, 1, 9, 50, 179, DateTimeKind.Utc).AddTicks(1948), null, 3, "Long description of Oncology", "Short description of Oncology", "About Oncology", null },
                    { 4, new DateTime(2024, 3, 20, 1, 9, 50, 179, DateTimeKind.Utc).AddTicks(1950), null, 4, "Long description of Pediatrics", "Short description of Pediatrics", "About Pediatrics", null },
                    { 5, new DateTime(2024, 3, 20, 1, 9, 50, 179, DateTimeKind.Utc).AddTicks(1952), null, 5, "Long description of Orthopedics", "Short description of Orthopedics", "About Orthopedics", null }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "AppUserId", "CreatedAt", "DeletedAt", "DepartmentId", "DocFacebook", "DocLinkedIn", "DocPinterest", "DocSkype", "DocTitle", "DocX", "IntroductionId", "Name", "Specialty", "UpdatedAt" },
                values: new object[,]
                {
                    { 11, 6, new DateTime(2024, 3, 20, 1, 9, 50, 179, DateTimeKind.Utc).AddTicks(2025), null, 1, null, null, null, null, null, null, 0, "Dr. Emily White", "Cardiology", null },
                    { 12, 7, new DateTime(2024, 3, 20, 1, 9, 50, 179, DateTimeKind.Utc).AddTicks(2029), null, 2, null, null, null, null, null, null, 0, "Dr. John Carter", "Neurology", null },
                    { 13, 8, new DateTime(2024, 3, 20, 1, 9, 50, 179, DateTimeKind.Utc).AddTicks(2032), null, 3, null, null, null, null, null, null, 0, "Dr. Clara Oswald", "Oncology", null },
                    { 14, 9, new DateTime(2024, 3, 20, 1, 9, 50, 179, DateTimeKind.Utc).AddTicks(2034), null, 5, null, null, null, null, null, null, 0, "Dr. Derek Shepherd", "Orthopedics", null },
                    { 15, 10, new DateTime(2024, 3, 20, 1, 9, 50, 179, DateTimeKind.Utc).AddTicks(2117), null, 4, null, null, null, null, null, null, 0, "Dr. Meredith Grey", "General Surgery", null }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "AppUserId", "CreatedAt", "DeletedAt", "Diagnosis", "IsDischarged", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 6, 6, new DateTime(2024, 3, 20, 1, 9, 50, 179, DateTimeKind.Utc).AddTicks(2439), null, "Acute Stress Reaction", false, "Michael Scott", null },
                    { 7, 7, new DateTime(2024, 3, 20, 1, 9, 50, 179, DateTimeKind.Utc).AddTicks(2442), null, "Common Cold", true, "Pam Beesly", null },
                    { 8, 8, new DateTime(2024, 3, 20, 1, 9, 50, 179, DateTimeKind.Utc).AddTicks(2444), null, "Sprained Ankle", false, "Jim Halpert", null },
                    { 9, 9, new DateTime(2024, 3, 20, 1, 9, 50, 179, DateTimeKind.Utc).AddTicks(2446), null, "Concussion", false, "Dwight Schrute", null },
                    { 10, 10, new DateTime(2024, 3, 20, 1, 9, 50, 179, DateTimeKind.Utc).AddTicks(2449), null, "Hypertension", true, "Angela Martin", null }
                });

            migrationBuilder.InsertData(
                table: "AppointmentManagers",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "DoctorId", "EndingTime", "PatientId", "StartingTime", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 11, new DateTime(2024, 3, 21, 11, 0, 0, 0, DateTimeKind.Unspecified), 10, new DateTime(2024, 3, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), 1, null },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 12, new DateTime(2024, 3, 22, 15, 0, 0, 0, DateTimeKind.Unspecified), 9, new DateTime(2024, 3, 22, 14, 0, 0, 0, DateTimeKind.Unspecified), 2, null },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 13, new DateTime(2024, 3, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), 8, new DateTime(2024, 3, 23, 16, 0, 0, 0, DateTimeKind.Unspecified), 3, null },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 14, new DateTime(2024, 3, 24, 10, 0, 0, 0, DateTimeKind.Unspecified), 7, new DateTime(2024, 3, 24, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, null },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 15, new DateTime(2024, 3, 25, 12, 30, 0, 0, DateTimeKind.Unspecified), 6, new DateTime(2024, 3, 25, 11, 30, 0, 0, DateTimeKind.Unspecified), 1, null }
                });

            migrationBuilder.InsertData(
                table: "BlogComments",
                columns: new[] { "Id", "AppUserId", "BlogId", "Comment", "CreatedAt", "DeletedAt", "IsActive", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, 1, "This is a very insightful article. Thank you for sharing!", new DateTime(2024, 3, 20, 1, 9, 50, 179, DateTimeKind.Utc).AddTicks(1539), null, true, null },
                    { 2, 2, 1, "I appreciate the depth of this post. Looking forward to more.", new DateTime(2024, 3, 20, 1, 9, 50, 179, DateTimeKind.Utc).AddTicks(1542), null, true, null },
                    { 3, 3, 2, "Can you provide more information on this subject?", new DateTime(2024, 3, 20, 1, 9, 50, 179, DateTimeKind.Utc).AddTicks(1544), null, true, null },
                    { 4, 4, 2, "I disagree with some points here, but it's a good read overall.", new DateTime(2024, 3, 20, 1, 9, 50, 179, DateTimeKind.Utc).AddTicks(1546), null, true, null },
                    { 5, 5, 3, "How can I get in touch with the author for further questions?", new DateTime(2024, 3, 20, 1, 9, 50, 179, DateTimeKind.Utc).AddTicks(1548), null, true, null }
                });

            migrationBuilder.InsertData(
                table: "BlogImages",
                columns: new[] { "Id", "BlogId", "CreatedAt", "DeletedAt", "ImagePath", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 3, 20, 1, 9, 50, 179, DateTimeKind.Utc).AddTicks(1630), null, "images/blog1.jpg", null },
                    { 2, 1, new DateTime(2024, 3, 20, 1, 9, 50, 179, DateTimeKind.Utc).AddTicks(1633), null, "images/blog2.jpg", null },
                    { 3, 2, new DateTime(2024, 3, 20, 1, 9, 50, 179, DateTimeKind.Utc).AddTicks(1634), null, "images/blog3.jpg", null },
                    { 4, 2, new DateTime(2024, 3, 20, 1, 9, 50, 179, DateTimeKind.Utc).AddTicks(1636), null, "images/blog4.jpg", null },
                    { 5, 3, new DateTime(2024, 3, 20, 1, 9, 50, 179, DateTimeKind.Utc).AddTicks(1637), null, "images/blog5.jpg", null }
                });

            migrationBuilder.InsertData(
                table: "DepartmentBlogs",
                columns: new[] { "Id", "BlogId", "CreatedAt", "DeletedAt", "DepartmentId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 3, 20, 1, 9, 50, 179, DateTimeKind.Utc).AddTicks(1803), null, 1, null },
                    { 2, 2, new DateTime(2024, 3, 20, 1, 9, 50, 179, DateTimeKind.Utc).AddTicks(1805), null, 1, null },
                    { 3, 3, new DateTime(2024, 3, 20, 1, 9, 50, 179, DateTimeKind.Utc).AddTicks(1806), null, 2, null },
                    { 4, 4, new DateTime(2024, 3, 20, 1, 9, 50, 179, DateTimeKind.Utc).AddTicks(1808), null, 2, null },
                    { 5, 5, new DateTime(2024, 3, 20, 1, 9, 50, 179, DateTimeKind.Utc).AddTicks(1816), null, 3, null }
                });

            migrationBuilder.InsertData(
                table: "DoctorPatients",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "DoctorId", "PatientId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 20, 1, 9, 50, 179, DateTimeKind.Utc).AddTicks(2164), null, 11, 6, null },
                    { 2, new DateTime(2024, 3, 20, 1, 9, 50, 179, DateTimeKind.Utc).AddTicks(2166), null, 12, 7, null },
                    { 3, new DateTime(2024, 3, 20, 1, 9, 50, 179, DateTimeKind.Utc).AddTicks(2168), null, 13, 8, null },
                    { 4, new DateTime(2024, 3, 20, 1, 9, 50, 179, DateTimeKind.Utc).AddTicks(2169), null, 14, 9, null },
                    { 5, new DateTime(2024, 3, 20, 1, 9, 50, 179, DateTimeKind.Utc).AddTicks(2171), null, 15, 10, null }
                });

            migrationBuilder.InsertData(
                table: "Educations",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "DoctorId", "Explanation", "IntroductionId", "University", "UpdatedAt", "Year" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 20, 1, 9, 50, 179, DateTimeKind.Utc).AddTicks(2211), null, 11, null, null, "Harvard University", null, "2000 - 2004" },
                    { 2, new DateTime(2024, 3, 20, 1, 9, 50, 179, DateTimeKind.Utc).AddTicks(2214), null, 12, null, null, "Johns Hopkins University", null, "2002 - 2006" },
                    { 3, new DateTime(2024, 3, 20, 1, 9, 50, 179, DateTimeKind.Utc).AddTicks(2216), null, 13, null, null, "Stanford University", null, "2001 - 2005" },
                    { 4, new DateTime(2024, 3, 20, 1, 9, 50, 179, DateTimeKind.Utc).AddTicks(2218), null, 14, null, null, "University of California", null, "2003 - 2007" },
                    { 5, new DateTime(2024, 3, 20, 1, 9, 50, 179, DateTimeKind.Utc).AddTicks(2220), null, 15, null, null, "Massachusetts Institute of Technology", null, "2004 - 2008" }
                });

            migrationBuilder.InsertData(
                table: "Surgeries",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "DepartmentId", "PatientId", "SurgeryDate", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 20, 1, 9, 50, 179, DateTimeKind.Utc).AddTicks(2570), null, 1, 6, new DateTime(2024, 4, 19, 1, 9, 50, 179, DateTimeKind.Utc).AddTicks(2526), null },
                    { 2, new DateTime(2024, 3, 20, 1, 9, 50, 179, DateTimeKind.Utc).AddTicks(2573), null, 2, 7, new DateTime(2024, 5, 19, 1, 9, 50, 179, DateTimeKind.Utc).AddTicks(2572), null },
                    { 3, new DateTime(2024, 3, 20, 1, 9, 50, 179, DateTimeKind.Utc).AddTicks(2576), null, 3, 8, new DateTime(2024, 6, 18, 1, 9, 50, 179, DateTimeKind.Utc).AddTicks(2575), null },
                    { 4, new DateTime(2024, 3, 20, 1, 9, 50, 179, DateTimeKind.Utc).AddTicks(2578), null, 4, 9, new DateTime(2024, 7, 18, 1, 9, 50, 179, DateTimeKind.Utc).AddTicks(2578), null },
                    { 5, new DateTime(2024, 3, 20, 1, 9, 50, 179, DateTimeKind.Utc).AddTicks(2581), null, 5, 10, new DateTime(2024, 8, 17, 1, 9, 50, 179, DateTimeKind.Utc).AddTicks(2580), null }
                });

            migrationBuilder.InsertData(
                table: "WorkingHours",
                columns: new[] { "Id", "AppointmentManagerId", "CreatedAt", "DayOfWeek", "DeletedAt", "DoctorId", "EndTime", "IsOffDay", "StartTime", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2024, 3, 20, 1, 9, 50, 179, DateTimeKind.Utc).AddTicks(2692), 1, null, 11, new TimeSpan(0, 16, 0, 0, 0), false, new TimeSpan(0, 8, 0, 0, 0), null },
                    { 2, null, new DateTime(2024, 3, 20, 1, 9, 50, 179, DateTimeKind.Utc).AddTicks(2695), 2, null, 12, new TimeSpan(0, 17, 0, 0, 0), false, new TimeSpan(0, 9, 0, 0, 0), null },
                    { 3, null, new DateTime(2024, 3, 20, 1, 9, 50, 179, DateTimeKind.Utc).AddTicks(2697), 3, null, 13, new TimeSpan(0, 18, 0, 0, 0), false, new TimeSpan(0, 10, 0, 0, 0), null },
                    { 4, null, new DateTime(2024, 3, 20, 1, 9, 50, 179, DateTimeKind.Utc).AddTicks(2700), 4, null, 14, new TimeSpan(0, 19, 0, 0, 0), false, new TimeSpan(0, 11, 0, 0, 0), null },
                    { 5, null, new DateTime(2024, 3, 20, 1, 9, 50, 179, DateTimeKind.Utc).AddTicks(2702), 5, null, 15, new TimeSpan(0, 20, 0, 0, 0), false, new TimeSpan(0, 12, 0, 0, 0), null }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "AppointmentDate", "AppointmentManagerId", "CreatedAt", "DeletedAt", "DepartmentId", "DoctorId", "Email", "FullName", "Message", "PatientId", "Phone", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 11, "patient1@example.com", "Patient One", "I need a general check-up.", 10, "1234567890", null },
                    { 2, new DateTime(2024, 3, 22, 14, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 12, "patient2@example.com", "Patient Two", "Consultation about my recent diagnosis.", 9, "0987654321", null },
                    { 3, new DateTime(2024, 3, 23, 16, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 13, "patient3@example.com", "Patient Three", "Follow-up on the previous treatment.", 8, "1231231234", null },
                    { 4, new DateTime(2024, 3, 24, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, 14, "patient4@example.com", "Patient Four", "Emergency consultation required.", 7, "3213214321", null },
                    { 5, new DateTime(2024, 3, 25, 11, 30, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5, 15, "patient5@example.com", "Patient Five", "Discussion about surgery options.", 6, "4564564567", null }
                });

            migrationBuilder.InsertData(
                table: "Introductions",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Description", "DoctorId", "MySkills", "UpdatedAt", "WorkingHourId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 20, 1, 9, 50, 179, DateTimeKind.Utc).AddTicks(2276), null, "Expert in Cardiology with 20 years of experience.", 11, null, null, 1 },
                    { 2, new DateTime(2024, 3, 20, 1, 9, 50, 179, DateTimeKind.Utc).AddTicks(2280), null, "Renowned Neurologist and published author.", 12, null, null, 1 },
                    { 3, new DateTime(2024, 3, 20, 1, 9, 50, 179, DateTimeKind.Utc).AddTicks(2282), null, "Leading Oncologist with numerous successful treatments.", 13, null, null, 1 },
                    { 4, new DateTime(2024, 3, 20, 1, 9, 50, 179, DateTimeKind.Utc).AddTicks(2284), null, "Orthopedic Surgeon with a focus on sports injuries.", 14, null, null, 1 },
                    { 5, new DateTime(2024, 3, 20, 1, 9, 50, 179, DateTimeKind.Utc).AddTicks(2286), null, "Award-winning General Surgeon with a passion for teaching.", 15, null, null, 1 }
                });

            migrationBuilder.InsertData(
                table: "SurgeryDoctors",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "DoctorId", "SurgeryId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 20, 1, 9, 50, 179, DateTimeKind.Utc).AddTicks(2625), null, 11, 1, null },
                    { 2, new DateTime(2024, 3, 20, 1, 9, 50, 179, DateTimeKind.Utc).AddTicks(2627), null, 12, 2, null },
                    { 3, new DateTime(2024, 3, 20, 1, 9, 50, 179, DateTimeKind.Utc).AddTicks(2628), null, 13, 3, null },
                    { 4, new DateTime(2024, 3, 20, 1, 9, 50, 179, DateTimeKind.Utc).AddTicks(2630), null, 14, 4, null },
                    { 5, new DateTime(2024, 3, 20, 1, 9, 50, 179, DateTimeKind.Utc).AddTicks(2631), null, 15, 5, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admins_AppUserId",
                table: "Admins",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentManagers_DoctorId",
                table: "AppointmentManagers",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentManagers_PatientId",
                table: "AppointmentManagers",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_AppointmentManagerId",
                table: "Appointments",
                column: "AppointmentManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DepartmentId",
                table: "Appointments",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoctorId",
                table: "Appointments",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientId",
                table: "Appointments",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BlogComments_AppUserId",
                table: "BlogComments",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogComments_BlogId",
                table: "BlogComments",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogImages_BlogId",
                table: "BlogImages",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_AppUserId",
                table: "Blogs",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentBlogs_BlogId",
                table: "DepartmentBlogs",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentBlogs_DepartmentId",
                table: "DepartmentBlogs",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentDetails_DepartmentId",
                table: "DepartmentDetails",
                column: "DepartmentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DoctorPatients_DoctorId",
                table: "DoctorPatients",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorPatients_PatientId",
                table: "DoctorPatients",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_AppUserId",
                table: "Doctors",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_DepartmentId",
                table: "Doctors",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Educations_DoctorId",
                table: "Educations",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Educations_IntroductionId",
                table: "Educations",
                column: "IntroductionId");

            migrationBuilder.CreateIndex(
                name: "IX_Introductions_DoctorId",
                table: "Introductions",
                column: "DoctorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Introductions_WorkingHourId",
                table: "Introductions",
                column: "WorkingHourId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_AppUserId",
                table: "Patients",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Surgeries_DepartmentId",
                table: "Surgeries",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Surgeries_PatientId",
                table: "Surgeries",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_SurgeryDoctors_DoctorId",
                table: "SurgeryDoctors",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_SurgeryDoctors_SurgeryId",
                table: "SurgeryDoctors",
                column: "SurgeryId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkingHours_AppointmentManagerId",
                table: "WorkingHours",
                column: "AppointmentManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkingHours_DoctorId",
                table: "WorkingHours",
                column: "DoctorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BlogComments");

            migrationBuilder.DropTable(
                name: "BlogImages");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "DepartmentBlogs");

            migrationBuilder.DropTable(
                name: "DepartmentDetails");

            migrationBuilder.DropTable(
                name: "DoctorPatients");

            migrationBuilder.DropTable(
                name: "Educations");

            migrationBuilder.DropTable(
                name: "SurgeryDoctors");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "Introductions");

            migrationBuilder.DropTable(
                name: "Surgeries");

            migrationBuilder.DropTable(
                name: "WorkingHours");

            migrationBuilder.DropTable(
                name: "AppointmentManagers");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
