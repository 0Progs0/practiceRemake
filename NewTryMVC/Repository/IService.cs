using System;
using System.Collections.Generic;
using System.Net.Http;
using UserModel;

namespace NewTryMVC.Repository
{
    public interface IService
    {
        public List<User> GetAll();
        public List<User> GetByName(string name);
        public HttpResponseMessage AddUser(User user);
        public User EditUser(Guid id);
        public HttpResponseMessage EditUserPost(User user);
        public HttpResponseMessage DeleteUser(Guid id);
    }
}
