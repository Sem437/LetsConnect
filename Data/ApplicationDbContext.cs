using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LetsConnect.Models;

namespace LetsConnect.Data
{
    public class ApplicationDbContext : IdentityDbContext<StudentModel>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<LetsConnect.Models.WorkshopModel> WorkshopModel { get; set; } = default!;
        public DbSet<LetsConnect.Models.StudentModel> Students { get; set; } = default!;
        public DbSet<LetsConnect.Models.WorkshopStudents> WorkshopStudents { get; set; } = default!;
        public DbSet<TemporaryWorkshopRegistration> TemporaryWorkshopRegistrations { get; set; }
        public DbSet<LetsConnect.Models.WorkshopTimes> WorkshopTimes { get; set; } = default!;
    }
}
