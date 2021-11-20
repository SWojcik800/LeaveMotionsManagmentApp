using LeaveMotionsManagmentApp.Data;
using LeaveMotionsManagmentApp.Data.Seeder;
using LeaveMotionsManagmentApp.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;

namespace LeaveMotionsManagmentApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddApplicationServices(Configuration);

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddIdentityServices(Configuration);
            services.AddControllersWithViews();
            services.AddCoreAdmin();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Auto migration
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                context.Database.EnsureCreated();

                if (!context.Motions.Any())
                {
                    context.Motions.AddRange(MotionSeeder.GetMotions("59373f6c-f198-46dd-972c-cf813bf05424", "8b1280d2-20e6-4464-8a6c-46ae41930e9b"));
                    context.Motions.AddRange(MotionSeeder.GetMotions("43f52c18-5726-4322-bd28-98ab883330af", "a1bc861a-d308-4b19-a26a-93e96fb1c661"));
                    context.SaveChanges();
                }

            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();

            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStatusCodePagesWithReExecute("/Home/Error", "?statusCode={0}");
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
