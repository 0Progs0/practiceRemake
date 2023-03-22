using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace NewAPI.Controllers
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
        public async Task<IActionResult> GetAllUsers()
        {
            var users = usersRepository.GetUsers();
            return Ok(usersRepository);
        }
    }
}
