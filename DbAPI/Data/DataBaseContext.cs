using DbAPI.Models;
using Microsoft.EntityFrameworkCore;

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
                Id = 123123,
                Name = "Ivan",
                Surname = "Ivanov",
                Email = "ivanov@mail.ru",
                Status = "Студент"
            });
        }
    }
}
