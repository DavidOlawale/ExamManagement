
using ExamManagement.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamManagement.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            // Apply pending migrations if there are any
            Database.Migrate();
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<CourseSubject> CourseSubjects { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Student>()
                .HasIndex(p => new { p.FirstName, p.LastName })
                .IsUnique();

            builder.Entity<Subject>()
                .HasIndex(p => p.Name)
                .IsUnique();

            builder.Entity<Course>()
                .HasIndex(p => p.Name)
                .IsUnique();

            builder.Entity<CourseSubject>()
                .HasIndex(p => new { p.CourseId, p.SubjectId })
                .IsUnique();
        }
    }

}
