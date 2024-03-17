﻿using HospitalCmsSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Data Source=DESKTOP-0LP7T25\\SQL2022;Initial Catalog=HospitalCmsSystem;Persist Security Info=True;User ID=sa;Password=123;Trusted_Connection=True; TrustServerCertificate=Yes");

            //optionsBuilder.UseSqlServer("Data Source=DESKTOP-U5FQ7NA\\SQL2022;Initial Catalog=HospitalCmsSystem;Persist Security Info=True;User ID=sa;Password=123;Trusted_Connection=True; TrustServerCertificate=Yes");
        }
        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {


        }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<AppointmentManager> AppointmentManagers { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<DepartmentBlog> DepartmentBlogs { get; set; }
        public DbSet<DepartmentDetail> DepartmentDetails { get; set; }
        public DbSet<BlogImage> BlogImages { get; set; }
        public DbSet<BlogComment> BlogComments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<DoctorPatient> DoctorPatients { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Introduction> Introductions { get; set; }
        public DbSet<WorkingHour> WorkingHours { get; set; }
        public DbSet<Surgery> Surgeries { get; set; }
        public DbSet<SurgeryDoctor> SurgeryDoctors { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                 .HasOne(d => d.DepartmentDetails) // Department sınıfındaki navigasyon özelliği
                 .WithOne(dd => dd.Departments) // DepartmentDetail sınıfındaki karşılıklı navigasyon özelliği
                 .HasForeignKey<DepartmentDetail>(dd => dd.DepartmentId); // DepartmentDetail içindeki yabancı anahtar özelliği

            modelBuilder.Entity<Doctor>()
                 .HasOne(d => d.Introduction) // Doctor sınıfındaki navigasyon özelliği
                 .WithOne(i => i.Doctor) // Introduction sınıfındaki navigasyon özelliği
                 .HasForeignKey<Introduction>(i => i.DoctorId); // Introduction içindeki yabancı anahtar

            base.OnModelCreating(modelBuilder);

            //AppUser
            modelBuilder.Entity<AppUser>().HasData(
                new AppUser
                {
                    Id = 1, // Assuming BaseEntity has an Id property
                    FullName = "John Doe",
                    City = "New York",
                    Phone = "123-456-7890",
                    Email = "john.doe@example.com",
                    Username = "johndoe",
                    Password = "password123", // Note: Store hashed passwords in a real application
                    IsActive = true,
                    ImagePath = "path/to/image1.jpg",
                    CreatedAt = new DateTime(2020, 1, 1),
                    UpdatedAt = new DateTime(2020, 1, 1)
                },
                new AppUser
                {
                    Id = 2,
                    FullName = "Jane Smith",
                    City = "Los Angeles",
                    Phone = "098-765-4321",
                    Email = "jane.smith@example.com",
                    Username = "janesmith",
                    Password = "password456",
                    IsActive = true,
                    ImagePath = "path/to/image2.jpg",
                    CreatedAt = new DateTime(2020, 2, 1),
                    UpdatedAt = new DateTime(2020, 2, 1)
                },
                new AppUser
                {
                    Id = 3,
                    FullName = "Alice Johnson",
                    City = "Chicago",
                    Phone = "555-666-7777",
                    Email = "alice.johnson@example.com",
                    Username = "alicejohnson",
                    Password = "password789",
                    IsActive = true,
                    ImagePath = "path/to/image3.jpg",
                    CreatedAt = new DateTime(2020, 3, 1),
                    UpdatedAt = new DateTime(2020, 3, 1)
                },
                new AppUser
                {
                    Id = 4,
                    FullName = "Bob Brown",
                    City = "Houston",
                    Phone = "222-333-4444",
                    Email = "bob.brown@example.com",
                    Username = "bobbrown",
                    Password = "password101",
                    IsActive = true,
                    ImagePath = "path/to/image4.jpg",
                    CreatedAt = new DateTime(2020, 4, 1),
                    UpdatedAt = new DateTime(2020, 4, 1)
                },
                new AppUser
                {
                    Id = 5,
                    FullName = "Charlie Davis",
                    City = "Phoenix",
                    Phone = "999-888-7777",
                    Email = "charlie.davis@example.com",
                    Username = "charliedavis",
                    Password = "password202",
                    IsActive = true,
                    ImagePath = "path/to/image5.jpg",
                    CreatedAt = new DateTime(2020, 5, 1),
                    UpdatedAt = new DateTime(2020, 5, 1)
                }
            );


            // Department
            modelBuilder.Entity<Department>().HasData(
                new { Id = 1, Name = "Cardiology", Description = "Heart related specialties", DepartmentDetailsId = 1, ImagePath = "path/to/image1.jpg" },
                new { Id = 2, Name = "Neurology", Description = "Brain and nerves specialties", DepartmentDetailsId = 2, ImagePath = "path/to/image2.jpg" },
                new { Id = 3, Name = "Gastroenterology", Description = "Digestive system specialties", DepartmentDetailsId = 3, ImagePath = "path/to/image3.jpg" },
                new { Id = 4, Name = "Pediatrics", Description = "Children's health specialties", DepartmentDetailsId = 4, ImagePath = "path/to/image4.jpg" },
                new { Id = 5, Name = "Orthopedics", Description = "Bones and joints specialties", DepartmentDetailsId = 5, ImagePath = "path/to/image5.jpg" }
            );

            // Admin
            modelBuilder.Entity<Admin>().HasData(
                new { Id = 1, Name = "Ahmet", GitHubAcc = "GitHubUser1" },
                new { Id = 2, Name = "Mehmet", GitHubAcc = "GitHubUser2" },
                new { Id = 5, Name = "Hıdır", GitHubAcc = "GitHubUser5" },
                new { Id = 3, Name = "Şevval", GitHubAcc = "GitHubUser3" },
                new { Id = 4, Name = "Uğur", GitHubAcc = "GitHubUser4" }
            );

            // AppRole
            modelBuilder.Entity<AppRole>().HasData(
                new { Id = 1, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow, DeletedAt = (DateTime?)null },
                new { Id = 2, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow, DeletedAt = (DateTime?)null },
                new { Id = 3, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow, DeletedAt = (DateTime?)null },
                new { Id = 4, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow, DeletedAt = (DateTime?)null },
                new { Id = 5, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow, DeletedAt = (DateTime?)null }
            );

            // Contacts
            modelBuilder.Entity<Contact>().HasData(
                new { Id = 1, FullName = "John Doe", Email = "john.doe@example.com", Phone = "1234567890", Title = "Inquiry", Message = "I have a question about..." },
                new { Id = 2, FullName = "Jane Doe", Email = "jane.doe@example.com", Phone = "0987654321", Title = "Support", Message = "I need assistance with..." },
                new { Id = 3, FullName = "Sam Smith", Email = "sam.smith@example.com", Phone = "1112223333", Title = "Feedback", Message = "Here's what I think..." },
                new { Id = 4, FullName = "Alex Johnson", Email = "alex.johnson@example.com", Phone = "4445556666", Title = "Booking", Message = "I want to schedule an appointment..." },
                new { Id = 5, FullName = "Patricia Williams", Email = "patricia.williams@example.com", Phone = "7778889999", Title = "Complaint", Message = "I have a complaint about..." }
            );

            // Patients
            modelBuilder.Entity<Patient>().HasData(
                new { Id = 1, Name = "A", Diagnosis = "Condition A", IsDischarged = false, RoleId = 1 },
                new { Id = 2, Name = "B", Diagnosis = "Condition B", IsDischarged = true, RoleId = 2 },
                new { Id = 3, Name = "C", Diagnosis = "Condition C", IsDischarged = false, RoleId = 3 },
                new { Id = 4, Name = "D", Diagnosis = "Condition D", IsDischarged = true, RoleId = 4 },
                new { Id = 5, Name = "E", Diagnosis = "Condition E", IsDischarged = false, RoleId = 5 }
            );

            // AppUserRole
            modelBuilder.Entity<AppUserRole>().HasData(
                new { Id = 1, UserId = 1, RoleId = 1 },
                new { Id = 2, UserId = 2, RoleId = 2 },
                new { Id = 3, UserId = 3, RoleId = 3 },
                new { Id = 4, UserId = 4, RoleId = 4 },
                new { Id = 5, UserId = 5, RoleId = 5 }
            );
            modelBuilder.Entity<Blog>().HasData(
                 new Blog
                 {
                     Id = 1,
                     AppUserId = 1,
                     Title = "Heart Health 101",
                     Content = "An introductory guide to maintaining a healthy heart.",
                     Tag = "Health",
                     Categories = new List<string> { "Health", "Cardiology", "Wellness" }
                 },
                 new Blog
                 {
                     Id = 2,
                     AppUserId = 2,
                     Title = "Advancements in Neurology",
                     Content = "Exploring recent breakthroughs in neuroscientific research.",
                     Tag = "Science",
                     Categories = new List<string> { "Science", "Neurology", "Research" }
                 },
                 new Blog
                 {
                     Id = 3,
                     AppUserId = 3,
                     Title = "Nutrition for Digestive Health",
                     Content = "Dietary habits to support your gastrointestinal system.",
                     Tag = "Nutrition",
                     Categories = new List<string> { "Nutrition", "Gastroenterology", "Diet" }
                 },
                 new Blog
                 {
                     Id = 4,
                     AppUserId = 4,
                     Title = "Orthopedic Innovations",
                     Content = "The future of musculoskeletal treatments and patient care.",
                     Tag = "Orthopedics",
                     Categories = new List<string> { "Orthopedics", "Innovation", "Care" }
                 },
                 new Blog
                 {
                     Id = 5,
                     AppUserId = 5,
                     Title = "Skincare Routines for All Ages",
                     Content = "Personalized skincare approaches for every stage of life.",
                     Tag = "Dermatology",
                     Categories = new List<string> { "Dermatology", "Skincare", "Lifestyle" }
                 }
             );



            // Doctors
            modelBuilder.Entity<Doctor>().HasData(
                new { Id = 1, Name = "Ahmet", Speacialty = "Specialty A", DepartmentId = 1, RoleId = 1, IntroductionId = 1, DocFacebook = "facebook.com/DocA", DocX = "twitter.com/DocA", DocPinterest = "pinterest.com/DocA", DocSkype = "skype.com/DocA", DocLinkedIn = "linkedin.com/DocA", DocTitle = "Dr. A" },
                new { Id = 2, Name = "Şevval", Speacialty = "Specialty B", DepartmentId = 2, RoleId = 2, IntroductionId = 2, DocFacebook = "facebook.com/DocB", DocX = "twitter.com/DocB", DocPinterest = "pinterest.com/DocB", DocSkype = "skype.com/DocB", DocLinkedIn = "linkedin.com/DocB", DocTitle = "Dr. B" },
                new { Id = 3, Name = "Mehmet", Speacialty = "Specialty C", DepartmentId = 3, RoleId = 3, IntroductionId = 3, DocFacebook = "facebook.com/DocC", DocX = "twitter.com/DocC", DocPinterest = "pinterest.com/DocC", DocSkype = "skype.com/DocC", DocLinkedIn = "linkedin.com/DocC", DocTitle = "Dr. C" },
                new { Id = 4, Name = "Uğur", Speacialty = "Specialty D", DepartmentId = 4, RoleId = 4, IntroductionId = 4, DocFacebook = "facebook.com/DocD", DocX = "twitter.com/DocD", DocPinterest = "pinterest.com/DocD", DocSkype = "skype.com/DocD", DocLinkedIn = "linkedin.com/DocD", DocTitle = "Dr. D" },
                new { Id = 5, Name = "Hıdır", Speacialty = "Specialty E", DepartmentId = 5, RoleId = 5, IntroductionId = 5, DocFacebook = "facebook.com/DocE", DocX = "twitter.com/DocE", DocPinterest = "pinterest.com/DocE", DocSkype = "skype.com/DocE", DocLinkedIn = "linkedin.com/DocE", DocTitle = "Dr. E" }
            );
            // Surgeries
            modelBuilder.Entity<Surgery>().HasData(
                new { Id = 1, PatientId = 1, DepartmentId = 1, SurgeryDate = new DateTime(2023, 1, 15) },
                new { Id = 2, PatientId = 2, DepartmentId = 2, SurgeryDate = new DateTime(2023, 2, 15) },
                new { Id = 3, PatientId = 3, DepartmentId = 3, SurgeryDate = new DateTime(2023, 3, 15) },
                new { Id = 4, PatientId = 4, DepartmentId = 4, SurgeryDate = new DateTime(2023, 4, 15) },
                new { Id = 5, PatientId = 5, DepartmentId = 5, SurgeryDate = new DateTime(2023, 5, 15) }
            );

            // BlogComments
            modelBuilder.Entity<BlogComment>().HasData(
                new { Id = 1, BlogId = 1, Comment = "Great article!", IsActive = true, AppUserId = 1 },
                new { Id = 2, BlogId = 1, Comment = "Very informative, thanks!", IsActive = true, AppUserId = 2 },
                new { Id = 3, BlogId = 2, Comment = "Thanks for sharing.", IsActive = true, AppUserId = 3 },
                new { Id = 4, BlogId = 2, Comment = "Interesting read!", IsActive = true, AppUserId = 4 },
                new { Id = 5, BlogId = 3, Comment = "Helpful article.", IsActive = true, AppUserId = 5 }
            );

            // BlogImages
            modelBuilder.Entity<BlogImage>().HasData(
                new { Id = 1, BlogId = 1, ImagePath = "path/to/blog/image1.jpg" },
                new { Id = 2, BlogId = 1, ImagePath = "path/to/blog/image2.jpg" },
                new { Id = 3, BlogId = 2, ImagePath = "path/to/blog/image3.jpg" },
                new { Id = 4, BlogId = 2, ImagePath = "path/to/blog/image4.jpg" },
                new { Id = 5, BlogId = 3, ImagePath = "path/to/blog/image5.jpg" }
            );

            // DepartmentBlogs
            modelBuilder.Entity<DepartmentBlog>().HasData(
                new { Id = 1, DepartmentId = 1, BlogId = 1 },
                new { Id = 2, DepartmentId = 2, BlogId = 2 },
                new { Id = 3, DepartmentId = 3, BlogId = 3 },
                new { Id = 4, DepartmentId = 4, BlogId = 4 },
                new { Id = 5, DepartmentId = 5, BlogId = 5 }
            );

            // AppointmentManagers
            modelBuilder.Entity<AppointmentManager>().HasData(
                new { Id = 1, DoctorId = 1, PatientId = 1, StartingTime = new DateTime(2023, 1, 20, 9, 0, 0), EndingTime = new DateTime(2023, 1, 20, 10, 0, 0), Status = AppointmentStatus.Pending },
                new { Id = 2, DoctorId = 2, PatientId = 2, StartingTime = new DateTime(2023, 2, 20, 9, 0, 0), EndingTime = new DateTime(2023, 2, 20, 10, 0, 0), Status = AppointmentStatus.Cancelled },
                new { Id = 3, DoctorId = 3, PatientId = 3, StartingTime = new DateTime(2023, 3, 20, 9, 0, 0), EndingTime = new DateTime(2023, 3, 20, 10, 0, 0), Status = AppointmentStatus.Pending },
                new { Id = 4, DoctorId = 4, PatientId = 4, StartingTime = new DateTime(2023, 4, 20, 9, 0, 0), EndingTime = new DateTime(2023, 4, 20, 10, 0, 0), Status = AppointmentStatus.Confirmed },
                new { Id = 5, DoctorId = 5, PatientId = 5, StartingTime = new DateTime(2023, 5, 20, 9, 0, 0), EndingTime = new DateTime(2023, 5, 20, 10, 0, 0), Status = AppointmentStatus.Completed }
            );

            // DoctorPatients
            modelBuilder.Entity<DoctorPatient>().HasData(
                new { Id = 1, DoctorId = 1, PatientId = 1 },
                new { Id = 2, DoctorId = 2, PatientId = 2 },
                new { Id = 3, DoctorId = 3, PatientId = 3 },
                new { Id = 4, DoctorId = 4, PatientId = 4 },
                new { Id = 5, DoctorId = 5, PatientId = 5 }
            );

            // SurgeryDoctors
            modelBuilder.Entity<SurgeryDoctor>().HasData(
                new { Id = 1, DoctorId = 1, SurgeryId = 1 },
                new { Id = 2, DoctorId = 2, SurgeryId = 2 },
                new { Id = 3, DoctorId = 3, SurgeryId = 3 },
                new { Id = 4, DoctorId = 4, SurgeryId = 4 },
                new { Id = 5, DoctorId = 5, SurgeryId = 5 }
            );

            // Appointments
            modelBuilder.Entity<Appointment>().HasData(
                new { Id = 1, DepartmentId = 1, DoctorId = 1, PatientId = 1, Email = "patient1@example.com", FullName = "Patient One", Phone = "1234567890", Message = "Looking forward to the appointment", AppointmentDate = new DateTime(2023, 1, 22), AppointmentManagerId = 1 },
                new { Id = 2, DepartmentId = 2, DoctorId = 2, PatientId = 2, Email = "patient2@example.com", FullName = "Patient Two", Phone = "1234567891", Message = "Please confirm the appointment time", AppointmentDate = new DateTime(2023, 2, 22), AppointmentManagerId = 2 },
                new { Id = 3, DepartmentId = 3, DoctorId = 3, PatientId = 3, Email = "patient3@example.com", FullName = "Patient Three", Phone = "1234567892", Message = "I may need to reschedule", AppointmentDate = new DateTime(2023, 3, 22), AppointmentManagerId = 3 },
                new { Id = 4, DepartmentId = 4, DoctorId = 4, PatientId = 4, Email = "patient4@example.com", FullName = "Patient Four", Phone = "1234567893", Message = "Looking for more information", AppointmentDate = new DateTime(2023, 4, 22), AppointmentManagerId = 4 },
                new { Id = 5, DepartmentId = 5, DoctorId = 5, PatientId = 5, Email = "patient5@example.com", FullName = "Patient Five", Phone = "1234567894", Message = "Confirming the appointment details", AppointmentDate = new DateTime(2023, 5, 22), AppointmentManagerId = 5 }
            );

            // WorkingHours
            modelBuilder.Entity<WorkingHour>().HasData(
                new { Id = 1, DoctorId = 1, DayOfWeek = DayOfWeek.Monday, StartTime = new TimeSpan(9, 0, 0), EndTime = new TimeSpan(17, 0, 0), IsOffDay = false },
                new { Id = 2, DoctorId = 2, DayOfWeek = DayOfWeek.Tuesday, StartTime = new TimeSpan(10, 0, 0), EndTime = new TimeSpan(18, 0, 0), IsOffDay = false },
                new { Id = 3, DoctorId = 3, DayOfWeek = DayOfWeek.Saturday, StartTime = new TimeSpan(11, 0, 0), EndTime = new TimeSpan(19, 0, 0), IsOffDay = false },
                new { Id = 4, DoctorId = 4, DayOfWeek = DayOfWeek.Sunday, StartTime = new TimeSpan(9, 30, 0), EndTime = new TimeSpan(17, 30, 0), IsOffDay = false },
                new { Id = 5, DoctorId = 5, DayOfWeek = DayOfWeek.Thursday, StartTime = new TimeSpan(8, 0, 0), EndTime = new TimeSpan(16, 0, 0), IsOffDay = true }
            );

            // Introductions
            modelBuilder.Entity<Introduction>().HasData(
                new { Id = 1, DoctorId = 1, Description = "Experienced Cardiologist", MySkills = "Cardiology, Surgery", WorkingHourId = 1 },
                new { Id = 2, DoctorId = 2, Description = "Expert in Neurology", MySkills = "Neurology, Patient Care", WorkingHourId = 2 },
                new { Id = 3, DoctorId = 3, Description = "Gastroenterology Specialist", MySkills = "Gastroenterology, Diagnostics", WorkingHourId = 3 },
                new { Id = 4, DoctorId = 4, Description = "Pediatrics Department", MySkills = "Pediatrics, Child Care", WorkingHourId = 4 },
                new { Id = 5, DoctorId = 5, Description = "Orthopedics Surgeon", MySkills = "Orthopedics, Joint Surgery", WorkingHourId = 5 }
            );

            // Educations
            modelBuilder.Entity<Education>().HasData(
                new { Id = 1, Year = "2000-2004", University = "University A", Explanation = "Bachelor's Degree in Medicine", DoctorId = 1 },
                new { Id = 2, Year = "2001-2005", University = "University B", Explanation = "Bachelor's Degree in Neurology", DoctorId = 2 },
                new { Id = 3, Year = "2002-2006", University = "University C", Explanation = "Bachelor's Degree in Gastroenterology", DoctorId = 3 },
                new { Id = 4, Year = "2003-2007", University = "University D", Explanation = "Bachelor's Degree in Pediatrics", DoctorId = 4 },
                new { Id = 5, Year = "2004-2008", University = "University E", Explanation = "Bachelor's Degree in Orthopedics", DoctorId = 5 }
            );

            modelBuilder.Entity<DepartmentDetail>().HasData(
                new DepartmentDetail
                {
                    Id = 1,
                    Title = "About Cardiology",
                    DescriptionShort = "Short description of Cardiology",
                    DescriptionLong = "Long and detailed description of Cardiology, its services, and treatments.",
                    DepartmentId = 1
                },
                new DepartmentDetail
                {
                    Id = 2,
                    Title = "About Neurology",
                    DescriptionShort = "Short description of Neurology",
                    DescriptionLong = "Long and detailed description of Neurology, its services, and treatments.",
                    DepartmentId = 2
                },
                new DepartmentDetail
                {
                    Id = 3,
                    Title = "About Gastroenterology",
                    DescriptionShort = "Short description of Gastroenterology",
                    DescriptionLong = "Long and detailed description of Gastroenterology, its services, and treatments.",
                    DepartmentId = 3
                },
                new DepartmentDetail
                {
                    Id = 4,
                    Title = "About Orthopedics",
                    DescriptionShort = "Short description of Orthopedics",
                    DescriptionLong = "Long and detailed description of Orthopedics, its services, and treatments.",
                    DepartmentId = 4
                },
                new DepartmentDetail
                {
                    Id = 5,
                    Title = "About Dermatology",
                    DescriptionShort = "Short description of Dermatology",
                    DescriptionLong = "Long and detailed description of Dermatology, its services, and treatments.",
                    DepartmentId = 5
                }
            );

        }
    }

}
