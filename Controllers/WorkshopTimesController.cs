using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LetsConnect.Data;
using LetsConnect.Models;

namespace LetsConnect.Controllers
{
    public class WorkshopTimesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WorkshopTimesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: WorkshopTimes
        public async Task<IActionResult> Index()
        {
            return View(await _context.WorkshopTimes.ToListAsync());
        }

        // GET: WorkshopTimes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workshopTimes = await _context.WorkshopTimes
                .FirstOrDefaultAsync(m => m.WorkshopTimeId == id);
            if (workshopTimes == null)
            {
                return NotFound();
            }

            return View(workshopTimes);
        }

        // GET: WorkshopTimes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WorkshopTimes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WorkshopTimeId,WorkshopId,WorkshopRonde,WorkshopPlace,WorkshopDate,WorkshopStartTime,WorkshopEndTime,WorkshopTeacher")] WorkshopTimes workshopTimes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workshopTimes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(workshopTimes);
        }

        // GET: WorkshopTimes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workshopTimes = await _context.WorkshopTimes.FindAsync(id);
            if (workshopTimes == null)
            {
                return NotFound();
            }
            return View(workshopTimes);
        }

        // POST: WorkshopTimes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WorkshopTimeId,WorkshopId,WorkshopRonde,WorkshopPlace,WorkshopDate,WorkshopStartTime,WorkshopEndTime,WorkshopTeacher")] WorkshopTimes workshopTimes)
        {
            if (id != workshopTimes.WorkshopTimeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workshopTimes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkshopTimesExists(workshopTimes.WorkshopTimeId))
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
            return View(workshopTimes);
        }

        // GET: WorkshopTimes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workshopTimes = await _context.WorkshopTimes
                .FirstOrDefaultAsync(m => m.WorkshopTimeId == id);
            if (workshopTimes == null)
            {
                return NotFound();
            }

            return View(workshopTimes);
        }

        // POST: WorkshopTimes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workshopTimes = await _context.WorkshopTimes.FindAsync(id);
            if (workshopTimes != null)
            {
                _context.WorkshopTimes.Remove(workshopTimes);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkshopTimesExists(int id)
        {
            return _context.WorkshopTimes.Any(e => e.WorkshopTimeId == id);
        }
    }
}
