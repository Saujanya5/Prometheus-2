using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Prometheus_MVC.Models;

#nullable disable

namespace Prometheus_MVC.Model
{
    public partial class PROJECT_SPRINT1Context : DbContext
    {
        public PROJECT_SPRINT1Context()
        {
        }

        public PROJECT_SPRINT1Context(DbContextOptions<PROJECT_SPRINT1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Assignment> Assignments { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Enrollment> Enrollments { get; set; }
        public virtual DbSet<Homework> Homeworks { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Teach> Teaches { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=.\\sqlexpress;Trusted_Connection=True;Database=PROJECT_SPRINT1");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Assignment>(entity =>
            {
                entity.HasKey(e => new { e.HomeWorkId, e.TeacherId, e.CourseId })
                    .HasName("PK__Assignme__1C8A785DD0D14792");

                entity.ToTable("Assignment");

                entity.Property(e => e.HomeWorkId)
                    .HasColumnType("numeric(5, 0)")
                    .HasColumnName("HomeWorkID");

                entity.Property(e => e.TeacherId)
                    .HasColumnType("numeric(5, 0)")
                    .HasColumnName("TeacherID");

                entity.Property(e => e.CourseId)
                    .HasColumnType("numeric(5, 0)")
                    .HasColumnName("CourseID");

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Assignments)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Assignmen__Cours__46E78A0C");

                entity.HasOne(d => d.HomeWork)
                    .WithMany(p => p.Assignments)
                    .HasForeignKey(d => d.HomeWorkId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Assignmen__HomeW__47DBAE45");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(e => e.CourseId)
                    .HasColumnType("numeric(5, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CourseID");

                entity.Property(e => e.CourseName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Enrollment>(entity =>
            {
                entity.HasKey(e => new { e.StudentId, e.CourseId })
                    .HasName("PK__Enrollme__5E57FD61E27A644E");

                entity.ToTable("Enrollment");

                entity.Property(e => e.StudentId)
                    .HasColumnType("numeric(5, 0)")
                    .HasColumnName("StudentID");

                entity.Property(e => e.CourseId)
                    .HasColumnType("numeric(5, 0)")
                    .HasColumnName("CourseID");

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Enrollments)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Enrollmen__Cours__412EB0B6");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Enrollments)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Enrollmen__Stude__4222D4EF");
            });

            modelBuilder.Entity<Homework>(entity =>
            {
                entity.ToTable("Homework");

                entity.Property(e => e.HomeWorkId)
                    .HasColumnType("numeric(5, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("HomeWorkID");

                entity.Property(e => e.Deadline).HasColumnType("date");

                entity.Property(e => e.Description)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LongDescription)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.StudentId)
                    .HasColumnType("numeric(5, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("StudentID");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB");

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("FName");

                entity.Property(e => e.Lname)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("LName");

                entity.Property(e => e.MobileNo).HasColumnType("numeric(10, 0)");

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Teach>(entity =>
            {
                entity.HasKey(e => new { e.TeacherId, e.CourseId })
                    .HasName("PK__Teaches__81608E5CD8B8E599");

                entity.Property(e => e.TeacherId)
                    .HasColumnType("numeric(5, 0)")
                    .HasColumnName("TeacherID");

                entity.Property(e => e.CourseId)
                    .HasColumnType("numeric(5, 0)")
                    .HasColumnName("CourseID");

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Teaches)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Teaches__CourseI__3E52440B");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Teaches)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Teaches__Teacher__3D5E1FD2");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.ToTable("Teacher");

                entity.Property(e => e.TeacherId)
                    .HasColumnType("numeric(5, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("TeacherID");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB");

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("FName");

                entity.Property(e => e.Lname)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("LName");

                entity.Property(e => e.MobileNo).HasColumnType("numeric(10, 0)");

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<Prometheus_MVC.Models.CourseViewModel> CourseViewModel { get; set; }

        public DbSet<Prometheus_MVC.Models.HomeworkViewModel> HomeworkViewModel { get; set; }

        public DbSet<Prometheus_MVC.Models.StudentViewModel> StudentViewModel { get; set; }

        public DbSet<Prometheus_MVC.Models.TeacherViewModel> TeacherViewModel { get; set; }
    }
}
