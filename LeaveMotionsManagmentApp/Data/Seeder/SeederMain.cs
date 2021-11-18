using LeaveMotionsManagmentApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveMotionsManagmentApp.Data.Seeder
{
    public class SeederMain
    {

        public void Seed(ModelBuilder builder)
        {
            List<Seed> users = new List<Seed>
            {
                new Seed()
                {
                    UserId = "59373f6c-f198-46dd-972c-cf813bf05424",
                    RoleId =  "341743f0-asd2–42de-afbf-59kmkkmk72cf6",
                    Username = "user@email.com",
                    Password = "Password1!"

                },
                new Seed()
                {
                    UserId = "8b1280d2-20e6-4464-8a6c-46ae41930e9b",
                    RoleId = "ce929b1c-01df-4073-a711-c501b68b96f4",
                    Username = "supervisor@email.com",
                    Password = "Password1!"


                }
            };

            SeedRoles(builder);

            foreach (var userSeed in users)
            {
                SeedUser(builder, userSeed);
            }

        }

        public void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "Employee",
                NormalizedName = "EMPLOYEE",
                Id = "341743f0-asd2–42de-afbf-59kmkkmk72cf6",
                ConcurrencyStamp = "59373f6c-f198-46dd-972c-cf813bf05424"
            });

            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "Supervisor",
                NormalizedName = "SUPERVISOR",
                Id = "ce929b1c-01df-4073-a711-c501b68b96f4",
                ConcurrencyStamp = "8b1280d2-20e6-4464-8a6c-46ae41930e9b"
            });
        }

        public void SeedUser(ModelBuilder builder, Seed user)
        {
            var appUser = new ApplicationUser
            {
                Id = user.UserId,
                Email = user.Username,
                EmailConfirmed = true,
                UserName = user.Username,
                NormalizedUserName = user.Username.ToUpper()
            };

            PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();
            appUser.PasswordHash = passwordHasher.HashPassword(appUser, user.Password);

            builder.Entity<ApplicationUser>().HasData(appUser);
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = user.RoleId,
                UserId = user.UserId
            });

        }
    }
}
