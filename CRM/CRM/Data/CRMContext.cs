using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CRM.Data
{
    public partial class CRMContext : DbContext
    {
        public CRMContext()
        {
        }

        public CRMContext(DbContextOptions<CRMContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Floors> Floors { get; set; }
        public virtual DbSet<Houses> Houses { get; set; }
        public virtual DbSet<OperationLogs> OperationLogs { get; set; }
        public virtual DbSet<Provinces> Provinces { get; set; }
        public virtual DbSet<RoomCategories> RoomCategories { get; set; }
        public virtual DbSet<Rooms> Rooms { get; set; }
        public virtual DbSet<SchoolClasses> SchoolClasses { get; set; }
        public virtual DbSet<Schools> Schools { get; set; }
        public virtual DbSet<SelectStationPeriods> SelectStationPeriods { get; set; }
        public virtual DbSet<Specialties> Specialties { get; set; }
        public virtual DbSet<Stations> Stations { get; set; }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<Teachers> Teachers { get; set; }
        public virtual DbSet<TrainClasses> TrainClasses { get; set; }

        // Unable to generate entity type for table 'dbo.SelectStationLogs'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.SpecialtyStations'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.TrainClassRooms'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.TrainClassStudents'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.TrainClassTeachers'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source =.; Database = CRM; Integrated Security = True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Floors>(entity =>
            {
                entity.HasKey(e => e.FId);

                entity.Property(e => e.FId).HasColumnName("F_ID");

                entity.Property(e => e.FMaleOrFemale).HasColumnName("F_MaleOrFemale");

                entity.Property(e => e.FName)
                    .IsRequired()
                    .HasColumnName("F_Name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FRemark)
                    .HasColumnName("F_Remark")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.HId).HasColumnName("H_ID");

                entity.HasOne(d => d.H)
                    .WithMany(p => p.Floors)
                    .HasForeignKey(d => d.HId)
                    .HasConstraintName("FK_FLOORS_REFERENCE_HOUSES");
            });

            modelBuilder.Entity<Houses>(entity =>
            {
                entity.HasKey(e => e.HId);

                entity.Property(e => e.HId).HasColumnName("H_ID");

                entity.Property(e => e.HMaleOrFemale).HasColumnName("H_MaleOrFemale");

                entity.Property(e => e.HName)
                    .IsRequired()
                    .HasColumnName("H_Name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.HRemark)
                    .HasColumnName("H_Remark")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OperationLogs>(entity =>
            {
                entity.HasKey(e => e.PlId);

                entity.Property(e => e.PlId).HasColumnName("PL_ID");

                entity.Property(e => e.PlDescription)
                    .HasColumnName("PL_Description")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PlOperation)
                    .HasColumnName("PL_Operation")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PlTableName)
                    .HasColumnName("PL_TableName")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PlTime)
                    .HasColumnName("PL_Time")
                    .HasColumnType("datetime");

                entity.Property(e => e.TId).HasColumnName("T_ID");

                entity.HasOne(d => d.T)
                    .WithMany(p => p.OperationLogs)
                    .HasForeignKey(d => d.TId)
                    .HasConstraintName("FK_OPERATIO_REFERENCE_TEACHERS");
            });

            modelBuilder.Entity<Provinces>(entity =>
            {
                entity.HasKey(e => e.PId);

                entity.Property(e => e.PId).HasColumnName("P_ID");

                entity.Property(e => e.PName)
                    .IsRequired()
                    .HasColumnName("P_Name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PRemark)
                    .HasColumnName("P_Remark")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RoomCategories>(entity =>
            {
                entity.HasKey(e => e.RcId);

                entity.Property(e => e.RcId).HasColumnName("RC_ID");

                entity.Property(e => e.RcCount).HasColumnName("RC_Count");

                entity.Property(e => e.RcMoneyPerMonth)
                    .HasColumnName("RC_MoneyPerMonth")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.RcName)
                    .IsRequired()
                    .HasColumnName("RC_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Rooms>(entity =>
            {
                entity.HasKey(e => e.RId);

                entity.Property(e => e.RId).HasColumnName("R_ID");

                entity.Property(e => e.FId).HasColumnName("F_ID");

                entity.Property(e => e.RIsHasFull).HasColumnName("R_IsHasFull");

                entity.Property(e => e.RMaleOrFemale).HasColumnName("R_MaleOrFemale");

                entity.Property(e => e.RName)
                    .IsRequired()
                    .HasColumnName("R_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RcId).HasColumnName("RC_ID");

                entity.HasOne(d => d.F)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.FId)
                    .HasConstraintName("FK_ROOMS_REFERENCE_FLOORS");

                entity.HasOne(d => d.Rc)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.RcId)
                    .HasConstraintName("FK_ROOMS_REFERENCE_ROOMCATE");
            });

            modelBuilder.Entity<SchoolClasses>(entity =>
            {
                entity.HasKey(e => e.ScId);

                entity.Property(e => e.ScId).HasColumnName("SC_ID");

                entity.Property(e => e.ScFemaleAmount).HasColumnName("SC_FemaleAmount");

                entity.Property(e => e.ScMaleAmount).HasColumnName("SC_MaleAmount");

                entity.Property(e => e.ScName)
                    .HasColumnName("SC_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ScSupervisor)
                    .HasColumnName("SC_Supervisor")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ScTeacher)
                    .HasColumnName("SC_Teacher")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SchoolId).HasColumnName("School_ID");

                entity.Property(e => e.SpecialtyId).HasColumnName("Specialty_ID");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.SchoolClasses)
                    .HasForeignKey(d => d.SchoolId)
                    .HasConstraintName("FK_SCHOOLCL_REFERENCE_SCHOOLS");

                entity.HasOne(d => d.Specialty)
                    .WithMany(p => p.SchoolClasses)
                    .HasForeignKey(d => d.SpecialtyId)
                    .HasConstraintName("FK_SCHOOLCL_REFERENCE_SPECIALT");
            });

            modelBuilder.Entity<Schools>(entity =>
            {
                entity.HasKey(e => e.SchoolId);

                entity.Property(e => e.SchoolId).HasColumnName("School_ID");

                entity.Property(e => e.PId).HasColumnName("P_ID");

                entity.Property(e => e.SchoolCode)
                    .IsRequired()
                    .HasColumnName("School_Code")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SchoolName)
                    .IsRequired()
                    .HasColumnName("School_Name")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.SchoolRemark)
                    .HasColumnName("School_Remark")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.P)
                    .WithMany(p => p.Schools)
                    .HasForeignKey(d => d.PId)
                    .HasConstraintName("FK_SCHOOLS_REFERENCE_PROVINCE");
            });

            modelBuilder.Entity<SelectStationPeriods>(entity =>
            {
                entity.HasKey(e => e.SspId);

                entity.Property(e => e.SspId).HasColumnName("SSP_ID");

                entity.Property(e => e.SchoolId).HasColumnName("School_ID");

                entity.Property(e => e.SpecialtyId).HasColumnName("Specialty_ID");

                entity.Property(e => e.SspOverDay).HasColumnName("SSP_OverDay");

                entity.Property(e => e.SspPreachDate)
                    .HasColumnName("SSP_PreachDate")
                    .HasColumnType("date");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.SelectStationPeriods)
                    .HasForeignKey(d => d.SchoolId)
                    .HasConstraintName("FK_SELECTST_REFERENCE_SCHOOLS");

                entity.HasOne(d => d.Specialty)
                    .WithMany(p => p.SelectStationPeriods)
                    .HasForeignKey(d => d.SpecialtyId)
                    .HasConstraintName("FK_SELECTST_REFERENCE_SPECIALT");
            });

            modelBuilder.Entity<Specialties>(entity =>
            {
                entity.HasKey(e => e.SpecialtyId);

                entity.Property(e => e.SpecialtyId).HasColumnName("Specialty_ID");

                entity.Property(e => e.SpecialtyDescription)
                    .HasColumnName("Specialty_Description")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.SpecialtyName)
                    .IsRequired()
                    .HasColumnName("Specialty_Name")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Stations>(entity =>
            {
                entity.HasKey(e => e.StationId);

                entity.Property(e => e.StationId).HasColumnName("Station_ID");

                entity.Property(e => e.StationDuty)
                    .IsRequired()
                    .HasColumnName("Station_Duty")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.StationName)
                    .IsRequired()
                    .HasColumnName("Station_Name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StationNeedTechnique)
                    .IsRequired()
                    .HasColumnName("Station_NeedTechnique")
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Students>(entity =>
            {
                entity.HasKey(e => e.StudentId);

                entity.Property(e => e.StudentId).HasColumnName("Student_ID");

                entity.Property(e => e.ScId).HasColumnName("SC_ID");

                entity.Property(e => e.StationId).HasColumnName("Station_ID");

                entity.Property(e => e.StationtSelectStationCount)
                    .HasColumnName("Stationt_SelectStationCount")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.StudentAddress)
                    .HasColumnName("Student_Address")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.StudentEducation)
                    .HasColumnName("Student_Education")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StudentEducationMoney)
                    .HasColumnName("Student_EducationMoney")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StudentEvaluate1)
                    .HasColumnName("Student_Evaluate1")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.StudentEvaluate2)
                    .HasColumnName("Student_Evaluate2")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.StudentExam)
                    .HasColumnName("Student_Exam")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StudentFamilyTel)
                    .HasColumnName("Student_FamilyTel")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StudentIdentityNumber)
                    .HasColumnName("Student_IdentityNumber")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StudentName)
                    .HasColumnName("Student_Name")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.StudentNameSpell)
                    .HasColumnName("Student_NameSpell")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StudentNo)
                    .HasColumnName("Student_NO")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StudentPersonalTel)
                    .HasColumnName("Student_PersonalTel")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StudentPostCode)
                    .HasColumnName("Student_PostCode")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.StudentQq)
                    .HasColumnName("Student_QQ")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StudentRemark)
                    .HasColumnName("Student_Remark")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.StudentSchoolofgraduation)
                    .HasColumnName("Student_Schoolofgraduation")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StudentSex)
                    .HasColumnName("Student_Sex")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.StudentSkillTrainingMoney)
                    .HasColumnName("Student_SkillTrainingMoney")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StudentSpecialty)
                    .HasColumnName("Student_Specialty")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StudentState)
                    .HasColumnName("Student_State")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StudentTrainResideMoney)
                    .HasColumnName("Student_TrainResideMoney")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Sc)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.ScId)
                    .HasConstraintName("FK_STUDENTS_REFERENCE_SCHOOLCL");

                entity.HasOne(d => d.Station)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.StationId)
                    .HasConstraintName("FK_STUDENTS_REFERENCE_STATIONS");
            });

            modelBuilder.Entity<Teachers>(entity =>
            {
                entity.HasKey(e => e.TId);

                entity.Property(e => e.TId).HasColumnName("T_ID");

                entity.Property(e => e.TCategory).HasColumnName("T_Category");

                entity.Property(e => e.TIsEnabled).HasColumnName("T_IsEnabled");

                entity.Property(e => e.TLastLoginTime)
                    .HasColumnName("T_LastLoginTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.TLoginName)
                    .IsRequired()
                    .HasColumnName("T_LoginName")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TName)
                    .IsRequired()
                    .HasColumnName("T_Name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TPwd)
                    .IsRequired()
                    .HasColumnName("T_Pwd")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TRole).HasColumnName("T_Role");

                entity.Property(e => e.TSex)
                    .IsRequired()
                    .HasColumnName("T_Sex")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.TTel)
                    .IsRequired()
                    .HasColumnName("T_Tel")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TrainClasses>(entity =>
            {
                entity.HasKey(e => e.TcId);

                entity.Property(e => e.TcId).HasColumnName("TC_ID");

                entity.Property(e => e.TcBeginTime)
                    .HasColumnName("TC_BeginTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.TcEndTime)
                    .HasColumnName("TC_EndTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.TcFemaleAmount).HasColumnName("TC_FemaleAmount");

                entity.Property(e => e.TcGrade)
                    .IsRequired()
                    .HasColumnName("TC_Grade")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TcMaleAmount).HasColumnName("TC_MaleAmount");

                entity.Property(e => e.TcMaxAmount).HasColumnName("TC_MaxAmount");

                entity.Property(e => e.TcName)
                    .IsRequired()
                    .HasColumnName("TC_Name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TcPeriod).HasColumnName("TC_Period");
            });
        }
    }
}
