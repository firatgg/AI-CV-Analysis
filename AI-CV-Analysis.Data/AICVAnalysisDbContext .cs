using Microsoft.EntityFrameworkCore;
using AI_CV_Analysis.Data.Entities;

using System.Collections.Generic;

namespace AI_CV_Analysis.Data
{
    public class AICVAnalysisDbContext : DbContext
    {
        public AICVAnalysisDbContext(DbContextOptions<AICVAnalysisDbContext> options) : base(options) { }

        // Veri Tabloları
        public DbSet<User> Users { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Application> Applications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Applications -> Applicant (User)
            modelBuilder.Entity<Application>()
                .HasOne(a => a.Applicant)
                .WithMany(u => u.Applications)
                .HasForeignKey(a => a.ApplicantId)
                .OnDelete(DeleteBehavior.Restrict); // Cascade yerine Restrict kullan

            // Applications -> Job
            modelBuilder.Entity<Application>()
                .HasOne(a => a.Job)
                .WithMany(j => j.Applications)
                .HasForeignKey(a => a.JobId)
                .OnDelete(DeleteBehavior.Restrict); // Cascade yerine Restrict kullan

            // Jobs -> Employer (User)
            modelBuilder.Entity<Job>()
                .HasOne(j => j.Employer)
                .WithMany(u => u.Jobs)
                .HasForeignKey(j => j.EmployerId)
                .OnDelete(DeleteBehavior.Restrict); // Cascade yerine Restrict kullan

            base.OnModelCreating(modelBuilder);
        }

    }
}
