using HCBrazil.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace HCBrazil.Api.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Attendee> Attendees { get; set; }
    public DbSet<Volunteer> Volunteers { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<Guardian> Guardians { get; set; }
    public DbSet<EventAttendees> EventAttendees { get; set; }
    public DbSet<EventOrganizations> EventOrganizations { get; set; }
    public DbSet<EventVolunteers> EventVolunteers { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EventAttendees>()
            .HasKey(ea => new { ea.EventId, ea.AttendeeId });
        
        modelBuilder.Entity<EventVolunteers>()
            .HasKey(ev => new { ev.EventId, ev.VolunteerId });
        
        modelBuilder.Entity<EventOrganizations>()
            .HasKey(eo => new { eo.EventId, eo.OrganizationId });
        
        modelBuilder.Entity<Attendee>()
            .HasOne(a => a.Guardian)
            .WithMany()
            .HasForeignKey(a => a.GuardianId);
    }
}