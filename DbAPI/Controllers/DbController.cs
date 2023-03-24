using DbAPI.Repository;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using UserModel;

namespace DbAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DbController : ControllerBase
    {

        private readonly UsersRepository usersRepository;
        public DbController(UsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        [HttpGet]
        public async Task<List<User>> GetAllUsers()
        {
            var model = usersRepository.GetUsers();
            return model;
        }

        [HttpGet("{name}")]
        public async Task<List<User>> GetUserByName(string name)
        {
            List<User> model = usersRepository.GetUserByName(name);
            return model;
        }

        [HttpPut("{id}")]
        public async Task<User> ModifyUser(User user)
        {
            usersRepository.ModifyUser(user);
            return user;
        }

        [HttpPost]
        public async Task<User> Create(User user)
        {
            usersRepository.CreateUser(user);
            return user;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            usersRepository.DeleteUser(new User() { Id = id });
            return Ok();
        }
    }
}
