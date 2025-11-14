using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Core.DTOs.common;
using ToDoList.Domain.Core.DTOs.ToDoItem;
using ToDoList.Domain.Core.Entities;
using ToDoList.Domain.Core.Enums;

namespace ToDoList.Domain.Core.Contracts.Service
{
    public interface IToDoListService
    {
        ResultDto<bool> Add(CreateItemDto createItemDto);
        List<GetItemsDto> GetAll(int userId);
        GetItemsDto Get(int id);
        ResultDto<bool> Update(int itemId, UpdateItemDto ItemDto);
        ResultDto<bool> Delete(int itemId);
        UpdateItemDto GetUpdateItems(int itemId);
        public ResultDto<bool> SetOverDueStatus(int itemId);

        //public IQueryable<ToDoItem> Search(int userId, SearchModel model);
        //public List<GetItemsDto> Sort(IQueryable<ToDoItem> query, SearchModel model);
        List<GetItemsDto> Filter(SearchModel model, int userId);
    }
}
