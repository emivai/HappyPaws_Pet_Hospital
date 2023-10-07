using HappyPaws.API.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace HappyPaws.API.Infrastructure
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options){}

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<AppointmentProcedure> AppointmentProcedures { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Procedure> Procedures { get; set; }
        public DbSet<TimeSlot> TimeSlots { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
