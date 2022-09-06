using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Hospital_Management_WebApi.Models.Context
{
    public partial class HospitalManagementContext : DbContext
    {
        public HospitalManagementContext()
        {
        }

        public HospitalManagementContext(DbContextOptions<HospitalManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<DoctorLogin> DoctorLogins { get; set; }
        public virtual DbSet<PatientBooking> PatientBookings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-MF59KDK\\SQLEXPRESS;Database=HospitalManagement;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DoctorCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DoctorDesignation)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DoctorName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DoctorLogin>(entity =>
            {
                entity.HasKey(e => e.LoginId)
                    .HasName("PK__DoctorLo__4DDA28183163441A");

                entity.ToTable("DoctorLogin");

                entity.Property(e => e.DoctorId)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.DoctorPassword)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Id).HasColumnName("id");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.DoctorLogins)
                    .HasForeignKey(d => d.Id)
                    .HasConstraintName("FK__DoctorLogin__id__5CD6CB2B");
            });

            modelBuilder.Entity<PatientBooking>(entity =>
            {
                entity.ToTable("PatientBooking");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ChooseDoctorType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Locality)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("status");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
