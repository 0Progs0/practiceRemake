using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NewTryMVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace NewTryMVC.Controllers
{
    public class HomeController : Controller
    {
        Uri address = new Uri("https://localhost:44392/api");
        HttpClient client;

        public HomeController() 
        {
            client= new HttpClient();
            client.BaseAddress = address;
        } 

        public ActionResult Index()
        {

            List<User> userList = new List<User>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Db").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                userList = JsonConvert.DeserializeObject<List<User>>(data);
            }
            return View(userList);
        }

        [HttpGet]
        public ActionResult UserFindByName(string name)
        {
            List<User> userList = new List<User>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Db").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                userList = JsonConvert.DeserializeObject<List<User>>(data);
                userList = userList.Where(x => x.Name.Contains(name)).ToList();
            }
            return View(userList);
        }

        public ActionResult UserCreate()
        {
            return View();
        }


        [HttpPost]
        public ActionResult UserCreate(User user)
        {
            string data = JsonConvert.SerializeObject(user);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "/Db", content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public  ActionResult UserModify(int id)
        {
            List<User> userList = new List<User>();
            User user = new User();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Db").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                userList = JsonConvert.DeserializeObject<List<User>>(data);
                user = userList.Single(x => x.Id == id); ;
            }
            return View(user);
        }


        [HttpPost]
        public ActionResult UserModify(User user)
        {
            string data = JsonConvert.SerializeObject(user);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync(client.BaseAddress + "/Db/" + user.Id, content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(user);
        }

        [HttpPost]
        public ActionResult UserDelete(int id)
        {
            List<User> userList = new List<User>();
            HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + "/Db/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Index",userList);
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