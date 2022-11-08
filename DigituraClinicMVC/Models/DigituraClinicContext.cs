using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DigituraClinicMVC.Models
{
    public partial class DigituraClinicContext : DbContext
    {
        public DigituraClinicContext()
        {
        }

        public DigituraClinicContext(DbContextOptions<DigituraClinicContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DoctorList> DoctorLists { get; set; } = null!;
        public virtual DbSet<PatientList> PatientLists { get; set; } = null!;
        public virtual DbSet<ScheduleAppointment> ScheduleAppointments { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-GAPI6062\\SQLEXPRESS01;Database=DigituraClinic;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DoctorList>(entity =>
            {
                entity.HasKey(e => e.DoctorId)
                    .HasName("PK__DoctorLi__2DC00EDF46AEBFC8");

                entity.ToTable("DoctorList");

                entity.Property(e => e.DoctorId).HasColumnName("DoctorID");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Sex)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Specialization)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.VisitingHours)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PatientList>(entity =>
            {
                entity.HasKey(e => e.PatientId)
                    .HasName("PK__PatientL__970EC346EEF4808B");

                entity.ToTable("PatientList");

                entity.Property(e => e.PatientId).HasColumnName("PatientID");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Sex)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ScheduleAppointment>(entity =>
            {
                entity.HasKey(e => e.AppointmentNumber)
                    .HasName("PK__Schedule__23EF3BAE7616B5B8");

                entity.ToTable("ScheduleAppointment");

                entity.Property(e => e.AppointmentDate).HasColumnType("date");

                entity.Property(e => e.AppointmentTime)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.DoctorId).HasColumnName("DoctorID");

                entity.Property(e => e.PatientId).HasColumnName("PatientID");

                entity.Property(e => e.Specialization)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserName)
                    .HasName("PK_UserName");

                entity.Property(e => e.UserName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
