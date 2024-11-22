using Microsoft.EntityFrameworkCore;
using AI_CV_Analysis.Data.Entities;

using System.Collections.Generic;

namespace AI_CV_Analysis.Data
{
    public class AICVAnalysisDbContext : DbContext
    {
        public AICVAnalysisDbContext(DbContextOptions<AICVAnalysisDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Job> Jobs { get; set; } = null!;
        public DbSet<Application> Applications { get; set; } = null!;
    }
}
