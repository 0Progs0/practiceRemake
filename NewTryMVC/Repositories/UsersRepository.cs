using Microsoft.EntityFrameworkCore;
using NewTryMVC.Data;
using NewTryMVC.Models;
using System.Linq;

namespace NewTryMVC.Repositories
{
    public class UsersRepository
    {
        private readonly AppDbContext context;

        public UsersRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<User> GetUsers()// Вывод всех пользователей
        {
            return context.Users.OrderBy(x => x.Name);
        }

        public User GetUserById (int id) // Поиск по id
        {
                return context.Users.SingleOrDefault(x => x.Id == id); 
        }

        public int SaveUser(User entity) // Добавление или редактирование существующего пользователя
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();

            return entity.Id;
        }

        public void DeleteUser(User entity) // Удаление пользователя
        {
            context.Users.Remove(entity);
            context.SaveChanges();
        }
    }
}
