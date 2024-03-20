using HospitalCmsSystem.Domain.Entities;
using HospitalCmsSystem.Domain.Entities.BaseEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Persistence.Context
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, int>

    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{

        //    optionsBuilder.UseSqlServer("Data Source=DESKTOP-0LP7T25\\SQL2022;Initial Catalog=HospitalCmsSystem;Persist Security Info=True;User ID=sa;Password=123;Trusted_Connection=True; TrustServerCertificate=Yes");//pc sevval

        //    //optionsBuilder.UseSqlServer("Data Source=DESKTOP-U5FQ7NA\\SQL2022;Initial Catalog=HospitalCmsSystem;Persist Security Info=True;User ID=sa;Password=123;Trusted_Connection=True; TrustServerCertificate=Yes");//pc ugur
        //}
        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        // DbSet tanımlamaları
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<AppointmentManager> AppointmentManagers { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogComment> BlogComments { get; set; }
        public DbSet<BlogImage> BlogImages { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<DepartmentBlog> DepartmentBlogs { get; set; }
        public DbSet<DepartmentDetail> DepartmentDetails { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<DoctorPatient> DoctorPatients { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Introduction> Introductions { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Surgery> Surgeries { get; set; }
        public DbSet<SurgeryDoctor> SurgeryDoctors { get; set; }
        public DbSet<WorkingHour> WorkingHours { get; set; }
        //public DbSet<AppUser> AppUsers { get; set; }
        public override int SaveChanges()
        {
            UpdateTimeStamps();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateTimeStamps();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void UpdateTimeStamps()
        {
            var entries = ChangeTracker.Entries<BaseEntity>().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedAt = DateTime.UtcNow;
                }

                if (entry.State == EntityState.Deleted)
                {
                    entry.State = EntityState.Modified;
                    entry.Entity.DeletedAt = DateTime.UtcNow;
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Soft delete için global query filter ekleyin
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType))
                {
                    var parameter = Expression.Parameter(entityType.ClrType, "e");
                    var body = Expression.Equal(Expression.Property(parameter, nameof(BaseEntity.DeletedAt)), Expression.Constant(null));
                    var lambda = Expression.Lambda(body, parameter);
                    modelBuilder.Entity(entityType.ClrType).HasQueryFilter(lambda);
                }
            }
            base.OnModelCreating(modelBuilder);
            // Admin için seed data
            modelBuilder.Entity<Department>()
               .HasOne(d => d.DepartmentDetails)
               .WithOne(dd => dd.Departments)
               .HasForeignKey<DepartmentDetail>(dd => dd.DepartmentId); // DepartmentDetail, yabancı anahtarı içeren bağımlı taraftır
            modelBuilder.Entity<Doctor>()
               .HasOne(d => d.Introduction) // Doctor entity'si Introduction'a sahip
               .WithOne(i => i.Doctor) // Introduction entity'si Doctor'a sahip
               .HasForeignKey<Introduction>(i => i.DoctorId); // Introduction, Foreign Key olarak DoctorId'yi içeriyor ve bağımlı taraf budur.
            modelBuilder.Entity<Admin>().HasData(
                new Admin { Id = 1, Name = "Uğur Kılıç", GitHubAcc = "https://github.com/klcuur", AppUserId = 1 },
                new Admin { Id = 2, Name = "Şevval Yıldırım", GitHubAcc = "https://github.com/sevvalyldrrm", AppUserId = 2 },
                new Admin { Id = 3, Name = "Ogün Özkaya", GitHubAcc = "https://github.com/o-ozkaya", AppUserId = 3 },
                new Admin { Id = 4, Name = "Hıdır Çelikel", GitHubAcc = "https://github.com/HdrClkl", AppUserId = 4 },
                new Admin { Id = 5, Name = "Admin Five", GitHubAcc = "github.com/adminfive", AppUserId = 5 }
                );
            //modelBuilder.Entity<AppRole>().HasData(
            //    new AppRole { Id = 1, Name = "Administrator", NormalizedName = "ADMINISTRATOR" },
            //    new AppRole { Id = 2, Name = "Doctor", NormalizedName = "DOCTOR" },
            //    new AppRole { Id = 3, Name = "Nurse", NormalizedName = "NURSE" },
            //    new AppRole { Id = 4, Name = "Receptionist", NormalizedName = "RECEPTIONIST" },
            //    new AppRole { Id = 5, Name = "Patient", NormalizedName = "PATIENT" }
            //    );

            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(
                new AppUser
                {
                    Id = 10,
                    UserName = "user1",
                    NormalizedUserName = "USER1",
                    Email = "user1@example.com",
                    NormalizedEmail = "USER1@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "User1234!"),
                    SecurityStamp = string.Empty,
                    FullName = "User One",
                    City = "Istanbul",
                    IsActive = true,
                    ImagePath = "path/to/image1.jpg"
                },
                new AppUser
                {
                    Id = 9,
                    UserName = "user2",
                    NormalizedUserName = "USER2",
                    Email = "user2@example.com",
                    NormalizedEmail = "USER2@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "User1234!"),
                    SecurityStamp = string.Empty,
                    FullName = "User Two",
                    City = "Ankara",
                    IsActive = true,
                    ImagePath = "path/to/image2.jpg"
                }, new AppUser
                {
                    Id = 8,
                    UserName = "user3",
                    NormalizedUserName = "USER3",
                    Email = "user3@example.com",
                    NormalizedEmail = "USER3@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "User1234!"),
                    SecurityStamp = string.Empty,
                    FullName = "User Three",
                    City = "Izmir",
                    IsActive = true,
                    ImagePath = "path/to/image3.jpg"
                },
                new AppUser
                {
                    Id = 7,
                    UserName = "user4",
                    NormalizedUserName = "USER4",
                    Email = "user4@example.com",
                    NormalizedEmail = "USER4@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "User1234!"),
                    SecurityStamp = string.Empty,
                    FullName = "User Four",
                    City = "Bursa",
                    IsActive = true,
                    ImagePath = "path/to/image4.jpg"
                },
                new AppUser
                {
                    Id = 6,
                    UserName = "user5",
                    NormalizedUserName = "USER5",
                    Email = "user5@example.com",
                    NormalizedEmail = "USER5@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "User1234!"),
                    SecurityStamp = string.Empty,
                    FullName = "User Five",
                    City = "Antalya",
                    IsActive = true,
                    ImagePath = "path/to/image5.jpg"
                });
               modelBuilder.Entity<Appointment>().HasData(
               new Appointment
               {
                   Id = 1,
                   DepartmentId = 1,
                   DoctorId = 11,
                   PatientId = 10,
                   Email = "patient1@example.com",
                   FullName = "Patient One",
                   Phone = "1234567890",
                   Message = "I need a general check-up.",
                   AppointmentDate = new DateTime(2024, 3, 21, 10, 0, 0),
                   AppointmentManagerId = 1
               },
               new Appointment
               {
                   Id = 2,
                   DepartmentId = 2,
                   DoctorId = 12,
                   PatientId = 9,
                   Email = "patient2@example.com",
                   FullName = "Patient Two",
                   Phone = "0987654321",
                   Message = "Consultation about my recent diagnosis.",
                   AppointmentDate = new DateTime(2024, 3, 22, 14, 0, 0),
                   AppointmentManagerId = 2
               },
               new Appointment
               {
                   Id = 3,
                   DepartmentId = 3,
                   DoctorId = 13,
                   PatientId = 8,
                   Email = "patient3@example.com",
                   FullName = "Patient Three",
                   Phone = "1231231234",
                   Message = "Follow-up on the previous treatment.",
                   AppointmentDate = new DateTime(2024, 3, 23, 16, 0, 0),
                   AppointmentManagerId = 1
               },
               new Appointment
               {
                   Id = 4,
                   DepartmentId = 4,
                   DoctorId = 14,
                   PatientId = 7,
                   Email = "patient4@example.com",
                   FullName = "Patient Four",
                   Phone = "3213214321",
                   Message = "Emergency consultation required.",
                   AppointmentDate = new DateTime(2024, 3, 24, 9, 0, 0),
                   AppointmentManagerId = 2
               },
               new Appointment
               {
                   Id = 5,
                   DepartmentId = 5,
                   DoctorId = 15,
                   PatientId = 6,
                   Email = "patient5@example.com",
                   FullName = "Patient Five",
                   Phone = "4564564567",
                   Message = "Discussion about surgery options.",
                   AppointmentDate = new DateTime(2024, 3, 25, 11, 30, 0),
                   AppointmentManagerId = 1
               }
           );
            modelBuilder.Entity<AppointmentManager>().HasData(
               new AppointmentManager
               {
                   Id = 1,
                   DoctorId = 11,
                   PatientId = 10,
                   StartingTime = new DateTime(2024, 3, 21, 10, 0, 0),
                   EndingTime = new DateTime(2024, 3, 21, 11, 0, 0),
                   Status = AppointmentStatus.Pending,
               },
               new AppointmentManager
               {
                   Id = 2,
                   DoctorId = 12,
                   PatientId = 9,
                   StartingTime = new DateTime(2024, 3, 22, 14, 0, 0),
                   EndingTime = new DateTime(2024, 3, 22, 15, 0, 0),
                   Status = AppointmentStatus.Confirmed,
               },
               new AppointmentManager
               {
                   Id = 3,
                   DoctorId = 13,
                   PatientId = 8,
                   StartingTime = new DateTime(2024, 3, 23, 16, 0, 0),
                   EndingTime = new DateTime(2024, 3, 23, 17, 0, 0),
                   Status = AppointmentStatus.Completed,
               },
               new AppointmentManager
               {
                   Id = 4,
                   DoctorId = 14,
                   PatientId = 7,
                   StartingTime = new DateTime(2024, 3, 24, 9, 0, 0),
                   EndingTime = new DateTime(2024, 3, 24, 10, 0, 0),
                   Status = AppointmentStatus.Cancelled,
               },
               new AppointmentManager
               {
                   Id = 5,
                   DoctorId = 15,
                   PatientId = 6,
                   StartingTime = new DateTime(2024, 3, 25, 11, 30, 0),
                   EndingTime = new DateTime(2024, 3, 25, 12, 30, 0),
                   Status = AppointmentStatus.Pending,
               }
           );
            modelBuilder.Entity<AppUser>().HasData(
               new AppUser
               {
                   Id = 1,
                   UserName = "user6",
                   NormalizedUserName = "USER6",
                   Email = "user1@example.com",
                   NormalizedEmail = "USER1@EXAMPLE.COM",
                   EmailConfirmed = true,
                   PasswordHash = "HashForPassword1", // Örnek hash değeri, gerçek hash ile değiştirilmelidir
                   SecurityStamp = Guid.NewGuid().ToString("D")
               },
               new AppUser
               {
                   Id = 2,
                   UserName = "user7",
                   NormalizedUserName = "USER7",
                   Email = "user2@example.com",
                   NormalizedEmail = "USER2@EXAMPLE.COM",
                   EmailConfirmed = true,
                   PasswordHash = "HashForPassword2",
                   SecurityStamp = Guid.NewGuid().ToString("D")
               },
               new AppUser
               {
                   Id = 3,
                   UserName = "user8",
                   NormalizedUserName = "USER8",
                   Email = "user3@example.com",
                   NormalizedEmail = "USER3@EXAMPLE.COM",
                   EmailConfirmed = true,
                   PasswordHash = "HashForPassword3",
                   SecurityStamp = Guid.NewGuid().ToString("D")
               },
               new AppUser
               {
                   Id = 4,
                   UserName = "user9",
                   NormalizedUserName = "USER9",
                   Email = "user4@example.com",
                   NormalizedEmail = "USER4@EXAMPLE.COM",
                   EmailConfirmed = true,
                   PasswordHash = "HashForPassword4",
                   SecurityStamp = Guid.NewGuid().ToString("D")
               },
               new AppUser
               {
                   Id = 5,
                   UserName = "user10",
                   NormalizedUserName = "USER10",
                   Email = "user5@example.com",
                   NormalizedEmail = "USER5@EXAMPLE.COM",
                   EmailConfirmed = true,
                   PasswordHash = "HashForPassword5",
                   SecurityStamp = Guid.NewGuid().ToString("D")
               }
           );
            modelBuilder.Entity<Blog>().HasData(
                new Blog
                {
                    Id = 1,
                    AppUserId = 1, // Varsayılan bir AppUser ID'si
                    Title = "Latest Health Tips",
                    Content = "Some valuable health tips content...",
                    CreatedAt = DateTime.UtcNow
                   
                },
                new Blog
                {
                    Id = 2,
                    AppUserId = 1,
                    Title = "Understanding Chronic Diseases",
                    Content = "Deep dive into chronic diseases...",
                    CreatedAt = DateTime.UtcNow
                },
                new Blog
                {
                    Id = 3,
                    AppUserId = 2,
                    Title = "Preventive Healthcare",
                    Content = "How to stay ahead of potential health issues...",
                    CreatedAt = DateTime.UtcNow
                },
                new Blog
                {
                    Id = 4,
                    AppUserId = 2,
                    Title = "Nutrition and Health",
                    Content = "Exploring the relationship between diet and wellness...",
                    CreatedAt = DateTime.UtcNow
                },
                new Blog
                {
                    Id = 5,
                    AppUserId = 3,
                    Title = "Fitness Fundamentals",
                    Content = "Essential tips for maintaining a fit lifestyle...",
                    CreatedAt = DateTime.UtcNow
                }
            );
            modelBuilder.Entity<BlogComment>().HasData(
               new BlogComment
               {
                   Id = 1,
                   BlogId = 1, // Bu, var olan bir Blog ID'sini referans almalıdır
                   Comment = "This is a very insightful article. Thank you for sharing!",
                   IsActive = true,
                   CreatedAt = DateTime.UtcNow,
                   AppUserId = 1 // Varsayılan bir AppUser ID'si
               },
               new BlogComment
               {
                   Id = 2,
                   BlogId = 1,
                   Comment = "I appreciate the depth of this post. Looking forward to more.",
                   IsActive = true,
                   CreatedAt = DateTime.UtcNow,
                   AppUserId = 2
               },
               new BlogComment
               {
                   Id = 3,
                   BlogId = 2,
                   Comment = "Can you provide more information on this subject?",
                   IsActive = true,
                   CreatedAt = DateTime.UtcNow,
                   AppUserId = 3
               },
               new BlogComment
               {
                   Id = 4,
                   BlogId = 2,
                   Comment = "I disagree with some points here, but it's a good read overall.",
                   IsActive = true,
                   CreatedAt = DateTime.UtcNow,
                   AppUserId = 4
               },
               new BlogComment
               {
                   Id = 5,
                   BlogId = 3,
                   Comment = "How can I get in touch with the author for further questions?",
                   IsActive = true,
                   CreatedAt = DateTime.UtcNow,
                   AppUserId = 5
               }
           );
            modelBuilder.Entity<BlogImage>().HasData(
               new BlogImage
               {
                   Id = 1,
                   BlogId = 1, // Mevcut bir Blog ID'si referans alınmalıdır
                   ImagePath = "images/blog1.jpg",
                   CreatedAt = DateTime.UtcNow
               },
               new BlogImage
               {
                   Id = 2,
                   BlogId = 1,
                   ImagePath = "images/blog2.jpg",
                   CreatedAt = DateTime.UtcNow
               },
               new BlogImage
               {
                   Id = 3,
                   BlogId = 2,
                   ImagePath = "images/blog3.jpg",
                   CreatedAt = DateTime.UtcNow
               },
               new BlogImage
               {
                   Id = 4,
                   BlogId = 2,
                   ImagePath = "images/blog4.jpg",
                   CreatedAt = DateTime.UtcNow
               },
               new BlogImage
               {
                   Id = 5,
                   BlogId = 3,
                   ImagePath = "images/blog5.jpg",
                   CreatedAt = DateTime.UtcNow
               }
            );
             modelBuilder.Entity<Contact>().HasData(
                    new Contact { Id = 1, FullName = "John Doe", Email = "john.doe@example.com", Phone = "123-456-7890", Title = "Inquiry", Message = "I have a question about...", CreatedAt = DateTime.UtcNow },
                    new Contact { Id = 2, FullName = "Jane Smith", Email = "jane.smith@example.com", Phone = "098-765-4321", Title = "Support", Message = "I need assistance with...", CreatedAt = DateTime.UtcNow },
                    new Contact { Id = 3, FullName = "Chris Johnson", Email = "chris.johnson@example.com", Phone = "555-123-4567", Title = "Feedback", Message = "Here's what I think...", CreatedAt = DateTime.UtcNow },
                    new Contact { Id = 4, FullName = "Patricia Brown", Email = "patricia.brown@example.com", Phone = "666-789-1234", Title = "Appointment", Message = "I would like to schedule a visit...", CreatedAt = DateTime.UtcNow },
                    new Contact { Id = 5, FullName = "Sam Walker", Email = "sam.walker@example.com", Phone = "555-678-1234", Title = "Other", Message = "I have another type of question...", CreatedAt = DateTime.UtcNow }
              );
            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, Name = "Cardiology", Description = "Heart related services", DepartmentDetailsId = 1, CreatedAt = DateTime.UtcNow },
                new Department { Id = 2, Name = "Neurology", Description = "Brain and nervous system services", DepartmentDetailsId = 2, CreatedAt = DateTime.UtcNow },
                new Department { Id = 3, Name = "Oncology", Description = "Cancer treatment services", DepartmentDetailsId = 3, CreatedAt = DateTime.UtcNow },
                new Department { Id = 4, Name = "Pediatrics", Description = "Medical care for children", DepartmentDetailsId = 4, CreatedAt = DateTime.UtcNow },
                new Department { Id = 5, Name = "Orthopedics", Description = "Musculoskeletal system services", DepartmentDetailsId = 5, CreatedAt = DateTime.UtcNow }
            );
            modelBuilder.Entity<DepartmentBlog>().HasData(
                new DepartmentBlog { Id = 1, DepartmentId = 1, BlogId = 1, CreatedAt = DateTime.UtcNow },
                new DepartmentBlog { Id = 2, DepartmentId = 1, BlogId = 2, CreatedAt = DateTime.UtcNow },
                new DepartmentBlog { Id = 3, DepartmentId = 2, BlogId = 3, CreatedAt = DateTime.UtcNow },
                new DepartmentBlog { Id = 4, DepartmentId = 2, BlogId = 4, CreatedAt = DateTime.UtcNow },
                new DepartmentBlog { Id = 5, DepartmentId = 3, BlogId = 5, CreatedAt = DateTime.UtcNow }
            );
            modelBuilder.Entity<DepartmentDetail>().HasData(
                new DepartmentDetail { Id = 1, Title = "About Cardiology", DescriptionShort = "Short description of Cardiology", DescriptionLong = "Long description of Cardiology", DepartmentId = 1, CreatedAt = DateTime.UtcNow },
                new DepartmentDetail { Id = 2, Title = "About Neurology", DescriptionShort = "Short description of Neurology", DescriptionLong = "Long description of Neurology", DepartmentId = 2, CreatedAt = DateTime.UtcNow },
                new DepartmentDetail { Id = 3, Title = "About Oncology", DescriptionShort = "Short description of Oncology", DescriptionLong = "Long description of Oncology", DepartmentId = 3, CreatedAt = DateTime.UtcNow },
                new DepartmentDetail { Id = 4, Title = "About Pediatrics", DescriptionShort = "Short description of Pediatrics", DescriptionLong = "Long description of Pediatrics", DepartmentId = 4, CreatedAt = DateTime.UtcNow },
                new DepartmentDetail { Id = 5, Title = "About Orthopedics", DescriptionShort = "Short description of Orthopedics", DescriptionLong = "Long description of Orthopedics", DepartmentId = 5, CreatedAt = DateTime.UtcNow }
            );
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { Id = 11, Name = "Dr. Emily White", Specialty = "Cardiology", DepartmentId = 1, AppUserId = 6, CreatedAt = DateTime.UtcNow },
                new Doctor { Id = 12, Name = "Dr. John Carter", Specialty = "Neurology", DepartmentId = 2, AppUserId = 7, CreatedAt = DateTime.UtcNow },
                new Doctor { Id = 13, Name = "Dr. Clara Oswald", Specialty = "Oncology", DepartmentId = 3, AppUserId = 8, CreatedAt = DateTime.UtcNow },
                new Doctor { Id = 14, Name = "Dr. Derek Shepherd", Specialty = "Orthopedics", DepartmentId = 5, AppUserId = 9, CreatedAt = DateTime.UtcNow },
                new Doctor { Id = 15, Name = "Dr. Meredith Grey", Specialty = "General Surgery", DepartmentId = 4, AppUserId = 10, CreatedAt = DateTime.UtcNow }
            );
            modelBuilder.Entity<DoctorPatient>().HasData(
                new DoctorPatient { Id = 1, DoctorId = 11, PatientId = 6, CreatedAt = DateTime.UtcNow },
                new DoctorPatient { Id = 2, DoctorId = 12, PatientId = 7, CreatedAt = DateTime.UtcNow },
                new DoctorPatient { Id = 3, DoctorId = 13, PatientId = 8, CreatedAt = DateTime.UtcNow },
                new DoctorPatient { Id = 4, DoctorId = 14, PatientId = 9, CreatedAt = DateTime.UtcNow },
                new DoctorPatient { Id = 5, DoctorId = 15, PatientId = 10, CreatedAt = DateTime.UtcNow }
            );
            modelBuilder.Entity<Education>().HasData(
                new Education { Id = 1, Year = "2000 - 2004", University = "Harvard University", DoctorId = 11, CreatedAt = DateTime.UtcNow },
                new Education { Id = 2, Year = "2002 - 2006", University = "Johns Hopkins University", DoctorId = 12, CreatedAt = DateTime.UtcNow },
                new Education { Id = 3, Year = "2001 - 2005", University = "Stanford University",  DoctorId = 13, CreatedAt = DateTime.UtcNow },
                new Education { Id = 4, Year = "2003 - 2007", University = "University of California", DoctorId = 14, CreatedAt = DateTime.UtcNow },
                new Education { Id = 5, Year = "2004 - 2008", University = "Massachusetts Institute of Technology",  DoctorId = 15, CreatedAt = DateTime.UtcNow }
            );
            modelBuilder.Entity<Introduction>().HasData(
                new Introduction { Id = 1,WorkingHourId = 1, Description = "Expert in Cardiology with 20 years of experience.", DoctorId = 11, CreatedAt = DateTime.UtcNow },
                new Introduction { Id = 2,WorkingHourId = 1, Description = "Renowned Neurologist and published author.", DoctorId = 12, CreatedAt = DateTime.UtcNow },
                new Introduction { Id = 3, WorkingHourId = 1, Description = "Leading Oncologist with numerous successful treatments.", DoctorId = 13, CreatedAt = DateTime.UtcNow },
                new Introduction { Id = 4,WorkingHourId = 1,Description = "Orthopedic Surgeon with a focus on sports injuries.", DoctorId = 14, CreatedAt = DateTime.UtcNow },
                new Introduction { Id = 5,WorkingHourId = 1, Description = "Award-winning General Surgeon with a passion for teaching.", DoctorId = 15, CreatedAt = DateTime.UtcNow }
            );
            modelBuilder.Entity<Patient>().HasData(
                new Patient { Id = 6, Name = "Michael Scott", Diagnosis = "Acute Stress Reaction", IsDischarged = false, AppUserId = 6, CreatedAt = DateTime.UtcNow },
                new Patient { Id = 7, Name = "Pam Beesly", Diagnosis = "Common Cold", IsDischarged = true, AppUserId = 7, CreatedAt = DateTime.UtcNow },
                new Patient { Id = 8, Name = "Jim Halpert", Diagnosis = "Sprained Ankle", IsDischarged = false, AppUserId = 8, CreatedAt = DateTime.UtcNow },
                new Patient { Id = 9, Name = "Dwight Schrute", Diagnosis = "Concussion", IsDischarged = false, AppUserId = 9, CreatedAt = DateTime.UtcNow },
                new Patient { Id = 10, Name = "Angela Martin", Diagnosis = "Hypertension", IsDischarged = true, AppUserId = 10, CreatedAt = DateTime.UtcNow }
            );
            modelBuilder.Entity<Surgery>().HasData(
                new Surgery { Id = 1, PatientId = 6, DepartmentId = 1, SurgeryDate = DateTime.UtcNow.AddDays(30), CreatedAt = DateTime.UtcNow },
                new Surgery { Id = 2, PatientId = 7, DepartmentId = 2, SurgeryDate = DateTime.UtcNow.AddDays(60), CreatedAt = DateTime.UtcNow },
                new Surgery { Id = 3, PatientId = 8, DepartmentId = 3, SurgeryDate = DateTime.UtcNow.AddDays(90), CreatedAt = DateTime.UtcNow },
                new Surgery { Id = 4, PatientId = 9, DepartmentId = 4, SurgeryDate = DateTime.UtcNow.AddDays(120), CreatedAt = DateTime.UtcNow },
                new Surgery { Id = 5, PatientId = 10, DepartmentId = 5, SurgeryDate = DateTime.UtcNow.AddDays(150), CreatedAt = DateTime.UtcNow }
            );
            modelBuilder.Entity<SurgeryDoctor>().HasData(
                new SurgeryDoctor { Id = 1, DoctorId = 11, SurgeryId = 1, CreatedAt = DateTime.UtcNow },
                new SurgeryDoctor { Id = 2, DoctorId = 12, SurgeryId = 2, CreatedAt = DateTime.UtcNow },
                new SurgeryDoctor { Id = 3, DoctorId = 13, SurgeryId = 3, CreatedAt = DateTime.UtcNow },
                new SurgeryDoctor { Id = 4, DoctorId = 14, SurgeryId = 4, CreatedAt = DateTime.UtcNow },
                new SurgeryDoctor { Id = 5, DoctorId = 15, SurgeryId = 5, CreatedAt = DateTime.UtcNow }
            );
            modelBuilder.Entity<WorkingHour>().HasData(
                new WorkingHour { Id = 1, DoctorId = 11, DayOfWeek = DayOfWeek.Monday, StartTime = TimeSpan.FromHours(8), EndTime = TimeSpan.FromHours(16), IsOffDay = false, CreatedAt = DateTime.UtcNow },
                new WorkingHour { Id = 2, DoctorId = 12, DayOfWeek = DayOfWeek.Tuesday, StartTime = TimeSpan.FromHours(9), EndTime = TimeSpan.FromHours(17), IsOffDay = false, CreatedAt = DateTime.UtcNow },
                new WorkingHour { Id = 3, DoctorId = 13, DayOfWeek = DayOfWeek.Wednesday, StartTime = TimeSpan.FromHours(10), EndTime = TimeSpan.FromHours(18), IsOffDay = false, CreatedAt = DateTime.UtcNow },
                new WorkingHour { Id = 4, DoctorId = 14, DayOfWeek = DayOfWeek.Thursday, StartTime = TimeSpan.FromHours(11), EndTime = TimeSpan.FromHours(19), IsOffDay = false, CreatedAt = DateTime.UtcNow },
                new WorkingHour { Id = 5, DoctorId = 15, DayOfWeek = DayOfWeek.Friday, StartTime = TimeSpan.FromHours(12), EndTime = TimeSpan.FromHours(20), IsOffDay = false, CreatedAt = DateTime.UtcNow }
            );







        }
    }

}
