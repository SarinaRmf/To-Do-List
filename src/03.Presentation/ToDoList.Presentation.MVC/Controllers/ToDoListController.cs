using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.Core.Contracts.ApplicationService;
using ToDoList.Domain.Core.Contracts.Service;
using ToDoList.Domain.Core.DTOs.common;
using ToDoList.Domain.Core.DTOs.ToDoItem;
using ToDoList.Domain.Core.Enums;
using ToDoList.Presentation.MVC.Database;
using ToDoList.Presentation.MVC.Models;

namespace ToDoList.Presentation.MVC.Controllers
{
    public class ToDoListController(IToDoListApplicationService toDoListApp) : Controller
    {
        public IActionResult Index()
        {
            var onlineUser = InMemoryDb.OnlineUser;
            var model = toDoListApp.GetAll(onlineUser.Id);

            foreach (var item in model)
            {
                var status = toDoListApp.SetOverDueStatus(item.Id);
                if (status.IsSuccess == false)
                {
                    ViewBag.Error = status.Message;
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Add() {

            var onlineUser = InMemoryDb.OnlineUser;
            var pageData = toDoListApp.GetPageData(onlineUser.Id);
            ViewBag.Categories = pageData.Categories;

            return View(new CreateItemDto());
        }

        [HttpPost]
        public IActionResult Add(CreateItemDto model) {
            model.UserId = InMemoryDb.OnlineUser.Id;
            var result = toDoListApp.Add(model);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Error=result.Message;
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int itemId)
        {
            var result = toDoListApp.Delete(itemId);
            if (result.IsSuccess) { 
            
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Error = result.Message;
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int itemId) {

            var onlineUser = InMemoryDb.OnlineUser;
            var pageData = toDoListApp.GetPageData(onlineUser.Id);
            ViewBag.Categories = pageData.Categories;

            var model = toDoListApp.GetUpdateItems(itemId);
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(UpdateItemDto model) {

            var result = toDoListApp.Update(model.Id, model);
            if (result.IsSuccess) { 
            
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Filter(SearchModel model)
        {
            var onlineUser = InMemoryDb.OnlineUser;
            
            var searchResult = toDoListApp.Filter(model, onlineUser.Id);
            return View("Index", searchResult);
        }
    }
}
