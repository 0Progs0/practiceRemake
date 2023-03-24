using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using UserModel;

namespace NewTryMVC.Repository

{
    public class Service : IService
    {
        Uri address = new Uri("https://localhost:44392/api");
        HttpClient client;

        public Service()
        {
            client = new HttpClient();
            client.BaseAddress = address;
        }
        public List<User> GetAll()
        {
            List<User> userList = new List<User>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Db").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                userList = JsonConvert.DeserializeObject<List<User>>(data);
            }
            return userList;
        }

        public List<User> GetByName(string name)
        {
            List<User> userList;
            string data;
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Db").Result;
            if ((response.IsSuccessStatusCode) && (name != null))
            {
                data = response.Content.ReadAsStringAsync().Result;
                userList = JsonConvert.DeserializeObject<List<User>>(data);
                userList = userList.Where(x => x.Name.Contains(name)).ToList();
            }
            else
            {
                data = response.Content.ReadAsStringAsync().Result;
                userList = JsonConvert.DeserializeObject<List<User>>(data);
            }
            return userList;
        }

        public HttpResponseMessage AddUser(User user)
        {
            string data = JsonConvert.SerializeObject(user);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "/Db", content).Result;
            return (response);
        }

        public User EditUser(Guid id)
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
            return(user);
        }

        public HttpResponseMessage EditUserPost(User user)
        {
            string data = JsonConvert.SerializeObject(user);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync(client.BaseAddress + "/Db/" + user.Id, content).Result;
            return (response);
        }

        public HttpResponseMessage DeleteUser(Guid id)
        {
            HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + "/Db/" + id).Result;
            return (response);
        }
    }
}