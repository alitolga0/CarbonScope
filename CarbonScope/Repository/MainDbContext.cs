
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CarbonScope.Models;

namespace CarbonScope.Repository
{

        public class MainDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
            public MainDbContext(DbContextOptions<MainDbContext> options)
                : base(options)
            {
            }

            public DbSet<Company> Companies { get; set; }
            public DbSet<Facility> Facilities { get; set; }
            public DbSet<ConsumptionType> ConsumptionTypes { get; set; }
            public DbSet<ConsumptionRecord> ConsumptionRecords { get; set; }
            public DbSet<Report> Reports { get; set; }
            public DbSet<Recommendation> Recommendations { get; set; }
            public DbSet<TaskAssignment> TaskAssignments { get; set; }

            protected override void OnModelCreating(ModelBuilder builder)
            {
                base.OnModelCreating(builder);

                builder.Entity<ApplicationUser>()
                    .HasOne(u => u.Company)
                    .WithMany(c => c.Users)
                    .HasForeignKey(u => u.CompanyId)
                    .OnDelete(DeleteBehavior.Restrict);

                builder.Entity<Facility>()
                    .HasOne(f => f.Company)
                    .WithMany(c => c.Facilities)
                    .HasForeignKey(f => f.CompanyId)
                    .OnDelete(DeleteBehavior.Cascade);

                builder.Entity<ConsumptionRecord>()
                    .HasOne(cr => cr.Facility)
                    .WithMany(f => f.ConsumptionRecords)
                    .HasForeignKey(cr => cr.FacilityId)
                    .OnDelete(DeleteBehavior.Cascade);

                builder.Entity<ConsumptionRecord>()
                    .HasOne(cr => cr.ConsumptionType)
                    .WithMany()
                    .HasForeignKey(cr => cr.ConsumptionTypeId)
                    .OnDelete(DeleteBehavior.Restrict);

                builder.Entity<Report>()
                    .HasOne(r => r.Company)
                    .WithMany()
                    .HasForeignKey(r => r.CompanyId)
                    .OnDelete(DeleteBehavior.Cascade);

                builder.Entity<Report>()
                    .HasOne(r => r.Facility)
                    .WithMany()
                    .HasForeignKey(r => r.FacilityId)
                    .OnDelete(DeleteBehavior.Restrict);

                builder.Entity<Recommendation>()
                    .HasOne(r => r.Company)
                    .WithMany()
                    .HasForeignKey(r => r.CompanyId)
                    .OnDelete(DeleteBehavior.Cascade);

                builder.Entity<Recommendation>()
                    .HasOne(r => r.Facility)
                    .WithMany()
                    .HasForeignKey(r => r.FacilityId)
                    .OnDelete(DeleteBehavior.Restrict);

                builder.Entity<TaskAssignment>()
                    .HasOne(t => t.AssignedUser)
                    .WithMany()
                    .HasForeignKey(t => t.AssignedUserId)
                    .OnDelete(DeleteBehavior.Cascade);

            }
   
        }
}
