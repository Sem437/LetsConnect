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
    public class OverzichtController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OverzichtController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Overzicht
        public async Task<IActionResult> Index()
        {
            var workshopsWithStudents = await _context.WorkshopModel
         .Select(workshop => new WorkshopStudentOverview
         {
             WorkshopName = workshop.WorkshopName,
             studentEmails = _context.WorkshopStudents
                 .Where(student => student.WorkshopId == workshop.WorkshopId)
                 .Select(student => student.Email)                 
                 .ToList(),
           
         })
         .ToListAsync();

            return View(workshopsWithStudents);
        }


        // GET: Overzicht/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workshopStudents = await _context.WorkshopStudents
                .FirstOrDefaultAsync(m => m.IdStudentWorkshop == id);
            if (workshopStudents == null)
            {
                return NotFound();
            }

            return View(workshopStudents);
        }

        // GET: Overzicht/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Overzicht/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdStudentWorkshop,Email,WorkshopId")] WorkshopStudents workshopStudents)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workshopStudents);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(workshopStudents);
        }

        // GET: Overzicht/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workshopStudents = await _context.WorkshopStudents.FindAsync(id);
            if (workshopStudents == null)
            {
                return NotFound();
            }
            return View(workshopStudents);
        }

        // POST: Overzicht/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdStudentWorkshop,Email,WorkshopId")] WorkshopStudents workshopStudents)
        {
            if (id != workshopStudents.IdStudentWorkshop)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workshopStudents);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkshopStudentsExists(workshopStudents.IdStudentWorkshop))
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
            return View(workshopStudents);
        }

        // GET: Overzicht/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workshopStudents = await _context.WorkshopStudents
                .FirstOrDefaultAsync(m => m.IdStudentWorkshop == id);
            if (workshopStudents == null)
            {
                return NotFound();
            }

            return View(workshopStudents);
        }

        // POST: Overzicht/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workshopStudents = await _context.WorkshopStudents.FindAsync(id);
            if (workshopStudents != null)
            {
                _context.WorkshopStudents.Remove(workshopStudents);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkshopStudentsExists(int id)
        {
            return _context.WorkshopStudents.Any(e => e.IdStudentWorkshop == id);
        }
    }
}
