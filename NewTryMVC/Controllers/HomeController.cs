using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NewTryMVC.Models;
using NewTryMVC.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Schema;

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

        public IActionResult UserEdit(int id)
        {
            User model = id == default ? new User() : usersRepository.GetUserById(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult UserEdit (User model)
        {
            if (ModelState.IsValid)
            {
                usersRepository.SaveUser(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult UserFind(int FindId)
        {
            var model = usersRepository.GetUserById(FindId);
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
