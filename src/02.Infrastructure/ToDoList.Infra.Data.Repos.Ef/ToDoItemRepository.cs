using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Core.Contracts.Repository;
using ToDoList.Domain.Core.DTOs.common;
using ToDoList.Domain.Core.DTOs.ToDoItem;
using ToDoList.Domain.Core.Entities;
using ToDoList.Domain.Core.Enums;
using ToDoList.Infra.Db.SqlServer.Ef;


namespace ToDoList.Infra.Data.Repos.Ef
{
    public class ToDoItemRepository(AppDbContext _context) : IToDoItemRepository
    {
        public bool Add(CreateItemDto createItemDto)
        {
            var entity = new ToDoItem
            {
                CategoryId = createItemDto.CategoryId,
                CreatedAt = DateTime.Now,
                DueTime = createItemDto.DueTime,
                Status = Domain.Core.Enums.StatusEnum.InProgress,
                UserId = createItemDto.UserId,
                Title = createItemDto.Title,
            };
            _context.ToDoList.Add(entity);
            return _context.SaveChanges() > 0;
        }

        public bool Delete(int itemId)
        {
            return _context.ToDoList.Where(i => i.Id == itemId).ExecuteDelete() > 0;
        }

        public GetItemsDto? Get(int taskId)
        {
            return _context.ToDoList.Where(i => i.Id == taskId)
                .AsNoTracking()
                .Select(i => new GetItemsDto
                {
                    CategoryName = i.Category.Name,
                    DueTime = i.DueTime,
                    Status = i.Status,
                    Title = i.Title,
                    Id = i.Id

                }).FirstOrDefault();
        }

        public List<GetItemsDto> GetAll(int userId)
        {
            return _context.ToDoList
                .AsNoTracking()
                .Where(i => i.UserId == userId)
                .Select(i => new GetItemsDto
                {
                    CategoryName = i.Category.Name,
                    DueTime = i.DueTime,
                    Status = i.Status,
                    Title = i.Title,
                    Id = i.Id

                }).ToList();
        }


        public UpdateItemDto? GetUpdateItems(int itemId)
        {
            return _context.ToDoList
                .AsNoTracking()
                .Where(i => i.Id == itemId)
                .Select(i => new UpdateItemDto
                {
                    CategoryId = i.CategoryId,
                    DueTime = i.DueTime,
                    Status = i.Status,
                    Title = i.Title,
                    Id = i.Id

                }).FirstOrDefault();
        }
        public bool IsExist(int id)
        {
            return _context.ToDoList.Any(i => i.Id == id);
        }

        public bool Update(int itemId, UpdateItemDto ItemDto)
        {
            try
            {
                _context.ToDoList
               .Where(i => i.Id == itemId)
               .ExecuteUpdate(setters => setters
                   .SetProperty(i => i.DueTime, ItemDto.DueTime)
                   .SetProperty(i => i.Title, ItemDto.Title)
                   .SetProperty(i => i.CategoryId, ItemDto.CategoryId)
                   .SetProperty(i => i.Status, ItemDto.Status)
                   .SetProperty(i => i.UptatedAt, DateTime.Now));
                return true;
            }
            catch{ 
            
                return false;
            }
            
        }

        public bool OverDue(int itemId)
        {
            return _context.ToDoList.Any(i => i.Id == itemId
            && i.DueTime< DateTime.Now && i.Status == StatusEnum.InProgress);
        }

        public bool UpdateStatus(int itemId, StatusEnum Status) {

            try
            {
                _context.ToDoList
               .Where(i => i.Id == itemId)
               .ExecuteUpdate(setters => setters
                   .SetProperty(i => i.Status, Status));
                return true;
            }
            catch
            {

                return false;
            }
        }
        public StatusEnum GetStatus(int itemId)
        {

            return _context.ToDoList.Where(i => i.Id == itemId)
                .Select(i => i.Status)
                .FirstOrDefault();
        }
        public List<GetItemsDto> SearchAndSort(int userId, SearchModel model)
        {
            var query = _context.ToDoList
                .Where(i => i.UserId == userId)
                .AsQueryable();

            
            if (!string.IsNullOrEmpty(model.Title))
                query = query.Where(i => i.Title.Contains(model.Title));

            
            if (!string.IsNullOrEmpty(model.CategoryName))
                query = query.Where(i => i.Category.Name == model.CategoryName);

            query = model.SortBy switch
            {
                "DueDate" => query.OrderBy(x => x.DueTime),
                "Status" => query.OrderBy(x => x.Status),
                "Title" => query.OrderBy(x => x.Title),
                _ => query.OrderBy(x => x.Id) // مرتب‌سازی پیش‌فرض
            };

            
            return query.Select(x => new GetItemsDto
            {
                Title = x.Title,
                Status = x.Status,
                DueTime = x.DueTime,
                Id = x.Id,
                CategoryName = x.Category.Name
            }).ToList();
        }
        //public IQueryable<ToDoItem> Search(int userId,SearchModel model)
        //{
        //    var result = _context.ToDoList.Where(i=> i.UserId == userId).AsQueryable();
        //    if(model.Title != null)
        //    {
        //        result = _context.ToDoList.Where(i => i.Title.Contains(model.Title));

        //    }
        //    if (model.CategoryName != null) { 

        //        result = _context.ToDoList.Where(i => i.Category.Name == model.CategoryName);

        //    }
        //    return result;

        //}

        //public List<GetItemsDto> Sort(IQueryable<ToDoItem> query, SearchModel model)
        //{

        //    if (model.SortBy == "DueDate")
        //    {
        //        query = query.OrderBy(x => x.DueTime);
        //    }
        //    else if (model.SortBy == "Status")
        //    {
        //        query = query.OrderBy(x => x.Status);
        //    }
        //    else if (model.SortBy == "Title")
        //    {
        //        query =  query.OrderBy(x => x.Title);
        //    }

        //    return query.Select(x => new GetItemsDto
        //    {
        //        Title = x.Title,
        //        Status = x.Status,
        //        DueTime = x.DueTime,
        //        Id = x.Id,
        //        CategoryName = x.Category.Name,
        //    }).ToList();

        //}
    }
}
