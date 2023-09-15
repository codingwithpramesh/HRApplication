using HRApplication.Models;
using HRApplication.Models.Comment;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HRApplication.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employee { get; set; } 
        
        public DbSet<Leave> leaves { get; set; }

        public DbSet<EmployeeAttendence> EmployeeAttendence { get; set;}

        public DbSet<Comment> Comment { get; set; }

       /* protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Status>()
                .HasNoKey()
                .ToView("status");
        }*/
    }
}
