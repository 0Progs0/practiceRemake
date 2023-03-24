using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using UserModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using NewTryMVC.Models;
using NewTryMVC.Repository;

namespace NewTryMVC.Controllers
{
    public class HomeController : Controller
    {
        IService service;


        public HomeController(IService s) 
        {
            service = s;
        }

        public ActionResult Index()
        {

            return View(service.GetAll());
        }

        [HttpGet]
        public ActionResult UserFindByName(string name)
        {
            return View(service.GetByName(name));
        }

        public ActionResult UserCreate()
        {
            return View();
        }


        [HttpPost]
        public ActionResult UserCreate(User user)
        {
            HttpResponseMessage response = service.AddUser(user);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public  ActionResult UserModify(Guid id)
        {           
            return View(service.EditUser(id));
        }


        [HttpPost]
        public ActionResult UserModify(User user)
        {
            HttpResponseMessage response = service.EditUserPost(user);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(user);
        }

        [HttpPost]
        public ActionResult UserDelete(Guid id)
        {
            HttpResponseMessage response = service.DeleteUser(id);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Index");
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