using Microsoft.EntityFrameworkCore;
using System;
using UserModel;

namespace DbAPI.Data
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = Guid.NewGuid(),
                Name = "Ivan",
                Surname = "Ivanov",
                Email = "ivanov@mail.ru",
                Status = "Студент"
            });
        }
    }
}
