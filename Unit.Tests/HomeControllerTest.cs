using Microsoft.AspNetCore.Mvc;
using Moq;
using NewTryMVC.Controllers;
using NewTryMVC.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using UserModel;
using Xunit;

namespace Unit.Tests
{
    public class HomeControllerTest
    {
        private List<User> GetTestUsers()
        {
            var users = new List<User>
            {
                new User { Id =  new Guid(), Name = "Alex", Surname = "Fja", Email = "Fja@mail.ru", Status = "student"},
                new User { Id =  new Guid(), Name = "Alice", Surname = "Fiu", Email = "Fiu@mail.ru", Status = "student"},
                new User { Id =  new Guid(), Name = "Sam", Surname = "Fia", Email = "fia@mail.ru", Status = "student"}
            };
            return users;
        }
        [Fact]
        public void IndexReturnsAViewResultWithAListOfUsers()
        {
            var mock = new Mock<IService>();
            mock.Setup(service => service.GetAll()).Returns(GetTestUsers());
            var controller = new HomeController(mock.Object);

            var result = controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<User>>(viewResult.Model);
            Assert.Equal(GetTestUsers().Count, model.Count());
        }
        
        [Fact]
        public void GetUserByNameReturnsViewResultWithUser()
        {
            // Arrange
            string testUserName = GetTestUsers().First().Name;
            var mock = new Mock<IService>();
            mock.Setup(service => service.GetByName(testUserName))
                .Returns(GetTestUsers().Where(p => p.Name.Contains(testUserName)).ToList());
            var controller = new HomeController(mock.Object);

            // Act
            var result = controller.UserFindByName(testUserName);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<List<User>>(viewResult.ViewData.Model);
            Assert.Equal("Alex", model.First().Name);
            Assert.Equal("Fja", model.First().Surname);
            Assert.Equal("Fja@mail.ru", model.First().Email);
            Assert.Equal("student", model.First().Status);
        }

        [Fact]
        public void UserCreateReturnsViewResultWithUserModel()
        {

            var newUser = new User()
            {
                Id = new Guid(),
                Name = "Alex",
                Surname = "Fja",
                Email = "Fja@mail.ru",
                Status = "student"
            };
            var response = new HttpResponseMessage();
            response.StatusCode = HttpStatusCode.OK;
            var mock = new Mock<IService>();
            mock.Setup(service => service.AddUser(newUser)).Returns(response);
            var controller = new HomeController(mock.Object);
            
            var result = controller.UserCreate(newUser);

            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }

        [Fact]
        public void UserModifyReturnsViewResultWithUserModel()
        {

            var newUser = new User()
            {
                Id = new Guid(),
                Name = "Alex",
                Surname = "Fja",
                Email = "Fja@mail.ru",
                Status = "student"
            };
            var response = new HttpResponseMessage();
            response.StatusCode = HttpStatusCode.OK;
            var mock = new Mock<IService>();
            mock.Setup(service => service.EditUserPost(newUser)).Returns(response);
            var controller = new HomeController(mock.Object);

            var result = controller.UserModify(newUser);

            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }

        [Fact]
        public void UserDeleteReturnsViewResult()
        {

            var newUser = new User()
            {
                Id = new Guid(),
                Name = "Alex",
                Surname = "Fja",
                Email = "Fja@mail.ru",
                Status = "student"
            };
            var response = new HttpResponseMessage();
            response.StatusCode = HttpStatusCode.OK;
            var mock = new Mock<IService>();
            mock.Setup(service => service.DeleteUser(newUser.Id)).Returns(response);
            var controller = new HomeController(mock.Object);

            var result = controller.UserDelete(newUser.Id);

            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }
    }
}
