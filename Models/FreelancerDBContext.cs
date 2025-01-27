using Freelance.Models.DbEntities;
using Microsoft.EntityFrameworkCore;

namespace Freelance.Models
{
    public class FreelancerDBContext :DbContext
    {
        public FreelancerDBContext(DbContextOptions<FreelancerDBContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relationships
            modelBuilder.Entity<Freelancer>()
                .HasMany(f => f.Skillsets)
                .WithOne(s => s.Freelancer)
                .HasForeignKey(s => s.FreelancerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Freelancer>()
                .HasMany(f => f.Hobbies)
                .WithOne(h => h.Freelancer)
                .HasForeignKey(h => h.FreelancerId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        public DbSet<Freelancer> Freelancers { get; set; }
        public DbSet<Skillset> Skillsets { get; set; }
        public DbSet<Hobby> Hobbies { get; set; }
    }
}
