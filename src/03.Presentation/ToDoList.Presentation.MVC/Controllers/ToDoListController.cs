using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.Core.Contracts.Service;
using ToDoList.Domain.Core.DTOs.ToDoItem;
using ToDoList.Presentation.MVC.Database;
using ToDoList.Presentation.MVC.Models;

namespace ToDoList.Presentation.MVC.Controllers
{
    public class ToDoListController(IToDoListService toDoListService, ICategoryService categoryService) : Controller
    {
        public IActionResult Index()
        {
            var onlineUser = InMemoryDb.OnlineUser;
            var model = toDoListService.GetAll(onlineUser.Id);
            foreach(var item in model)
            {
                var status = toDoListService.SetOverDueStatus(item.Id);
                if (status.IsSuccess == false)
                {
                    ViewBag.Error = status.Message;
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Add() {

            ViewBag.Categories = categoryService.GetAll();
            return View(new CreateItemDto());
        }

        [HttpPost]
        public IActionResult Add(CreateItemDto model) {
            model.UserId = InMemoryDb.OnlineUser.Id;
            var result = toDoListService.Add(model);
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
            var result = toDoListService.Delete(itemId);
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

            ViewBag.Categories = categoryService.GetAll();
            var model = toDoListService.GetUpdateItems(itemId);
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(UpdateItemDto model) {

            var result = toDoListService.Update(model.Id, model);
            if (result.IsSuccess) { 
            
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
