using System;
using E_LearningBackendAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace E_LearningBackendAPI.Contexts
{
    public class ELearningDBContext : DbContext
    {
        public ELearningDBContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<CourseCategory> CourseCategories { get; set; }


    }
}
