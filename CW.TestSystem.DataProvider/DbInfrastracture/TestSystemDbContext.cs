using System.Reflection;
using Microsoft.EntityFrameworkCore;
using CW.TestSystem.Model.CoreEntities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using CW.TestSystem.Model.RelationValueObjects;

namespace CW.TestSystem.DataProvider.DbInfrastracture
{
    public class TestSystemDbContext : IdentityDbContext<User, Role, Guid>
    {
        public TestSystemDbContext(DbContextOptions<TestSystemDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Test> Tests { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Result> Results { get; set; }
    }
}
