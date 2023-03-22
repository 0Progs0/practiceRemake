using System.Linq;

namespace NewAPI.Repository
{
    public class UsersRepository
    {
        private readonly DataBaseContext context;

        public UsersRepository(DataBaseContext context)
        {
            this.context = context;
        }

        public IQueryable<User> GetUsers()
        {
            return context.Users.OrderBy(x => x.Name);
        }

        public User GetUserById(int id)
        {
            return context.Users.SingleOrDefault(x => x.Id == id);
        }

        public IQueryable<User> GetUserByName(string user_name)
        {
            return context.Users.Where(x => EF.Functions.Like(x.Name, $"{user_name}%"));
        }

        public int SaveUser(User entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();

            return entity.Id;
        }

        public int CreateUser(User entity)
        {
            context.Entry(entity).State = EntityState.Added;
            context.SaveChanges();
            return entity.Id;
        }

        public int ModifyUser(User entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
            return entity.Id;
        }

        public void DeleteUser(User entity)
        {
            context.Users.Remove(entity);
            context.SaveChanges();
        }
    }
}
