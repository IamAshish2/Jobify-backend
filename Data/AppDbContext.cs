using jobify_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace jobify_Backend.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }
            public DbSet<User> Users { get; set; }
            public DbSet<Company> Companies { get; set; }
            public DbSet<Job> Jobs { get; set; }
            public DbSet<JobApplication> JobApplications { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
             modelBuilder.Entity<Company>()
                .HasMany(c => c.Jobs)
                .WithOne(j => j.Company)
                .HasForeignKey(j => j.CompanyId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<JobApplication>()
                .HasKey(ja => new { ja.JobId, ja.UserId });

            // Many-to-One relationship between Job and JobApplication
            modelBuilder.Entity<JobApplication>()
                .HasOne(ja => ja.Job)
                .WithMany(j => j.JobApplications)
                .HasForeignKey(ja => ja.JobId)
                .OnDelete(DeleteBehavior.NoAction);

            // Many-to-One relationship between User and JobApplication
            modelBuilder.Entity<JobApplication>()
                .HasOne(ja => ja.User)
                .WithMany(u => u.JobApplications)
                .HasForeignKey(ja => ja.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
        }

    }
