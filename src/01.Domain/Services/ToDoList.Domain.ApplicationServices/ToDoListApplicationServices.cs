using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Core.Contracts.ApplicationService;
using ToDoList.Domain.Core.Contracts.Service;
using ToDoList.Domain.Core.DTOs.common;
using ToDoList.Domain.Core.DTOs.ToDoItem;
using ToDoList.Domain.Core.Entities;

namespace ToDoList.Domain.ApplicationServices
{
    public class ToDoListApplicationServices(IToDoListService toDoListService, ICategoryService categoryService) : IToDoListApplicationService
    {
        public ResultDto<bool> Add(CreateItemDto createItemDto)
        {
            return toDoListService.Add(createItemDto);
        }

        public ResultDto<bool> Delete(int itemId)
        {
            return toDoListService.Delete(itemId);
        }

        public GetItemsDto Get(int id)
        {
            return toDoListService.Get(id);
        }

        public List<GetItemsDto> GetAll(int userId)
        {
            return toDoListService.GetAll(userId);
        }

        public UpdateItemDto GetUpdateItems(int itemId)
        {
            return toDoListService.GetUpdateItems(itemId);
        }

        public ResultDto<bool> SetOverDueStatus(int itemId)
        {
            return toDoListService.SetOverDueStatus(itemId);
        }

        public ResultDto<bool> Update(int itemId, UpdateItemDto ItemDto)
        {
            return toDoListService.Update(itemId, ItemDto);
        }

        public ToDoCategoryDto GetPageData(int userId)
        {
            var dto = new ToDoCategoryDto()
            {
                Categories = categoryService.GetAll(),
                Tasks = toDoListService.GetAll(userId),
            };

            return dto;
        }
        public List<GetItemsDto> Filter(SearchModel model, int userId)
        {
            if(model.SortBy == null && model.Title == null && model.CategoryName == null)
            {
                return toDoListService.GetAll(userId);
            }
            var searchResult = toDoListService.Search(userId, model);
            return toDoListService.Sort(searchResult, model);
        }
    }
}
