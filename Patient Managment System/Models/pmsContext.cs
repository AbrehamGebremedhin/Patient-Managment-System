using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Patient_Managment_System.Models
{
    public partial class pmsContext : DbContext
    {
        public pmsContext()
        {
        }

        public pmsContext(DbContextOptions<pmsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointment> Appointments { get; set; } = null!;
        public virtual DbSet<Bill> Bills { get; set; } = null!;
        public virtual DbSet<Doctor> Doctors { get; set; } = null!;
        public virtual DbSet<Drug> Drug { get; set; } = null!;
        public virtual DbSet<OrderHistory> OrderHistories { get; set; } = null!;
        public virtual DbSet<Patient> Patients { get; set; } = null!;
        public virtual DbSet<PatientDiag> PatientDiags { get; set; } = null!;
        public virtual DbSet<Prescriptiondrug> Prescriptiondrugs { get; set; } = null!;
        public virtual DbSet<Prescriptiontest> Prescriptiontests { get; set; } = null!;
        public virtual DbSet<Test> Tests { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;port=3306;user=Abreham;password=bloodhair@125;database=pms", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.30-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.ToTable("appointments");

                entity.HasIndex(e => e.Id, "ID_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.DoctorId, "appointement_doctor_idx");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.DoctorId).HasColumnName("DoctorID");

                entity.Property(e => e.LastVisited).HasColumnName("lastVisited");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("appointement_doctor");
            });

            modelBuilder.Entity<Bill>(entity =>
            {
                entity.ToTable("bill");

                entity.HasIndex(e => e.Id, "id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.BillType)
                    .HasMaxLength(45)
                    .UseCollation("utf8mb4_bin");

                entity.Property(e => e.InvoiceAmount).HasPrecision(10);

                entity.Property(e => e.InvoiceTitle).HasPrecision(10);

                entity.Property(e => e.PaymentMode).HasMaxLength(45);

                entity.Property(e => e.Reference).HasColumnType("mediumtext");
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.ToTable("doctor");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.FridayFrom).HasMaxLength(45);

                entity.Property(e => e.FridayTo).HasMaxLength(45);

                entity.Property(e => e.MondayFrom).HasMaxLength(45);

                entity.Property(e => e.MondayTo).HasMaxLength(45);

                entity.Property(e => e.SaturdayFrom).HasMaxLength(45);

                entity.Property(e => e.SaturdayTo).HasMaxLength(45);

                entity.Property(e => e.Speciality).HasMaxLength(45);

                entity.Property(e => e.SundayFrom).HasMaxLength(45);

                entity.Property(e => e.SundayTo).HasMaxLength(45);

                entity.Property(e => e.ThursdayFrom).HasMaxLength(45);

                entity.Property(e => e.ThursdayTo).HasMaxLength(45);

                entity.Property(e => e.TuesdayFrom).HasMaxLength(45);

                entity.Property(e => e.TuesdayTo).HasMaxLength(45);

                entity.Property(e => e.WednesdayFrom).HasMaxLength(45);

                entity.Property(e => e.WednesdayTo).HasMaxLength(45);
            });

            modelBuilder.Entity<Drug>(entity =>
            {
                entity.HasKey(e => e.DId)
                    .HasName("PRIMARY");

                entity.ToTable("drugs");

                entity.HasIndex(e => e.GenericName, "GenericName_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Note, "Note_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Price, "Price_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.TradeName, "TradeName_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.DId, "dId_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.DId).HasColumnName("dId");

                entity.Property(e => e.ExpireDate).HasColumnType("datetime");

                entity.Property(e => e.GenericName).HasMaxLength(250);

                entity.Property(e => e.Note).HasMaxLength(300);

                entity.Property(e => e.Price).HasPrecision(10);

                entity.Property(e => e.TradeName).HasMaxLength(300);
            });

            modelBuilder.Entity<OrderHistory>(entity =>
            {
                entity.ToTable("order_history");

                entity.HasIndex(e => e.PatientId, "PatientId_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.History).HasMaxLength(450);

                entity.Property(e => e.LabOrder).HasMaxLength(450);

                entity.Property(e => e.PatientId).IsRequired();

                entity.Property(e => e.Symptoms).HasMaxLength(450);

                entity.Property(e => e.TestId).HasColumnName("Test_Id");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.ToTable("patient");

                entity.HasIndex(e => e.Email, "Email_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Id, "idpatient_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.AppointemtId, "patient_appintment_idx");

                entity.HasIndex(e => e.BillId, "patient_bill_idx");

                entity.HasIndex(e => e.DiagnosisId, "patient_diagnosis_idx");

                entity.HasIndex(e => e.OrderId, "patient_order_idx");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Address).HasMaxLength(45);

                entity.Property(e => e.AppointemtId).HasColumnName("AppointemtID");

                entity.Property(e => e.BillId).HasColumnName("billID");

                entity.Property(e => e.BloodType).HasMaxLength(45);

                entity.Property(e => e.Email).HasMaxLength(45);

                entity.Property(e => e.Fullname)
                    .HasColumnType("mediumtext")
                    .HasColumnName("FULLNAME");

                entity.Property(e => e.Gender).HasMaxLength(45);

                entity.Property(e => e.Password).HasMaxLength(45);

                entity.Property(e => e.Phone).HasMaxLength(45);

                entity.HasOne(d => d.Appointemt)
                    .WithMany(p => p.Patients)
                    .HasForeignKey(d => d.AppointemtId)
                    .HasConstraintName("patient_appintment");

                entity.HasOne(d => d.Bill)
                    .WithMany(p => p.Patients)
                    .HasForeignKey(d => d.BillId)
                    .HasConstraintName("patient_bill");

                entity.HasOne(d => d.Diagnosis)
                    .WithMany(p => p.Patients)
                    .HasForeignKey(d => d.DiagnosisId)
                    .HasConstraintName("patient_diagnosis");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Patients)
                    .HasPrincipalKey(p => p.PatientId)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("patient_order");
            });

            modelBuilder.Entity<PatientDiag>(entity =>
            {
                entity.HasKey(e => e.PatientId)
                    .HasName("PRIMARY");

                entity.ToTable("patient_diag");

                entity.HasIndex(e => e.PatientId, "PatientId_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Diagnosis).HasMaxLength(450);

                entity.Property(e => e.MedId).HasColumnName("MedID");

                entity.Property(e => e.MedicineOrder).HasMaxLength(450);
            });

            modelBuilder.Entity<Prescriptiondrug>(entity =>
            {
                entity.ToTable("prescriptiondrugs");

                entity.HasIndex(e => e.Id, "id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Advice).HasMaxLength(450);

                entity.Property(e => e.Dose).HasMaxLength(45);

                entity.Property(e => e.DrugId).HasColumnName("drugId");

                entity.Property(e => e.Duration).HasMaxLength(45);

                entity.Property(e => e.Type).HasMaxLength(450);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Prescriptiondrug)
                    .HasForeignKey<Prescriptiondrug>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("preDrugs_drug");
            });

            modelBuilder.Entity<Prescriptiontest>(entity =>
            {
                entity.ToTable("prescriptiontests");

                entity.HasIndex(e => e.Id, "ID_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Description).HasMaxLength(45);

                entity.Property(e => e.Result).HasMaxLength(4500);

                entity.Property(e => e.TestId)
                    .HasMaxLength(45)
                    .HasColumnName("testId");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Prescriptiontest)
                    .HasForeignKey<Prescriptiontest>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("preTests_test");
            });

            modelBuilder.Entity<Test>(entity =>
            {
                entity.ToTable("tests");

                entity.HasIndex(e => e.Id, "ID_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.TestName, "TestName_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Comment).HasMaxLength(450);

                entity.Property(e => e.Price).HasMaxLength(45);

                entity.Property(e => e.TestName).HasMaxLength(150);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.HasIndex(e => e.Id, "id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Did).HasColumnName("did");

                entity.Property(e => e.Email).HasMaxLength(45);

                entity.Property(e => e.Name).HasMaxLength(45);

                entity.Property(e => e.Password).HasMaxLength(45);

                entity.Property(e => e.RememberPhrase).HasMaxLength(45);

                entity.Property(e => e.Role).HasMaxLength(45);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
