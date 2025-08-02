using Gradify.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Gradify.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<RegistrationArchive> RegistrationArchives { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<SemesterCourseSettings> SemesterCourseSettings { get; set; }
        public DbSet<Exam> Exams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Student
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(s => s.Id);

                entity.Property(s => s.Id)
                      .ValueGeneratedNever(); // 👈 هنا بنوقف Auto-Generation

                entity.Property(s => s.Name).IsRequired().HasMaxLength(100); 
                entity.Property(s => s.Status).HasConversion<string>().HasMaxLength(50);

                entity.HasMany(s => s.RegistrationArchives)
                      .WithOne(r => r.Student)
                      .HasForeignKey(r => r.StudentId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(s => s.Registrations)
                      .WithOne(r => r.Student)
                      .HasForeignKey(r => r.StudentId)
                      .OnDelete(DeleteBehavior.Cascade);
            });


            // Course
            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(c => c.Code);

                entity.Property(c => c.Code).HasMaxLength(20).IsRequired();
                entity.Property(c => c.Name).HasMaxLength(100).IsRequired();

                entity.HasMany(c => c.RegistrationArchives)
                      .WithOne(r => r.Course)
                      .HasForeignKey(r => r.CourseCode);

                entity.HasMany(c => c.Registrations)
                      .WithOne(r => r.Course)
                      .HasForeignKey(r => r.CourseCode);

                entity.HasMany(c => c.SemesterCourseSettings)
                      .WithOne(s => s.Course)
                      .HasForeignKey(s => s.CourseCode);
            });

            // Semester
            modelBuilder.Entity<Semester>(entity =>
            {
                entity.HasKey(s => s.SemesterName);

                entity.Property(s => s.SemesterName)
                      .HasMaxLength(50)
                      .IsRequired()
                      .ValueGeneratedNever(); // 👈 انتي اللي تدخلي القيمة

                entity.Property(s => s.StartDate).IsRequired();
                entity.Property(s => s.EndDate).IsRequired();

                entity.HasMany(s => s.RegistrationArchives)
                      .WithOne(r => r.Semester)
                      .HasForeignKey(r => r.SemesterName);

                entity.HasMany(s => s.Registrations)
                      .WithOne(r => r.Semester)
                      .HasForeignKey(r => r.SemesterName);

                entity.HasMany(s => s.SemesterCourseSettings)
                      .WithOne(scs => scs.Semester)
                      .HasForeignKey(scs => scs.SemesterName);
            });

            // SemesterCourseSettings
            modelBuilder.Entity<SemesterCourseSettings>(entity =>
            {
                entity.HasKey(s => new { s.CourseCode, s.SemesterName });

                entity.Property(s => s.CourseWorkValue).IsRequired();
                entity.Property(s => s.FinalValue).IsRequired();
            });

            // RegistrationArchive
            modelBuilder.Entity<RegistrationArchive>(entity =>
            {
                entity.HasKey(r => r.Id);

                entity.Property(r => r.Grade)
                      .HasConversion<string>()         // 👈 نخزن enum كـ string
                      .HasMaxLength(10)                
                      .IsRequired(false);              // optional لو ممكن تكون null

                entity.HasMany(r => r.Exams)
                      .WithOne(e => e.RegistrationArchive)
                      .HasForeignKey(e => e.RegistrationAID)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Registration
            modelBuilder.Entity<Registration>(entity =>
            {
                entity.HasKey(r => r.Id);

                entity.Property(r => r.Grade)
                      .HasConversion<string>()         
                      .HasMaxLength(10)
                      .IsRequired(false);              

                entity.HasMany(r => r.Exams)
                      .WithOne(e => e.Registration)
                      .HasForeignKey(e => e.RegistrationID)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Exam
            modelBuilder.Entity<Exam>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);

                entity.Property(e => e.IsSame).IsRequired();

                entity.HasOne(e => e.Registration)
                      .WithMany(r => r.Exams)
                      .HasForeignKey(e => e.RegistrationID)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.RegistrationArchive)
                      .WithMany(r => r.Exams)
                      .HasForeignKey(e => e.RegistrationAID)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }

}
