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
using Microsoft.AspNetCore.Mvc;

namespace LeaveMotionsManagmentApp.Repositories
{
    public class MotionRepository : IMotionRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IFilterQueryBuilder _filterQueryBuilder;

        public MotionRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor, IFilterQueryBuilder filterQueryBuilder)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _filterQueryBuilder = filterQueryBuilder;
        }
        
        
        public async Task<List<Motion>> ListMotions()
        {

            var motionList = getBaseQuery()
                .Include(m => m.Employee)
                .Include(m => m.Supervisor); ;
            return await motionList.ToListAsync();
        }
        public async Task<List<Motion>> FilterMotions(FilterQuery? query)
        {
            var motionList = _filterQueryBuilder.buildQuery(getBaseQuery(), query);


            List<Motion> motionsList = await motionList
                            .Include(m => m.Employee)
                            .Include(m => m.Supervisor)
                            .ToListAsync();
            
            return motionsList;
        }

       

        public async Task<Motion> GetMotion(int? id)
        {
            var motion = await getBaseQuery()
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
            var motion = await GetMotion(id);

            if (motion == null || motion.MotionState != MotionState.Pending)
                return null;


            motion.MotionState = MotionState.Cancelled;
            motion.ExaminationDate = DateTime.Now;
            motion.SupervisorId = GetCurrentUserId();
            await _context.SaveChangesAsync();

            return motion;
        }

        public async Task DeleteMotion(int? id)
        {
            var motion = await GetMotion(id);
            if (motion == null)
                return;
            _context.Motions.Remove(motion);
            await _context.SaveChangesAsync();
              
        }

        public async Task UpdateMotion(int id ,Motion editedMotion)
        {
            if (await GetMotion(id) != null)
            {
                _context.Update(editedMotion);
                await _context.SaveChangesAsync();
            }
        }

        public async Task AcceptMotion(int id)
        {
            var motion = await GetMotion(id);
            if (motion != null)
            {
                motion.MotionState = MotionState.Accepted;
                motion.ExaminationDate = DateTime.Now;
                _context.Update(motion);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DenyMotion(int id)
        {
            var motion = await GetMotion(id);
            if (motion != null)
            {

                motion.MotionState = MotionState.Denied;
                motion.ExaminationDate = DateTime.Now;
                _context.Update(motion);
                await _context.SaveChangesAsync();
            }
        }



        //Accessing current user Id
        private string GetCurrentUserId() => _httpContextAccessor.HttpContext
            .User.FindFirstValue(ClaimTypes.NameIdentifier);


        //Returns only records that contain Users motion if user is in role Employee
        private IQueryable<Motion> getBaseQuery() {

            if (_httpContextAccessor.HttpContext.User.IsInRole("Employee"))
                return _context.Motions
                    .Where(m => m.EmployeeId == GetCurrentUserId() 
                    && m.MotionState != MotionState.Cancelled);
            return _context.Motions;
        }
        
    }
}
