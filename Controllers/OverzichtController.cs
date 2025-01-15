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
            return View(await _context.TemporaryWorkshopRegistrations.ToListAsync());
        }

        // GET: Overzicht/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var temporaryWorkshopRegistration = await _context.TemporaryWorkshopRegistrations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (temporaryWorkshopRegistration == null)
            {
                return NotFound();
            }

            return View(temporaryWorkshopRegistration);
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
        public async Task<IActionResult> Create([Bind("Id,Email,FirstName,Insert,LastName,StudentClass,WorkshopId,IsConfirmed,ConformationToken")] TemporaryWorkshopRegistration temporaryWorkshopRegistration)
        {
            if (ModelState.IsValid)
            {
                _context.Add(temporaryWorkshopRegistration);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(temporaryWorkshopRegistration);
        }

        // GET: Overzicht/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var temporaryWorkshopRegistration = await _context.TemporaryWorkshopRegistrations.FindAsync(id);
            if (temporaryWorkshopRegistration == null)
            {
                return NotFound();
            }
            return View(temporaryWorkshopRegistration);
        }

        // POST: Overzicht/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Email,FirstName,Insert,LastName,StudentClass,WorkshopId,IsConfirmed,ConformationToken")] TemporaryWorkshopRegistration temporaryWorkshopRegistration)
        {
            if (id != temporaryWorkshopRegistration.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(temporaryWorkshopRegistration);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TemporaryWorkshopRegistrationExists(temporaryWorkshopRegistration.Id))
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
            return View(temporaryWorkshopRegistration);
        }

        // GET: Overzicht/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var temporaryWorkshopRegistration = await _context.TemporaryWorkshopRegistrations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (temporaryWorkshopRegistration == null)
            {
                return NotFound();
            }

            return View(temporaryWorkshopRegistration);
        }

        // POST: Overzicht/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var temporaryWorkshopRegistration = await _context.TemporaryWorkshopRegistrations.FindAsync(id);
            if (temporaryWorkshopRegistration != null)
            {
                _context.TemporaryWorkshopRegistrations.Remove(temporaryWorkshopRegistration);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TemporaryWorkshopRegistrationExists(int id)
        {
            return _context.TemporaryWorkshopRegistrations.Any(e => e.Id == id);
        }
    }
}
