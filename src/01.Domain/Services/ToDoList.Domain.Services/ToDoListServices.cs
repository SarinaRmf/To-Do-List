using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Core.Contracts.Repository;
using ToDoList.Domain.Core.Contracts.Service;
using ToDoList.Domain.Core.DTOs.common;
using ToDoList.Domain.Core.DTOs.ToDoItem;
using ToDoList.Domain.Core.Entities;
using ToDoList.Domain.Core.Enums;
using ToDoList.framework;

namespace ToDoList.Domain.Services
{
    public class ToDoListServices(IToDoItemRepository _repo) : IToDoListService
    {
        public ResultDto<bool> Add(CreateItemDto createItemDto)
        {
            if (string.IsNullOrEmpty(createItemDto.Title))
            {
                return new ResultDto<bool>() { IsSuccess = false, Message = "Task title is required!" };
            }

            var result = _repo.Add(createItemDto);
            if (result)
            {
                return new ResultDto<bool>() { IsSuccess = true, Message = "Task Successfully added." };
            }
            return new ResultDto<bool>() { IsSuccess = false, Message = "Adding Task failed!" };
        }

        public ResultDto<bool> Delete(int itemId)
        {
            if (!_repo.IsExist(itemId))
            {
                return new ResultDto<bool>() { IsSuccess = false, Message = "Task not found!" };
            }
            var result = _repo.Delete(itemId);
            if (result)
            {
                return new ResultDto<bool>() { IsSuccess = true, Message = "Task Successfully deleted." };
            }
            return new ResultDto<bool>() { IsSuccess = false, Message = "Deleting Task failed!" };
        }

        public GetItemsDto Get(int id)
        {
            return _repo.Get(id);
        }

        public List<GetItemsDto> GetAll(int userId)
        {
            return _repo.GetAll(userId);
        }

        public UpdateItemDto GetUpdateItems(int itemId)
        {
            return _repo.GetUpdateItems(itemId);
        }

        public ResultDto<bool> Update(int itemId, UpdateItemDto updateItemDto)
        {
            if (!_repo.IsExist(itemId))
            {
                return new ResultDto<bool>() { IsSuccess = false, Message = "Task not found!" };
            }

            var result = _repo.Update(itemId, updateItemDto);
            if (result)
            {
                return new ResultDto<bool>() { IsSuccess = true, Message = "Task Successfully edited." };
            }
            return new ResultDto<bool>() { IsSuccess = false, Message = "Editing Task failed!" };
        }

        public ResultDto<bool> SetOverDueStatus(int itemId)
        {
            if (_repo.OverDue(itemId))
            {
                var result = _repo.UpdateStatus(itemId, Core.Enums.StatusEnum.Delayed);
                if (result)
                {
                    return new ResultDto<bool>() { IsSuccess = true };
                }
                return new ResultDto<bool>() { IsSuccess = false, Message = "Updating Status failed!" };
            }
            return new ResultDto<bool>() { IsSuccess = false};
        }

        public List<GetItemsDto> Filter(SearchModel model, int userId)
        {
            return _repo.SearchAndSort(userId, model);
        }
    }
}

 