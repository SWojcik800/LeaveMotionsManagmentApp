using LeaveMotionsManagmentApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace LeaveMotionsManagmentApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public DbSet<Motion> Motions { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            Seed(builder);
            
        }

        private void Seed(ModelBuilder builder)
        {
            
            string user_id = "59373f6c-f198-46dd-972c-cf813bf05424";
            string role_id = "341743f0-asd2–42de-afbf-59kmkkmk72cf6";

            string supervisor_id = "8b1280d2-20e6-4464-8a6c-46ae41930e9b";
            string supervisor_role_id = "ce929b1c-01df-4073-a711-c501b68b96f4";
            


            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "Employee",
                NormalizedName = "EMPLOYEE",
                Id = role_id,
                ConcurrencyStamp = user_id
            });

            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "Supervisor",
                NormalizedName = "SUPERVISOR",
                Id = supervisor_role_id,
                ConcurrencyStamp = supervisor_id
            });



            var appUser = new ApplicationUser
            {
                Id = user_id,
                Email = "user@email.com",
                EmailConfirmed = true,
                UserName = "user@email.com",
                NormalizedUserName = "USER@EMAIL.COM"
            };

            var supervisor = new ApplicationUser
            {
                Id = supervisor_id,
                Email = "supervisor@email.com",
                EmailConfirmed = true,
                UserName = "supervisor@email.com",
                NormalizedUserName = "SUPERVISOR@EMAIL.COM"
            };


            PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();
            appUser.PasswordHash = passwordHasher.HashPassword(appUser, "Password1!");
            supervisor.PasswordHash = passwordHasher.HashPassword(supervisor, "Password1!");


            builder.Entity<ApplicationUser>().HasData(appUser);
            builder.Entity<ApplicationUser>().HasData(supervisor);


            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = role_id,
                UserId = user_id
            });
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = supervisor_role_id,
                UserId = supervisor_id
            });
        }
        

    }
}
