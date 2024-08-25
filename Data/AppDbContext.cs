using jobify_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace jobify_Backend.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) {}
            public DbSet<User> Users { get; set; }
            public DbSet<Company> Companies { get; set; }
            public DbSet<Job> Jobs { get; set; }
            public DbSet<JobApplication> JobApplications { get; set; }
            public DbSet<CompanyJob> CompanyJobs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<JobApplication>()
                .HasKey(ja => new {ja.JobId,ja.UserId});

            modelBuilder.Entity<JobApplication>()
                .HasOne(ja => ja.Job)
                .WithMany(ja => ja.JobApplications)
                .HasForeignKey(ja => ja.JobId)
                .OnDelete(DeleteBehavior.ClientSetNull);


            modelBuilder.Entity<JobApplication>()
              .HasOne(ja => ja.User)
              .WithMany(ja => ja.JobApplications)
              .HasForeignKey(ja => ja.UserId)
              .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<CompanyJob>()
                .HasKey(cj => new { cj.CompanyId, cj.JobId });

            modelBuilder.Entity<CompanyJob>()
                .HasOne(cj => cj.Company)
                .WithMany(cj => cj.CompanyJobs)
                .HasForeignKey(cj => cj.CompanyId)
                 .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<CompanyJob>()
             .HasOne(cj => cj.Job)
             .WithMany(cj => cj.CompanyJobs)
             .HasForeignKey(cj => cj.JobId)
              .OnDelete(DeleteBehavior.ClientSetNull);


        }
    }
 }
