using LeaveMotionsManagmentApp.Data;
using LeaveMotionsManagmentApp.Models;
using LeaveMotionsManagmentApp.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System;

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
                 .Where(m => m.EmployeeId == GetCurrentUserId() && m.MotionState != MotionState.Cancelled)
                 .Include(m => m.Employee)
                 .Include(m => m.Supervisor);

            return await motionList.ToListAsync();
        }

        public async Task<Motion> GetMotion(int? id)
        {
            var motion = await _context.Motions
                .Where(m => m.EmployeeId == GetCurrentUserId() && m.MotionState != MotionState.Cancelled)
                .Include(m => m.Employee)
                .Include(m => m.Supervisor)
                .FirstOrDefaultAsync(m => m.Id == id);

            return motion;
        }

        public async Task<Motion> CreateMotion(CreateMotion model)
        {
            Motion motion = new Motion()
            {
                Name = model.Name,
                Description = model.Description,
                Send = DateTime.Now,
                RequestedStartingDate = model.RequestedStartingDate,
                RequestedDueDate = model.RequestedDueDate,
                MotionState = MotionState.Pending,
                ExaminationDate = null,
                EmployeeId = GetCurrentUserId(),
                SupervisorId = null
            };

            _context.Add(motion);
            await _context.SaveChangesAsync();
            return motion;
        }

        public async Task<Motion> CancelMotion(int? id)
        {
            var motion = await _context.Motions.FindAsync(id);

            motion.MotionState = MotionState.Cancelled;
            motion.ExaminationDate = DateTime.Now;
            motion.SupervisorId = GetCurrentUserId();
            await _context.SaveChangesAsync();

            return motion;
        }

        public async Task UpdateMotion(int id ,Motion editedMotion)
        {
            if (await GetMotion(id) != null)
            {
                _context.Update(editedMotion);
                await _context.SaveChangesAsync();
            }
        }

        

        //Accessing current user Id
        public string GetCurrentUserId() => _httpContextAccessor.HttpContext
            .User.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}
