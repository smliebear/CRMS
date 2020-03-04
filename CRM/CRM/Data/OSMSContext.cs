﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CRM.Data
{
    public partial class OSMSContext : DbContext
    {
        public OSMSContext()
        {
        }

        public OSMSContext(DbContextOptions<OSMSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Approver> Approver { get; set; }
        public virtual DbSet<Entry> Entry { get; set; }
        public virtual DbSet<Job> Job { get; set; }
        public virtual DbSet<LeaveOffice> LeaveOffice { get; set; }
        public virtual DbSet<OilMaterialOrder> OilMaterialOrder { get; set; }
        public virtual DbSet<OilMaterialOrderDetail> OilMaterialOrderDetail { get; set; }
        public virtual DbSet<OrganizationStructure> OrganizationStructure { get; set; }
        public virtual DbSet<ProcessItem> ProcessItem { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Staff> Staff { get; set; }
        public virtual DbSet<SystemResourceModule> SystemResourceModule { get; set; }

        // Unable to generate entity type for table 'dbo.ProcessStepRecord'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.RoleResourceModule'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.StaffRole'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("server=.;uid=sa;pwd=123;database=OSMS");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Approver>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Discrible).HasMaxLength(100);

                entity.Property(e => e.ExecuteMethod).HasMaxLength(100);

                entity.Property(e => e.JobCode)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.ProcessItem)
                    .WithMany(p => p.Approver)
                    .HasForeignKey(d => d.ProcessItemId)
                    .HasConstraintName("FK__Approver__Proces__5535A963");
            });

            modelBuilder.Entity<Entry>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Address).HasMaxLength(500);

                entity.Property(e => e.BankCardNumber).HasMaxLength(200);

                entity.Property(e => e.BirthCertificatePhoto).HasMaxLength(200);

                entity.Property(e => e.BirthDay).HasColumnType("date");

                entity.Property(e => e.CorrectSalary).HasMaxLength(50);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.EducationalExperience1Certificate).HasMaxLength(500);

                entity.Property(e => e.EducationalExperience1EndDate).HasColumnType("date");

                entity.Property(e => e.EducationalExperience1Major).HasMaxLength(500);

                entity.Property(e => e.EducationalExperience1SchoolName).HasMaxLength(500);

                entity.Property(e => e.EducationalExperience1StartDate).HasColumnType("date");

                entity.Property(e => e.EducationalExperience2Certificate).HasMaxLength(500);

                entity.Property(e => e.EducationalExperience2EndDate).HasColumnType("date");

                entity.Property(e => e.EducationalExperience2Major).HasMaxLength(500);

                entity.Property(e => e.EducationalExperience2SchoolName).HasMaxLength(500);

                entity.Property(e => e.EducationalExperience2StartDate).HasColumnType("date");

                entity.Property(e => e.EducationalExperience3Certificate).HasMaxLength(500);

                entity.Property(e => e.EducationalExperience3EndDate).HasColumnType("date");

                entity.Property(e => e.EducationalExperience3Major).HasMaxLength(500);

                entity.Property(e => e.EducationalExperience3SchoolName).HasMaxLength(500);

                entity.Property(e => e.EducationalExperience3StartDate).HasColumnType("date");

                entity.Property(e => e.EducationalExperience4Certificate).HasMaxLength(500);

                entity.Property(e => e.EducationalExperience4EndDate).HasColumnType("date");

                entity.Property(e => e.EducationalExperience4Major).HasMaxLength(500);

                entity.Property(e => e.EducationalExperience4SchoolName).HasMaxLength(500);

                entity.Property(e => e.EducationalExperience4StartDate).HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(500);

                entity.Property(e => e.EmergencyContactEelationShipWithMe).HasMaxLength(500);

                entity.Property(e => e.EmergencyContactName).HasMaxLength(500);

                entity.Property(e => e.EmergencyContactTel)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.EntryDate).HasColumnType("date");

                entity.Property(e => e.FamilyStatus1Appellation).HasMaxLength(500);

                entity.Property(e => e.FamilyStatus1Company).HasMaxLength(500);

                entity.Property(e => e.FamilyStatus1Name).HasMaxLength(500);

                entity.Property(e => e.FamilyStatus1Tel)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FamilyStatus2Appellation).HasMaxLength(500);

                entity.Property(e => e.FamilyStatus2Company).HasMaxLength(500);

                entity.Property(e => e.FamilyStatus2Name).HasMaxLength(500);

                entity.Property(e => e.FamilyStatus2Tel)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ForeginLanguageAptitude).HasMaxLength(500);

                entity.Property(e => e.Height).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.HobbiesAndSpeciality).HasMaxLength(500);

                entity.Property(e => e.IDNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Major).HasMaxLength(500);

                entity.Property(e => e.MedicalHistoryComment).HasMaxLength(500);

                entity.Property(e => e.NativePlace).HasMaxLength(500);

                entity.Property(e => e.No)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProbationarySalary).HasMaxLength(50);

                entity.Property(e => e.RegistrationPhoto).HasMaxLength(200);

                entity.Property(e => e.StaffName)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.StaffNo).HasMaxLength(100);

                entity.Property(e => e.SupervisorComments).HasMaxLength(500);

                entity.Property(e => e.Tel)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.WorkExperience1CompanyName).HasMaxLength(500);

                entity.Property(e => e.WorkExperience1EndDate).HasColumnType("date");

                entity.Property(e => e.WorkExperience1Job).HasMaxLength(500);

                entity.Property(e => e.WorkExperience1LeavingReasons).HasMaxLength(100);

                entity.Property(e => e.WorkExperience1Pay).HasMaxLength(50);

                entity.Property(e => e.WorkExperience1StartDate).HasColumnType("date");

                entity.Property(e => e.WorkExperience2CompanyName).HasMaxLength(500);

                entity.Property(e => e.WorkExperience2EndDate).HasColumnType("date");

                entity.Property(e => e.WorkExperience2Job).HasMaxLength(500);

                entity.Property(e => e.WorkExperience2LeavingReasons).HasMaxLength(100);

                entity.Property(e => e.WorkExperience2Pay).HasMaxLength(50);

                entity.Property(e => e.WorkExperience2StartDate).HasColumnType("date");

                entity.Property(e => e.WorkExperience3CompanyName).HasMaxLength(500);

                entity.Property(e => e.WorkExperience3EndDate).HasColumnType("date");

                entity.Property(e => e.WorkExperience3Job).HasMaxLength(500);

                entity.Property(e => e.WorkExperience3LeavingReasons).HasMaxLength(100);

                entity.Property(e => e.WorkExperience3Pay).HasMaxLength(50);

                entity.Property(e => e.WorkExperience3StartDate).HasColumnType("date");

                entity.Property(e => e.WorkExperience4CompanyName).HasMaxLength(500);

                entity.Property(e => e.WorkExperience4EndDate).HasColumnType("date");

                entity.Property(e => e.WorkExperience4Job).HasMaxLength(500);

                entity.Property(e => e.WorkExperience4LeavingReasons).HasMaxLength(100);

                entity.Property(e => e.WorkExperience4Pay).HasMaxLength(50);

                entity.Property(e => e.WorkExperience4StartDate).HasColumnType("date");

                entity.Property(e => e.WorkNumber).HasMaxLength(50);
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code).HasMaxLength(100);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<LeaveOffice>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ApplyDate).HasColumnType("date");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.ExplanationHandover).HasMaxLength(500);

                entity.Property(e => e.LeaveType)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.No).HasMaxLength(100);

                entity.Property(e => e.Reason).HasMaxLength(500);

                entity.Property(e => e.StaffName).HasMaxLength(100);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<OilMaterialOrder>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ApplyDate).HasColumnType("date");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.No)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Remark).HasMaxLength(500);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<OilMaterialOrderDetail>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.OilSpec).HasMaxLength(100);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OilMaterialOrderDetail)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OilMateri__Order__5812160E");
            });

            modelBuilder.Entity<OrganizationStructure>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<ProcessItem>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Discrible).HasMaxLength(100);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<Staff>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Address).HasMaxLength(500);

                entity.Property(e => e.BirthDay).HasColumnType("date");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.IsHSEGroup).HasDefaultValueSql("((0))");

                entity.Property(e => e.Name).HasMaxLength(500);

                entity.Property(e => e.NativePlace).HasMaxLength(500);

                entity.Property(e => e.No).HasMaxLength(500);

                entity.Property(e => e.Password).HasMaxLength(1000);

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Tel).HasMaxLength(20);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<SystemResourceModule>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Name).HasMaxLength(500);

                entity.Property(e => e.Url).HasMaxLength(1000);
            });
        }
    }
}
