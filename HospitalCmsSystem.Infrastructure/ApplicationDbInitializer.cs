using HospitalCmsSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Infrastructure
{
    public static class ApplicationDbInitializer
    {
        public static async Task SeedRoles(Microsoft.AspNetCore.Identity.RoleManager<AppRole> roleManager)
        {
            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                var adminRole = new AppRole { Name = "Admin" };
                await roleManager.CreateAsync(adminRole);
            }

            if (!await roleManager.RoleExistsAsync("Doctor"))
            {
                var doctorRole = new AppRole { Name = "Doctor" };
                await roleManager.CreateAsync(doctorRole);
            }

            if (!await roleManager.RoleExistsAsync("Patient"))
            {
                var patientRole = new AppRole { Name = "Patient" };
                await roleManager.CreateAsync(patientRole);
            }

            // Diğer rolleri burada ekleyebilirsiniz.
            // Örneğin: "Nurse", "Receptionist" vs.
        }
    }
}
