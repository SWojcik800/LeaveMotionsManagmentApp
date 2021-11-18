using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LeaveMotionsManagmentApp.Data;
using LeaveMotionsManagmentApp.Models;
using LeaveMotionsManagmentApp.Models;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using LeaveMotionsManagmentApp.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace LeaveMotionsManagmentApp.Controllers
{
    public class MotionsController : Controller
    {
       
        private readonly IMotionRepository _motionRepository;

        public MotionsController(IMotionRepository motionRepository)
        {
           
            _motionRepository = motionRepository;
        }

        [Authorize(Roles="Employee")]
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

            var motion = new Motion();
            if (ModelState.IsValid)
            {
                motion = await _motionRepository.CreateMotion(model);
                return RedirectToAction(nameof(Index));
            }
           
            return View(motion);
        }

        // GET: Motions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();
            

            var motion = await _motionRepository.GetMotion(id);
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

            var motion = await _motionRepository.GetMotion(id);
            
            if (motion is null)
                return NotFound();

            motion.Name = editedMotion.Name;
            motion.Description = editedMotion.Description;
            motion.RequestedStartingDate = editedMotion.RequestedStartingDate;
            motion.RequestedDueDate = editedMotion.RequestedDueDate;
            

            if (ModelState.IsValid)
            {
                await _motionRepository.UpdateMotion(id, motion);
                return RedirectToAction(nameof(Index));
            }
      
            return View(motion);
        }

        // GET: Motions/Cancel/5
        public async Task<IActionResult> Cancel(int? id)
        {
            if (id == null)
                return NotFound();


            var motion = await _motionRepository.CancelMotion(id);
            if (motion == null)
                return NotFound();
            

            return View(motion);
        }

        // POST: Motions/Cancel/5
        [HttpPost, ActionName("Cancel")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CancelConfirmed(int id)
        {
            await _motionRepository.CancelMotion(id);
            return RedirectToAction(nameof(Index));
        }

 
    }
}
