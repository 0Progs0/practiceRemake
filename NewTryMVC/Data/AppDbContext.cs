using Microsoft.EntityFrameworkCore;
using NewTryMVC.Models;

namespace NewTryMVC.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; } // проекция класса на таблицу для отслеживания состояния

        protected override void OnModelCreating(ModelBuilder modelBuilder) //переопределение стандартного метода
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(new User //при первой миграции база будет заполнена
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
