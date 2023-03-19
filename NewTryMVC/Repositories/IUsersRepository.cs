using NewTryMVC.Models;
using System.Linq;

namespace NewTryMVC.Repositories
{
    public interface IUsersRepository
    {
        public IQueryable<User> GetUsers();
        public User GetUserById(int id);
        public IQueryable<User> GetUserByName(string user_name);
        public int CreateUser(User entity);
        public int ModifyUser(User entity);
        public void DeleteUser(User entity);
    }
}
