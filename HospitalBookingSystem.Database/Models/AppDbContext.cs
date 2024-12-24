using Microsoft.EntityFrameworkCore;

namespace HospitalBookingSystem.Database.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    #region DbSet

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    #endregion

    #region Connetion String

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=HospitalAppointmentSystem;User Id=sa;Password=sasa@123;TrustServerCertificate=True;");

    #endregion

    #region OnModelCreating

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region Appointment

        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.AppointmentId).HasName("PK__Appointm__8ECDFCA2D21206D7");

            entity.ToTable("Appointment");

            entity.Property(e => e.AppointmentId)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("AppointmentID");
            entity.Property(e => e.DoctorId)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("DoctorID");
            entity.Property(e => e.PatientId)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("PatientID");
            entity.Property(e => e.Reason).HasColumnType("text");
            entity.Property(e => e.Remarks).HasColumnType("text");
            entity.Property(e => e.RoomNumber).HasMaxLength(10);
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.Doctor).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.DoctorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Appointme__Docto__3E52440B");

            entity.HasOne(d => d.Patient).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Appointme__Patie__3F466844");
        });

        #endregion

        #region Doctor

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasKey(e => e.DoctorId).HasName("PK__Doctor__2DC00EDF29E9635B");

            entity.ToTable("Doctor");

            entity.HasIndex(e => e.LicenseNumber, "UQ__Doctor__E8890166B5D13199").IsUnique();

            entity.Property(e => e.DoctorId)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("DoctorID");
            entity.Property(e => e.Department).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.IsAvailable).HasDefaultValue(true);
            entity.Property(e => e.LicenseNumber).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber).HasMaxLength(50);
            entity.Property(e => e.Specialization).HasMaxLength(100);
        });

        #endregion

        #region Patient

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.PatientId).HasName("PK__Patient__970EC34650800F63");

            entity.ToTable("Patient");

            entity.Property(e => e.PatientId)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("PatientID");
            entity.Property(e => e.Address).HasColumnType("text");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.EmergencyContact).HasMaxLength(100);
            entity.Property(e => e.Gender).HasMaxLength(10);
            entity.Property(e => e.InsuranceDetails).HasColumnType("text");
            entity.Property(e => e.MedicalHistory).HasColumnType("text");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.PhoneNumber).HasMaxLength(15);
        });

        #endregion

        OnModelCreatingPartial(modelBuilder);
    }

    #endregion

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
