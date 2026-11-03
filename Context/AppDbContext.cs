using Assignment_2.Configurations;
using Assignment_2.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment_2.Context
{
    internal class AppDbContext : DbContext
    {
        public DbSet<Organizer> Organizers { get; set; }
        public DbSet<OrganizerProfile> OrganizerProfiles { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Attendee> Attendees { get; set; }
        public DbSet<Badge> Badges { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=EventHubDb;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Organizer>()
                        .HasOne(o => o.Profile)
                        .WithOne(p => p.Organizer)
                        .HasForeignKey<OrganizerProfile>(p => p.OrganizerId);

            modelBuilder.Entity<Organizer>()
                        .HasMany(o => o.Events)
                        .WithOne(e => e.Organizer)
                        .HasForeignKey(e => e.OrganizerId);

            modelBuilder.ApplyConfiguration(new BadgeConfigs());
        }
    }
}
