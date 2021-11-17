using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LeaveMotionsManagmentApp.Data;
using LeaveMotionsManagmentApp.Entities;
using LeaveMotionsManagmentApp.Models;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using LeaveMotionsManagmentApp.Interfaces;

namespace LeaveMotionsManagmentApp.Controllers
{
    public class MotionsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMotionRepository _motionRepository;

        public MotionsController(ApplicationDbContext context, IMotionRepository motionRepository)
        {
            _context = context;
            _motionRepository = motionRepository;
        }

        // GET: Motions
        public async Task<IActionResult> Index()
        {

            return View(await _motionRepository.ListMotions());
        }

        // GET: Motions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();


            var motion = await _motionRepository.GetMotion(id);

            if (motion == null)
                return NotFound();
            

            return View(motion);
        }

        // GET: Motions/Create
        public IActionResult Create()
        {
            
            return View();
        }

        // POST: Motions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,RequestedStartingDate,RequestedDueDate,MotionState")] CreateMotion model)
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
                EmployeeId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier),
                SupervisorId = null
            };

            if (ModelState.IsValid)
            {
                _context.Add(motion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
           
            return View(motion);
        }

        // GET: Motions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();
            

            var motion = await _context.Motions.FindAsync(id);
            if (motion == null)
                return NotFound();
            
            
            return View(motion);
        }

        // POST: Motions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Description,RequestedStartingDate,RequestedDueDate")] Motion editedMotion)
        {

            var motion = await _context.Motions.FirstOrDefaultAsync(motion => motion.Id == id);
            
            if (motion is null)
                return NotFound();

            motion.Name = editedMotion.Name;
            motion.Description = editedMotion.Description;
            motion.RequestedStartingDate = editedMotion.RequestedStartingDate;
            motion.RequestedDueDate = editedMotion.RequestedDueDate;
            

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(motion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MotionExists(motion.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
      
            return View(motion);
        }

        // GET: Motions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            

            var motion = await _context.Motions
                .Include(m => m.Employee)
                .Include(m => m.Supervisor)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (motion == null)
                return NotFound();
            

            return View(motion);
        }

        // POST: Motions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var motion = await _context.Motions.FindAsync(id);
            _context.Motions.Remove(motion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MotionExists(int id)
        {
            return _context.Motions.Any(e => e.Id == id);
        }
    }
}
