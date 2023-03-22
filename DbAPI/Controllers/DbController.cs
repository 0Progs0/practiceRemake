using DbAPI.Models;
using DbAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


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
        public async Task<ActionResult> GetAllUsers()
        {
            var model = usersRepository.GetUsers();
            return Ok(model);
        }

        [HttpGet("{name}")]
        public async Task<ActionResult> GetUserByName(string name)
        {
            var model = usersRepository.GetUserByName(name);
            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> ModifyUser(User user)
        {
            usersRepository.ModifyUser(user);
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult> Create(User user)
        {
            usersRepository.CreateUser(user);
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            usersRepository.DeleteUser(new User() { Id = id });
            return Ok();
        }
    }
}
