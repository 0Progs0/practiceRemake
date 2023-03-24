using DbAPI.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using UserModel;

namespace DbAPI.Repository
{
    public class UsersRepository
    {
        private readonly DataBaseContext context;

        public UsersRepository(DataBaseContext context)
        {
            this.context = context;
        }

        public List<User> GetUsers()
        {
            return context.Users.OrderBy(x => x.Name).ToList();
        }

        public User GetUserById(Guid id)
        {
            return context.Users.SingleOrDefault(x => x.Id == id);
        }

        public List<User> GetUserByName(string user_name)
        {
            return context.Users.Where(x => EF.Functions.Like(x.Name, $"%{user_name}%")).ToList();
        }

        //public Guid SaveUser(User entity)
        //{
        //    if (entity.Id == default)
        //        context.Entry(entity).State = EntityState.Added;
        //    else
        //        context.Entry(entity).State = EntityState.Modified;
        //    context.SaveChanges();

        //    return entity.Id;
        //}

        public Guid CreateUser(User entity)
        {
            context.Entry(entity).State = EntityState.Added;
            context.SaveChanges();
            return entity.Id;
        }

        public Guid ModifyUser(User entity)
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
