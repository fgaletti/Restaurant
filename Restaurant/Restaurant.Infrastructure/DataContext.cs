using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Repositories;
using Restaurant.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurant.Infrastructure
{
    public class DataContext : DbContext, IUnitOfWork
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<User > Users { get; set; }

        public DbSet<UserCourse> UserCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                modelBuilder.Entity<UserCourse>()
                    .HasKey(c => new { c.UserId, c.CourseId });

            // seed
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed<User>("./MockData/user.json");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
      
    }
}
