using Microsoft.EntityFrameworkCore;

namespace DoctorManagementSystem.DataAccess
{
    public class ApplicationDbcontext :DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;initial catalog=DoctorDataBase;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Doctor>(
                e => {
                    e.Property(d => d.Name).HasMaxLength(255);
                    e.Property(d => d.Img).HasMaxLength(255);
                    e.Property(d => d.Specialization).HasMaxLength(255);
                }
                );
            modelBuilder.Entity<BookAppointment>(
                e => {
                    e.Property(d => d.Name).HasMaxLength(255);
                    //e.Property(e => e.TimeBook).HasColumnType("varchar(255)");
                    //e.Property(e => e.DateBook).HasColumnType("Datetime2");
                }
                );

        }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<BookAppointment> bookAppointments { get; set; }
    }
}
