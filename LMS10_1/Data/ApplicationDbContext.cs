using LMS10_1.Models;
using LMS10_1.Models.ViewModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;


namespace LMS10_1.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // DbSets

        public DbSet<Student> Students { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<feedback> feedbacks { get; set; }
        public DbSet<TeacherRequests> TeacherRequestss { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> orderItems { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<ContactUs> contactUs { get; set; }
        public DbSet<Teacher> Teachers { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);



            // العلاقة بين TeacherRequests و Category (Many-to-One)
            builder.Entity<TeacherRequests>()
        .HasOne(tr => tr.Category)
        .WithMany(c => c.TeacherRequests) // ربط العلاقة مع خاصية TeacherRequests في Category
        .HasForeignKey(tr => tr.CategoryId)
        .OnDelete(DeleteBehavior.Restrict);

            // العلاقة Many-to-Many بين Students و Courses
            builder.Entity<StudentCourse>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId });

            builder.Entity<StudentCourse>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.Courses)
                .HasForeignKey(sc => sc.StudentId);

            builder.Entity<StudentCourse>()
                .HasOne(sc => sc.Course)
                .WithMany(c => c.Students)
                .HasForeignKey(sc => sc.CourseId);

            // العلاقة بين Lessons و Courses (Many-to-One)
            builder.Entity<Lesson>()
                .HasOne(l => l.Course)
                .WithMany(c => c.Lessons)
                .HasForeignKey(l => l.CoursesId);

            // العلاقة بين Courses و Categories (Many-to-One)
            builder.Entity<Courses>()
         .HasOne(c => c.Category)
         .WithMany(cat => cat.Courses)
         .HasForeignKey(c => c.CategoryId)
         .OnDelete(DeleteBehavior.Cascade);
            // إذا حُذفت الفئة، تحذف الدورات المرتبطة بها
            builder.Entity<Teacher>()
           .HasOne(t => t.Category)
           .WithMany(c => c.Teachers)
           .HasForeignKey(t => t.CategoryId)
           .OnDelete(DeleteBehavior.SetNull); // عند حذف الفئة، يبقى المعلم بدون فئة


          


        }
    }
}