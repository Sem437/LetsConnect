using LetsConnect.Data;
using LetsConnect.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;

namespace LetsConnect.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<StudentModel> _userManager;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, UserManager<StudentModel> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }

        // GET: Index
        public async Task<IActionResult> Index()
        {           

            if (User.Identity.IsAuthenticated)
            {
                string IdUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                ViewBag.UserId = IdUser;
            }

            var workshops = from w in _context.WorkshopModel select w;

            return View(await workshops.ToListAsync());
        }

        // POST: Index
        // Studenten gekozen workshops        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddStudent([Bind("IdStudentWorkshop,StudentId,WorkshopId")] WorkshopStudents workshopStudents)
        {              
            if (ModelState.IsValid)
            {
                _context.Add(workshopStudents);

                // Id ophalen van aangemelde workshop
                var workshop = await _context.WorkshopModel.FindAsync(workshopStudents.WorkshopId);

                if (workshop != null)
                {
                    workshop.WorkshopSignUps++;

                    if (workshop.WorkshopSignUps > workshop.WorkshopMax)
                    {
                        ModelState.AddModelError("", "Workshop is al vol.");
                        return View(workshop);
                    }
                    _context.Update(workshop);
                }

                // Data in db zetten
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }              

            return View(workshopStudents);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
