using LetsConnect.Data;
using LetsConnect.Models;
using LetsConnect.Services;
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
        private readonly EmailService _emailService;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, UserManager<StudentModel> userManager, EmailService emailService)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
            _emailService = emailService;
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
        public async Task<IActionResult> SendMail(string FirstName, string Insert, string LastName, string Email, string StudentClass, int WorkshopId)
        {
            var registration = new TemporaryWorkshopRegistration
            {
                FirstName = FirstName,
                Insert = Insert,
                LastName = LastName,
                Email = Email,
                StudentClass = StudentClass,
                WorkshopId = WorkshopId,
                ConformationToken = GenerateConfirmationToken()
            };

            _context.Add(registration);
            await _context.SaveChangesAsync();

            var confirmationURL = Url.Action("Confirm", "Home", new { token = registration.ConformationToken }, protocol: Request.Scheme);
            await _emailService.SendEmailAsync(Email, "Bevestig je workshopinschrijving",
                $"Hallo {FirstName},<br> Klik op de <a href='{confirmationURL}'>Link</a> om je inschrijving te bevestigen.");

            return RedirectToAction(nameof(Index));      
        }

        // GET: Confirm
        public async Task<IActionResult> Confirm(string token)
        {
            if(string.IsNullOrEmpty(token))
            {
                return BadRequest("Geen token");
            }

            var registration = await _context.TemporaryWorkshopRegistrations
                .FirstOrDefaultAsync(r => r.ConformationToken == token); // Haalt token op die overeenkomt in db met URL

            if(registration == null)
            {
                return BadRequest("Token niet gevonden");
            }

            //Check of email al in db staat
            var EmailIsInUserTable = await _context.Students
                .FirstOrDefaultAsync(e => e.Email == registration.Email);

            if (EmailIsInUserTable == null)
            {
                var confirmedRegistration = new StudentModel
                {
                    FirstName = registration.FirstName,
                    Inserts = registration.Insert,
                    Lastname = registration.LastName,
                    Email = registration.Email,
                    StudentClass = registration.StudentClass
                };

                _context.Add(confirmedRegistration);
            }

            var link = new WorkshopStudents
            { 
                WorkshopId = registration.WorkshopId,
                Email = registration.Email
            };


            _context.TemporaryWorkshopRegistrations.Remove(registration);
            _context.SaveChanges();

            return View();
        }

        public string GenerateConfirmationToken()
        {
            return Guid.NewGuid().ToString();
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
