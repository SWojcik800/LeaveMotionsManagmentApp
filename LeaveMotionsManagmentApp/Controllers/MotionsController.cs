using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LeaveMotionsManagmentApp.Models;
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


        [Authorize(Roles="Employee, Supervisor")]
        // GET: Motions
        public async Task<IActionResult> Index()
        {

            return View(await _motionRepository.ListMotions());
        }

        [Authorize(Roles = "Employee, Supervisor")]
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

        [Authorize(Roles = "Employee")]
        
        // GET: Motions/Create
        public IActionResult Create()
        {
            
            return View();
        }

        
        // POST: Motions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Employee")]
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
        [Authorize(Roles = "Employee")]
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
        [Authorize(Roles = "Employee")]
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
        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> Cancel(int? id)
        {
            if (id == null)
                return NotFound();


            var motion = await _motionRepository.GetMotion(id);
            if (motion == null)
                return NotFound();
            

            return View(motion);
        }


        // POST: Motions/Cancel/5
        [Authorize(Roles = "Employee")]
        [HttpPost, ActionName("Cancel")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CancelConfirmed(int id)
        {
            await _motionRepository.CancelMotion(id);
            return RedirectToAction(nameof(Index));
        }

        // GET: Motions/Delete/5
        [Authorize(Roles = "Supervisor")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();


            var motion = await _motionRepository.GetMotion(id);
            if (motion == null)
                return NotFound();


            return View(motion);
        }

        // POST: Motions/Delete/5
        [Authorize(Roles = "Supervisor")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _motionRepository.DeleteMotion(id);
            return RedirectToAction(nameof(Index));
        }

        // GET: Motions/Accept/5
        [Authorize(Roles = "Supervisor")]
        public async Task<IActionResult> Accept(int? id)
        {

            if (id == null)
                return NotFound();


            var motion = await _motionRepository.GetMotion(id);
            if (motion == null)
                return NotFound();


            return View(motion);
        }

        // POST: Motions/Accept/5
        [Authorize(Roles = "Supervisor")]
        [HttpPost, ActionName("Accept")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AcceptConfirmed(int id)
        {
            await _motionRepository.AcceptMotion(id);
            return RedirectToAction(nameof(Index));
        }

        // GET: Motions/Deny/5
        [Authorize(Roles = "Supervisor")]
        public async Task<IActionResult> Deny(int? id)
        {

            if (id == null)
                return NotFound();


            var motion = await _motionRepository.GetMotion(id);
            if (motion == null)
                return NotFound();


            return View(motion);
        }


        // POST: Motions/Deny/5
        [Authorize(Roles = "Supervisor")]
        [HttpPost, ActionName("Deny")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DenialConfirmed(int id)
        {
            await _motionRepository.DenyMotion(id);
            return RedirectToAction(nameof(Index));
        }



    }
}
