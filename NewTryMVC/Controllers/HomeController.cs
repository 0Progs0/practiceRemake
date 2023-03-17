using Microsoft.AspNetCore.Mvc;
using NewTryMVC.Models;
using NewTryMVC.Repositories;
using System.Diagnostics;

namespace NewTryMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly UsersRepository usersRepository;
        public HomeController(UsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public IActionResult Index()
        {
            var model = usersRepository.GetUsers();
            return View(model);
        }

        
       
        public IActionResult UserCreate()
        {
                User model = new User();
                return View(model);
        }

        [HttpPost]
        public IActionResult UserCreate(User model)
        {
            if (ModelState.IsValid)
            {
                usersRepository.CreateUser(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult UserModify(int id)
        {
            User model = usersRepository.GetUserById(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult UserModify(User model)
        {
            if (ModelState.IsValid)
            {
                usersRepository.ModifyUser(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        //[HttpPost]
        //public IActionResult UserFind(int FindId)
        //{
        //    var model = usersRepository.GetUserById(FindId);
        //    return View(model);
        //}

        [HttpPost]
        public IActionResult UserFindByName(string name)
        {
            var model = usersRepository.GetUserByName(name);
            return View(model);
        }


        [HttpPost]
        public IActionResult UserDelete(int id)
        {
            usersRepository.DeleteUser(new User { Id = id });
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}