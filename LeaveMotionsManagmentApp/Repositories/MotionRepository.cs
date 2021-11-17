using LeaveMotionsManagmentApp.Data;
using LeaveMotionsManagmentApp.Entities;
using LeaveMotionsManagmentApp.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LeaveMotionsManagmentApp.Repositories
{
    public class MotionRepository : IMotionRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MotionRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        
        public async Task<List<Motion>> ListMotions()
        {
            var motionList = _context.Motions
                 .Where(m => m.EmployeeId == GetCurrentUserId())
                 .Include(m => m.Employee)
                 .Include(m => m.Supervisor);

            return await motionList.ToListAsync();
        }

        public async Task<Motion> GetMotion(int? id)
        {
            var motion = await _context.Motions
                .Where(m => m.EmployeeId == GetCurrentUserId())
                .Include(m => m.Employee)
                .Include(m => m.Supervisor)
                .FirstOrDefaultAsync(m => m.Id == id);

            return motion;
        }

        //Accessing current user Id
        public string GetCurrentUserId() => _httpContextAccessor.HttpContext
            .User.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}
