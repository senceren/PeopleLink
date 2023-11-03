using ApplicationCore.Constants;
using ApplicationCore.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity
{
    public static class PeopleLinkIdentityContextSeed
    {
        public static async Task SeedAsync(PeopleLinkIdentityContext db, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            await db.Database.MigrateAsync();

            if (await userManager.Users.AnyAsync() || await roleManager.Roles.AnyAsync())
                return;

            var admin = new ApplicationUser()
            {
                UserName = AuthorizationConstant.DEFAULT_ADMIN_USER,
                Email = AuthorizationConstant.DEFAULT_ADMIN_USER,
                EmailConfirmed = true,
                PhoneNumber = "5347384176",
                FirstName = "Şule",
                LastName = "Çakır",
                BirthDate = new DateTime(1989, 06, 14),
                BirthPlaceName = "Ankara",
                PictureUri = "sule.jpg",
                IdentityNumber = "48951167304",
                HireDate = new DateTime(2017, 08, 26),
                OccupationId = 1,
                DepartmentId = 1,
                OccupationName = "Yazılım Mühendisi",
                DepartmentName = "Bilgi Teknolojileri Departmanı",
                CompanyName = "Bilge Adam Teknoloji",
                CityId = 6,
                DistrictId = 1231,
                CityName = "Ankara",
                DistrictName = "Çankaya",
                FullAddress = "M Mah. S Sok. No: 7",
                Salary = 51000,
                Gender = Gender.Female
            };

            var demoUser = new ApplicationUser()
            {
                UserName = AuthorizationConstant.DEFAULT_DEMO_USER,
                Email = AuthorizationConstant.DEFAULT_DEMO_USER,
                EmailConfirmed = true,
                PhoneNumber = "5557894512",
                FirstName = "Ezgi",
                LastName = "Sönmez",
                MiddleLastName = "Karaca",
                BirthDate = new DateTime(1990, 05, 10),
                BirthPlaceName = "Eskişehir",
                PictureUri = "ezgi.jpg",
                IdentityNumber = "12345678910",
                HireDate = new DateTime(2020, 05, 10),
                OccupationId = 1,
                DepartmentId = 1,
                OccupationName = "Yazılım Mühendisi",
                DepartmentName = "Bilgi Teknolojileri Departmanı",
                CompanyName = "Bilge Adam Teknoloji",
                CityId = 6,
                DistrictId = 1231,
                CityName = "Ankara",
                DistrictName = "Çankaya",
                FullAddress = "A Sok. 26 / 8",
                Salary = 40000,
                Gender = Gender.Female
            };

            var manager = new ApplicationUser()
            {
                UserName = AuthorizationConstant.DEFAULT_MANAGER_USER,
                Email = AuthorizationConstant.DEFAULT_MANAGER_USER,
                EmailConfirmed = true,
                PhoneNumber = "5054796243",
                FirstName = "Mehmet",
                MiddleName = "Kaan",
                LastName = "Kaya",
                BirthDate = new DateTime(1985, 02, 21),
                BirthPlaceName = "İstanbul",
                PictureUri = "kaan.png",
                IdentityNumber = "10124578962",
                HireDate = new DateTime(2015, 04, 10),
                OccupationId = 3,
                DepartmentId = 5,
                OccupationName = "Proje Yöneticisi",
                DepartmentName = "Proje Yönetim Departmanı",
                CompanyName = "Bilge Adam Teknoloji",
                CityId = 6,
                DistrictId = 1231,
                CityName = "Ankara",
                DistrictName = "Çankaya",
                FullAddress = "C Sok. A-3 / 7",
                Salary = 45000,
                Gender = Gender.Male
            };

            demoUser.AdvanceAllowance = demoUser.Salary * 3;
            demoUser.AccruedLeave = demoUser.IsActive ? (DateTimeOffset.Now > demoUser.HireDate.AddYears(1) ? (DateTimeOffset.Now < demoUser.HireDate.AddYears(6) ? 14 : 20) : 0) : 0;

            manager.AdvanceAllowance = manager.Salary * 3;
            manager.AccruedLeave = manager.IsActive ? (DateTimeOffset.Now > manager.HireDate.AddYears(1) ? (DateTimeOffset.Now < manager.HireDate.AddYears(6) ? 14 : 20) : 0) : 0;

            admin.AdvanceAllowance = admin.Salary * 3;
            admin.AccruedLeave = admin.IsActive ? (DateTimeOffset.Now > admin.HireDate.AddYears(1) ? (DateTimeOffset.Now < admin.HireDate.AddYears(6) ? 14 : 20) : 0) : 0;

            await userManager.CreateAsync(admin, AuthorizationConstant.DEFAULT_PASSWORD);
            await roleManager.CreateAsync(new IdentityRole(AuthorizationConstant.Roles.ADMIN));
            await userManager.AddToRoleAsync(admin, AuthorizationConstant.Roles.ADMIN);

            await userManager.CreateAsync(manager, AuthorizationConstant.DEFAULT_PASSWORD);
            await roleManager.CreateAsync(new IdentityRole(AuthorizationConstant.Roles.MANAGER));
            await userManager.AddToRoleAsync(manager, AuthorizationConstant.Roles.MANAGER);

            await userManager.CreateAsync(demoUser, AuthorizationConstant.DEFAULT_PASSWORD);
            await roleManager.CreateAsync(new IdentityRole(AuthorizationConstant.Roles.EMPLOYEE));
            await userManager.AddToRoleAsync(demoUser, AuthorizationConstant.Roles.EMPLOYEE);
        }
    }
}
