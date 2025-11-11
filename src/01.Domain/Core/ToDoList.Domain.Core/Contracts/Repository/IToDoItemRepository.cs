using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Core.DTOs.common;
using ToDoList.Domain.Core.DTOs.ToDoItem;
using ToDoList.Domain.Core.Enums;

namespace ToDoList.Domain.Core.Contracts.Repository
{
    public interface IToDoItemRepository
    {
        bool Add(CreateItemDto createItemDto);
        List<GetItemsDto> GetAll(int userId);
        GetItemsDto Get(int id);
        bool Update(int itemId, UpdateItemDto createItemDto);
        bool Delete(int itemId);
        bool IsExist(int id);
        UpdateItemDto GetUpdateItems(int itemId);
        bool OverDue(int itemId);
        bool UpdateStatus(int itemId, StatusEnum Status);
        StatusEnum GetStatus(int itemId);

    }
}
