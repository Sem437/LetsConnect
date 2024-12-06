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
    public class WorkshopController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WorkshopController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Workshop
        public async Task<IActionResult> Index()
        {
            return View(await _context.WorkshopModel.ToListAsync());
        }

        // GET: Workshop/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workshopModel = await _context.WorkshopModel
                .FirstOrDefaultAsync(m => m.WorkshopId == id);
            if (workshopModel == null)
            {
                return NotFound();
            }

            return View(workshopModel);
        }

        // GET: Workshop/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Workshop/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WorkshopId,WorkshopName,WorkshopDescription,WorkshopPlace,WorkshopMax,WorkshopSignUps,WorkshopDate,WorkshopStartTime,WorkshopEndTime,WorkshopTeacher,WorkshopType,WorkshopIMG")] WorkshopModel workshopModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workshopModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(workshopModel);
        }

        // GET: Workshop/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workshopModel = await _context.WorkshopModel.FindAsync(id);
            if (workshopModel == null)
            {
                return NotFound();
            }
            return View(workshopModel);
        }

        // POST: Workshop/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WorkshopId,WorkshopName,WorkshopDescription,WorkshopPlace,WorkshopMax,WorkshopSignUps,WorkshopDate,WorkshopStartTime,WorkshopEndTime,WorkshopTeacher,WorkshopType,WorkshopIMG")] WorkshopModel workshopModel)
        {
            if (id != workshopModel.WorkshopId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workshopModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkshopModelExists(workshopModel.WorkshopId))
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
            return View(workshopModel);
        }

        // GET: Workshop/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workshopModel = await _context.WorkshopModel
                .FirstOrDefaultAsync(m => m.WorkshopId == id);
            if (workshopModel == null)
            {
                return NotFound();
            }

            return View(workshopModel);
        }

        // POST: Workshop/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workshopModel = await _context.WorkshopModel.FindAsync(id);
            if (workshopModel != null)
            {
                _context.WorkshopModel.Remove(workshopModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkshopModelExists(int id)
        {
            return _context.WorkshopModel.Any(e => e.WorkshopId == id);
        }
    }
}
