using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Core.DTOs.common;
using ToDoList.Domain.Core.DTOs.ToDoItem;

namespace ToDoList.Domain.Core.Contracts.ApplicationService
{
    public interface IToDoListApplicationService
    {
        ResultDto<bool> Add(CreateItemDto createItemDto);
        List<GetItemsDto> GetAll(int userId);
        GetItemsDto Get(int id);
        ResultDto<bool> Update(int itemId, UpdateItemDto ItemDto);
        ResultDto<bool> Delete(int itemId);
        UpdateItemDto GetUpdateItems(int itemId);
       ResultDto<bool> SetOverDueStatus(int itemId);
        ToDoCategoryDto GetPageData(int userId);
        List<GetItemsDto> Filter(SearchModel model, int userId);
    }
}
