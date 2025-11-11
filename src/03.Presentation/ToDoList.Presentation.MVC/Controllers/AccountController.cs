using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.Core.Contracts.ApplicationService;
using ToDoList.Domain.Core.Contracts.Service;
using ToDoList.Domain.Core.DTOs.User;
using ToDoList.Presentation.MVC.Database;
using ToDoList.Presentation.MVC.Models;

namespace ToDoList.Presentation.MVC.Controllers
{
    public class AccountController(IUserApplicationService userApp) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login() { 
            return View(new LoginViewModel());
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            var result = userApp.Login(model.Username, model.Password);
            if (result.IsSuccess)
            {
                InMemoryDb.OnlineUser = new OnlineUser
                {
                    Id = result.Data.userId,
                    Username = result.Data.userName,
                };
                return RedirectToAction("Index", "ToDoList");
            }
            else
            {
                ViewBag.LoginError = result.Message;
            }
                return View(model);
        }
        [HttpGet]
        public IActionResult Register() {

            return View(new CreateUserDto());
        }
        [HttpPost]
        public IActionResult Register(CreateUserDto model)
        {
            var result = userApp.Register(model);
            if (result.IsSuccess) {

                return RedirectToAction("Login");
            }
            else
            {
                ViewBag.LoginError = result.Message;
            }

            return View(model);
        }

        
    }
}
