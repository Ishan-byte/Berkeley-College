using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace berkeley_college.Models
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Assignment> Assignment { get; set; }
        public virtual DbSet<Departments> Departments { get; set; }
        public virtual DbSet<Module> Module { get; set; }
        public virtual DbSet<ModuleStudent> ModuleStudent { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<PersonAddressInfo> PersonAddressInfo { get; set; }
        public virtual DbSet<ResultInfo> ResultInfo { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<StudentAttendenceInfo> StudentAttendenceInfo { get; set; }
        public virtual DbSet<StudentFeePayment> StudentFeePayment { get; set; }
        public virtual DbSet<Teacher> Teacher { get; set; }
        public virtual DbSet<TeacherModuleInfo> TeacherModuleInfo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
 //               optionsBuilder.UseOracle("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=xe)));User ID=berkeley_college;Password=coursework;Persist Security Info=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:DefaultSchema", "BERKELEY_COLLEGE");

            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("ADDRESS");

                entity.Property(e => e.AddressId)
                    .HasColumnName("ADDRESS_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("CITY")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasColumnName("COUNTRY")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.PostalCode)
                    .HasColumnName("POSTAL_CODE")
                    .HasColumnType("NUMBER(38)");
            });

            modelBuilder.Entity<Assignment>(entity =>
            {
                entity.ToTable("ASSIGNMENT");

                entity.Property(e => e.AssignmentId)
                    .HasColumnName("ASSIGNMENT_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.AssignmentType)
                    .IsRequired()
                    .HasColumnName("ASSIGNMENT_TYPE")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.DepartmentId)
                    .IsRequired()
                    .HasColumnName("DEPARTMENT_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModuleId)
                    .IsRequired()
                    .HasColumnName("MODULE_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Assignment)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ASSIGNMENT_DEPARTMENTS_FK");

                entity.HasOne(d => d.Module)
                    .WithMany(p => p.Assignment)
                    .HasForeignKey(d => d.ModuleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ASSIGNMENT_MODULE_FK");
            });

            modelBuilder.Entity<Departments>(entity =>
            {
                entity.HasKey(e => e.DepartmentId)
                    .HasName("DEPARTMENTS_PK");

                entity.ToTable("DEPARTMENTS");

                entity.Property(e => e.DepartmentId)
                    .HasColumnName("DEPARTMENT_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DepartmentName)
                    .IsRequired()
                    .HasColumnName("DEPARTMENT_NAME")
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Module>(entity =>
            {
                entity.ToTable("MODULE");

                entity.Property(e => e.ModuleId)
                    .HasColumnName("MODULE_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModuleCode)
                    .IsRequired()
                    .HasColumnName("MODULE_CODE")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.ModuleCredit)
                    .HasColumnName("MODULE_CREDIT")
                    .HasColumnType("NUMBER(38)");

                entity.Property(e => e.ModuleName)
                    .IsRequired()
                    .HasColumnName("MODULE_NAME")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.ModuleTeachingDays)
                    .HasColumnName("MODULE_TEACHING_DAYS")
                    .HasColumnType("NUMBER(38)");
            });

            modelBuilder.Entity<ModuleStudent>(entity =>
            {
                entity.HasKey(e => new { e.ModuleId, e.StudentId })
                    .HasName("MODULE_STUDENT_PK");

                entity.ToTable("MODULE_STUDENT");

                entity.Property(e => e.ModuleId)
                    .HasColumnName("MODULE_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.StudentId)
                    .HasColumnName("STUDENT_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Module)
                    .WithMany(p => p.ModuleStudent)
                    .HasForeignKey(d => d.ModuleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("MODULE_STUDENT_MODULE_FK");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.ModuleStudent)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("MODULE_STUDENT_STUDENT_FK");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("PERSON");

                entity.Property(e => e.PersonId)
                    .HasColumnName("PERSON_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.EMail)
                    .IsRequired()
                    .HasColumnName("E-mail")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("FIRST_NAME")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("LAST_NAME")
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PersonAddressInfo>(entity =>
            {
                entity.HasKey(e => new { e.PersonId, e.AddressId })
                    .HasName("PERSON_ADDRESS_INFO_PK");

                entity.ToTable("PERSON_ADDRESS_INFO");

                entity.Property(e => e.PersonId)
                    .HasColumnName("PERSON_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.AddressId)
                    .HasColumnName("ADDRESS_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.PersonAddressInfo)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PERSON_ADDRESS_INFO_ADDRESS_FK");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonAddressInfo)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PERSON_ADDRESS_INFO_PERSON_FK");
            });

            modelBuilder.Entity<ResultInfo>(entity =>
            {
                entity.HasKey(e => e.ResultId)
                    .HasName("EXAM_INFO_PK");

                entity.ToTable("RESULT_INFO");

                entity.Property(e => e.ResultId)
                    .HasColumnName("RESULT_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.AssignmentId)
                    .IsRequired()
                    .HasColumnName("ASSIGNMENT_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Grade)
                    .IsRequired()
                    .HasColumnName("GRADE")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("STATUS")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.StudentId)
                    .IsRequired()
                    .HasColumnName("STUDENT_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Assignment)
                    .WithMany(p => p.ResultInfo)
                    .HasForeignKey(d => d.AssignmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("EXAM_INFO_ASSIGNMENT_FK");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.ResultInfo)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RESULT_INFO_STUDENT_FK");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.PersonId)
                    .HasName("STUDENT_PK");

                entity.ToTable("STUDENT");

                entity.Property(e => e.PersonId)
                    .HasColumnName("PERSON_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.StudentYear)
                    .HasColumnName("STUDENT_YEAR")
                    .HasColumnType("NUMBER(38)");

                entity.HasOne(d => d.Person)
                    .WithOne(p => p.Student)
                    .HasForeignKey<Student>(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("STUDENT_PERSON_FK");
            });

            modelBuilder.Entity<StudentAttendenceInfo>(entity =>
            {
                entity.HasKey(e => new { e.StudentId, e.ModuleId })
                    .HasName("STUDENT_ATTENDENCE_INFO_PK");

                entity.ToTable("STUDENT_ATTENDENCE_INFO");

                entity.Property(e => e.StudentId)
                    .HasColumnName("STUDENT_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModuleId)
                    .HasColumnName("MODULE_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.AttendanceDate)
                    .HasColumnName("ATTENDANCE_DATE")
                    .HasColumnType("DATE");

                entity.Property(e => e.DepartmentId)
                    .IsRequired()
                    .HasColumnName("DEPARTMENT_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.StudentAttendenceInfo)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ATTENDENCE_DEPARTMENTS_FK");

                entity.HasOne(d => d.Module)
                    .WithMany(p => p.StudentAttendenceInfo)
                    .HasForeignKey(d => d.ModuleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ATTENDENCE_MODULE_FK");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentAttendenceInfo)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ATTENDENCE_STUDENT_FK");
            });

            modelBuilder.Entity<StudentFeePayment>(entity =>
            {
                entity.HasKey(e => e.PaymentId)
                    .HasName("STUDENT_FEE_PAYMENT_PK");

                entity.ToTable("STUDENT_FEE_PAYMENT");

                entity.Property(e => e.PaymentId)
                    .HasColumnName("PAYMENT_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Amount)
                    .HasColumnName("AMOUNT")
                    .HasColumnType("NUMBER(38)");

                entity.Property(e => e.DepartmentId)
                    .IsRequired()
                    .HasColumnName("DEPARTMENT_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PaymentDate)
                    .HasColumnName("PAYMENT_DATE")
                    .HasColumnType("DATE");

                entity.Property(e => e.StudentId)
                    .IsRequired()
                    .HasColumnName("STUDENT_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Year)
                    .HasColumnName("YEAR")
                    .HasColumnType("NUMBER(38)");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.StudentFeePayment)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PAYMENT_DEPARTMENTS_FK");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentFeePayment)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("STUDENT_FEE_PAYMENT_STUDENT_FK");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.HasKey(e => e.PersonId)
                    .HasName("TEACHER_PK");

                entity.ToTable("TEACHER");

                entity.Property(e => e.PersonId)
                    .HasColumnName("PERSON_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Salary)
                    .HasColumnName("SALARY")
                    .HasColumnType("NUMBER(38)");

                entity.Property(e => e.TeacherType)
                    .IsRequired()
                    .HasColumnName("TEACHER_TYPE")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.Person)
                    .WithOne(p => p.Teacher)
                    .HasForeignKey<Teacher>(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TEACHER_PERSON_FK");
            });

            modelBuilder.Entity<TeacherModuleInfo>(entity =>
            {
                entity.HasKey(e => new { e.TeacherId, e.ModuleId })
                    .HasName("TEACHER_MODULE_INFO_PK");

                entity.ToTable("TEACHER_MODULE_INFO");

                entity.Property(e => e.TeacherId)
                    .HasColumnName("TEACHER_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModuleId)
                    .HasColumnName("MODULE_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Module)
                    .WithMany(p => p.TeacherModuleInfo)
                    .HasForeignKey(d => d.ModuleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TEACHER_MODULE_INFO_MODULE_FK");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.TeacherModuleInfo)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TEACHER_MODULE_INFO_TEACHER_FK");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
