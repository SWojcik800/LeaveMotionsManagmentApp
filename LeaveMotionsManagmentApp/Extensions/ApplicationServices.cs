using LeaveMotionsManagmentApp.Data;
using LeaveMotionsManagmentApp.Interfaces;
using LeaveMotionsManagmentApp.Repositories;
using LeaveMotionsManagmentApp.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace LeaveMotionsManagmentApp.Extensions
{
    public static class ApplicationServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration Configuration)
        {

            
            services.AddHttpContextAccessor();

            services.AddDbContext<ApplicationDbContext>(options =>
             options.UseSqlServer(
                 Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IFilterQueryBuilder, FilterQueryBuilder>();
            services.AddScoped<IMotionRepository, MotionRepository>();
            

           

            return services;
        }
    }
}
