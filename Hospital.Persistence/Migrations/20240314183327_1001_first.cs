using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HospitalCmsSystem.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class _1001_first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GitHubAcc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUser", x => x.Id);
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
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Diagnosis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDischarged = table.Column<bool>(type: "bit", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_AppRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AppRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AppUserRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUserRole_AppRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AppRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AppUserRole_AppUser_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUser",
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
                    Tag = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blogs_AppUser_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUser",
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
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
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
                    Speacialty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    IntroductionId = table.Column<int>(type: "int", nullable: false),
                    DocFacebook = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocX = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocPinterest = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocSkype = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocLinkedIn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocTitle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctors_AppRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AppRole",
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
                name: "Surgeries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    SurgeryDate = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                name: "BlogComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlogId = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogComments_AppUser_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUser",
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
                    ImagePath = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
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
                    BlogId = table.Column<int>(type: "int", nullable: false)
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
                name: "AppointmentManagers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    StartingTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndingTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
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
                    PatientId = table.Column<int>(type: "int", nullable: false)
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
                    SurgeryId = table.Column<int>(type: "int", nullable: false)
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
                    AppointmentManagerId = table.Column<int>(type: "int", nullable: false)
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
                    AppointmentManagerId = table.Column<int>(type: "int", nullable: true)
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
                    MySkills = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkingHourId = table.Column<int>(type: "int", nullable: false)
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
                    Explanation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    IntroductionId = table.Column<int>(type: "int", nullable: true)
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
                table: "Admins",
                columns: new[] { "Id", "GitHubAcc" },
                values: new object[,]
                {
                    { 1, "GitHubUser1" },
                    { 2, "GitHubUser2" },
                    { 3, "GitHubUser3" },
                    { 4, "GitHubUser4" },
                    { 5, "GitHubUser5" }
                });

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 14, 18, 33, 26, 526, DateTimeKind.Utc).AddTicks(5117), null, new DateTime(2024, 3, 14, 18, 33, 26, 526, DateTimeKind.Utc).AddTicks(5121) },
                    { 2, new DateTime(2024, 3, 14, 18, 33, 26, 526, DateTimeKind.Utc).AddTicks(5122), null, new DateTime(2024, 3, 14, 18, 33, 26, 526, DateTimeKind.Utc).AddTicks(5122) },
                    { 3, new DateTime(2024, 3, 14, 18, 33, 26, 526, DateTimeKind.Utc).AddTicks(5123), null, new DateTime(2024, 3, 14, 18, 33, 26, 526, DateTimeKind.Utc).AddTicks(5124) },
                    { 4, new DateTime(2024, 3, 14, 18, 33, 26, 526, DateTimeKind.Utc).AddTicks(5125), null, new DateTime(2024, 3, 14, 18, 33, 26, 526, DateTimeKind.Utc).AddTicks(5125) },
                    { 5, new DateTime(2024, 3, 14, 18, 33, 26, 526, DateTimeKind.Utc).AddTicks(5126), null, new DateTime(2024, 3, 14, 18, 33, 26, 526, DateTimeKind.Utc).AddTicks(5126) }
                });

            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "City", "CreatedAt", "DeletedAt", "FullName", "ImagePath", "IsActive", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "CityOne", new DateTime(2024, 3, 14, 18, 33, 26, 526, DateTimeKind.Utc).AddTicks(5164), null, "User One", "path/to/user1.jpg", true, new DateTime(2024, 3, 14, 18, 33, 26, 526, DateTimeKind.Utc).AddTicks(5164) },
                    { 2, "CityTwo", new DateTime(2024, 3, 14, 18, 33, 26, 526, DateTimeKind.Utc).AddTicks(5166), null, "User Two", "path/to/user2.jpg", true, new DateTime(2024, 3, 14, 18, 33, 26, 526, DateTimeKind.Utc).AddTicks(5166) },
                    { 3, "CityThree", new DateTime(2024, 3, 14, 18, 33, 26, 526, DateTimeKind.Utc).AddTicks(5167), null, "User Three", "path/to/user3.jpg", true, new DateTime(2024, 3, 14, 18, 33, 26, 526, DateTimeKind.Utc).AddTicks(5168) },
                    { 4, "CityFour", new DateTime(2024, 3, 14, 18, 33, 26, 526, DateTimeKind.Utc).AddTicks(5168), null, "User Four", "path/to/user4.jpg", true, new DateTime(2024, 3, 14, 18, 33, 26, 526, DateTimeKind.Utc).AddTicks(5169) },
                    { 5, "CityFive", new DateTime(2024, 3, 14, 18, 33, 26, 526, DateTimeKind.Utc).AddTicks(5170), null, "User Five", "path/to/user5.jpg", true, new DateTime(2024, 3, 14, 18, 33, 26, 526, DateTimeKind.Utc).AddTicks(5170) }
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Email", "FullName", "Message", "Phone", "Title" },
                values: new object[,]
                {
                    { 1, "john.doe@example.com", "John Doe", "I have a question about...", "1234567890", "Inquiry" },
                    { 2, "jane.doe@example.com", "Jane Doe", "I need assistance with...", "0987654321", "Support" },
                    { 3, "sam.smith@example.com", "Sam Smith", "Here's what I think...", "1112223333", "Feedback" },
                    { 4, "alex.johnson@example.com", "Alex Johnson", "I want to schedule an appointment...", "4445556666", "Booking" },
                    { 5, "patricia.williams@example.com", "Patricia Williams", "I have a complaint about...", "7778889999", "Complaint" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "DepartmentDetailsId", "Description", "ImagePath", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Heart related specialties", "path/to/image1.jpg", "Cardiology" },
                    { 2, 2, "Brain and nerves specialties", "path/to/image2.jpg", "Neurology" },
                    { 3, 3, "Digestive system specialties", "path/to/image3.jpg", "Gastroenterology" },
                    { 4, 4, "Children's health specialties", "path/to/image4.jpg", "Pediatrics" },
                    { 5, 5, "Bones and joints specialties", "path/to/image5.jpg", "Orthopedics" }
                });

            migrationBuilder.InsertData(
                table: "AppUserRole",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 },
                    { 4, 4, 4 },
                    { 5, 5, 5 }
                });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "AppUserId", "Content", "Tag", "Title" },
                values: new object[,]
                {
                    { 1, 1, "This is the content of the first blog post.", "General", "First Blog Title" },
                    { 2, 2, "This is the content of the second blog post.", "Health", "Second Blog Title" },
                    { 3, 3, "This is the content of the third blog post.", "Update", "Third Blog Title" },
                    { 4, 4, "This is the content of the fourth blog post.", "News", "Fourth Blog Title" },
                    { 5, 5, "This is the content of the fifth blog post.", "General", "Fifth Blog Title" }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "DepartmentId", "DocFacebook", "DocLinkedIn", "DocPinterest", "DocSkype", "DocTitle", "DocX", "IntroductionId", "RoleId", "Speacialty" },
                values: new object[,]
                {
                    { 1, 1, "facebook.com/DocA", "linkedin.com/DocA", "pinterest.com/DocA", "skype.com/DocA", "Dr. A", "twitter.com/DocA", 1, 1, "Specialty A" },
                    { 2, 2, "facebook.com/DocB", "linkedin.com/DocB", "pinterest.com/DocB", "skype.com/DocB", "Dr. B", "twitter.com/DocB", 2, 2, "Specialty B" },
                    { 3, 3, "facebook.com/DocC", "linkedin.com/DocC", "pinterest.com/DocC", "skype.com/DocC", "Dr. C", "twitter.com/DocC", 3, 3, "Specialty C" },
                    { 4, 4, "facebook.com/DocD", "linkedin.com/DocD", "pinterest.com/DocD", "skype.com/DocD", "Dr. D", "twitter.com/DocD", 4, 4, "Specialty D" },
                    { 5, 5, "facebook.com/DocE", "linkedin.com/DocE", "pinterest.com/DocE", "skype.com/DocE", "Dr. E", "twitter.com/DocE", 5, 5, "Specialty E" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Diagnosis", "IsDischarged", "RoleId" },
                values: new object[,]
                {
                    { 1, "Condition A", false, 1 },
                    { 2, "Condition B", true, 2 },
                    { 3, "Condition C", false, 3 },
                    { 4, "Condition D", true, 4 },
                    { 5, "Condition E", false, 5 }
                });

            migrationBuilder.InsertData(
                table: "AppointmentManagers",
                columns: new[] { "Id", "DoctorId", "EndingTime", "PatientId", "StartingTime", "Status" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 1, 20, 10, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2023, 1, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, 2, new DateTime(2023, 2, 20, 10, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2023, 2, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 3, 3, new DateTime(2023, 3, 20, 10, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2023, 3, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 4, 4, new DateTime(2023, 4, 20, 10, 0, 0, 0, DateTimeKind.Unspecified), 4, new DateTime(2023, 4, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 5, 5, new DateTime(2023, 5, 20, 10, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2023, 5, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), 3 }
                });

            migrationBuilder.InsertData(
                table: "BlogComments",
                columns: new[] { "Id", "AppUserId", "BlogId", "Comment", "IsActive" },
                values: new object[,]
                {
                    { 1, 1, 1, "Great article!", true },
                    { 2, 2, 1, "Very informative, thanks!", true },
                    { 3, 3, 2, "Thanks for sharing.", true },
                    { 4, 4, 2, "Interesting read!", true },
                    { 5, 5, 3, "Helpful article.", true }
                });

            migrationBuilder.InsertData(
                table: "BlogImages",
                columns: new[] { "Id", "BlogId", "ImagePath" },
                values: new object[,]
                {
                    { 1, 1, "path/to/blog/image1.jpg" },
                    { 2, 1, "path/to/blog/image2.jpg" },
                    { 3, 2, "path/to/blog/image3.jpg" },
                    { 4, 2, "path/to/blog/image4.jpg" },
                    { 5, 3, "path/to/blog/image5.jpg" }
                });

            migrationBuilder.InsertData(
                table: "DepartmentBlogs",
                columns: new[] { "Id", "BlogId", "DepartmentId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 },
                    { 4, 4, 4 },
                    { 5, 5, 5 }
                });

            migrationBuilder.InsertData(
                table: "DoctorPatients",
                columns: new[] { "Id", "DoctorId", "PatientId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 },
                    { 4, 4, 4 },
                    { 5, 5, 5 }
                });

            migrationBuilder.InsertData(
                table: "Educations",
                columns: new[] { "Id", "DoctorId", "Explanation", "IntroductionId", "University", "Year" },
                values: new object[,]
                {
                    { 1, 1, "Bachelor's Degree in Medicine", null, "University A", "2000-2004" },
                    { 2, 2, "Bachelor's Degree in Neurology", null, "University B", "2001-2005" },
                    { 3, 3, "Bachelor's Degree in Gastroenterology", null, "University C", "2002-2006" },
                    { 4, 4, "Bachelor's Degree in Pediatrics", null, "University D", "2003-2007" },
                    { 5, 5, "Bachelor's Degree in Orthopedics", null, "University E", "2004-2008" }
                });

            migrationBuilder.InsertData(
                table: "Surgeries",
                columns: new[] { "Id", "DepartmentId", "PatientId", "SurgeryDate" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, 2, new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 3, 3, new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 4, 4, new DateTime(2023, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 5, 5, new DateTime(2023, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "WorkingHours",
                columns: new[] { "Id", "AppointmentManagerId", "DayOfWeek", "DoctorId", "EndTime", "IsOffDay", "StartTime" },
                values: new object[,]
                {
                    { 1, null, 1, 1, new TimeSpan(0, 17, 0, 0, 0), false, new TimeSpan(0, 9, 0, 0, 0) },
                    { 2, null, 2, 2, new TimeSpan(0, 18, 0, 0, 0), false, new TimeSpan(0, 10, 0, 0, 0) },
                    { 3, null, 6, 3, new TimeSpan(0, 19, 0, 0, 0), false, new TimeSpan(0, 11, 0, 0, 0) },
                    { 4, null, 0, 4, new TimeSpan(0, 17, 30, 0, 0), false, new TimeSpan(0, 9, 30, 0, 0) },
                    { 5, null, 4, 5, new TimeSpan(0, 16, 0, 0, 0), true, new TimeSpan(0, 8, 0, 0, 0) }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "AppointmentDate", "AppointmentManagerId", "DepartmentId", "DoctorId", "Email", "FullName", "Message", "PatientId", "Phone" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 1, "patient1@example.com", "Patient One", "Looking forward to the appointment", 1, "1234567890" },
                    { 2, new DateTime(2023, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, 2, "patient2@example.com", "Patient Two", "Please confirm the appointment time", 2, "1234567891" },
                    { 3, new DateTime(2023, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3, 3, "patient3@example.com", "Patient Three", "I may need to reschedule", 3, "1234567892" },
                    { 4, new DateTime(2023, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 4, 4, "patient4@example.com", "Patient Four", "Looking for more information", 4, "1234567893" },
                    { 5, new DateTime(2023, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 5, 5, "patient5@example.com", "Patient Five", "Confirming the appointment details", 5, "1234567894" }
                });

            migrationBuilder.InsertData(
                table: "Introductions",
                columns: new[] { "Id", "Description", "DoctorId", "MySkills", "WorkingHourId" },
                values: new object[,]
                {
                    { 1, "Experienced Cardiologist", 1, "Cardiology, Surgery", 1 },
                    { 2, "Expert in Neurology", 2, "Neurology, Patient Care", 2 },
                    { 3, "Gastroenterology Specialist", 3, "Gastroenterology, Diagnostics", 3 },
                    { 4, "Pediatrics Department", 4, "Pediatrics, Child Care", 4 },
                    { 5, "Orthopedics Surgeon", 5, "Orthopedics, Joint Surgery", 5 }
                });

            migrationBuilder.InsertData(
                table: "SurgeryDoctors",
                columns: new[] { "Id", "DoctorId", "SurgeryId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 },
                    { 4, 4, 4 },
                    { 5, 5, 5 }
                });

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
                name: "IX_AppUserRole_RoleId",
                table: "AppUserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserRole_UserId",
                table: "AppUserRole",
                column: "UserId");

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
                name: "IX_Doctors_DepartmentId",
                table: "Doctors",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_RoleId",
                table: "Doctors",
                column: "RoleId");

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
                name: "IX_Patients_RoleId",
                table: "Patients",
                column: "RoleId");

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
                name: "AppUserRole");

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
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "Introductions");

            migrationBuilder.DropTable(
                name: "Surgeries");

            migrationBuilder.DropTable(
                name: "AppUser");

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
                name: "AppRole");
        }
    }
}
