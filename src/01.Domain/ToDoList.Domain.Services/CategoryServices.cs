using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Core.Contracts.Repository;
using ToDoList.Domain.Core.Contracts.Service;
using ToDoList.Domain.Core.DTOs.Category;

namespace ToDoList.Domain.Services
{
    public class CategoryServices(ICategoryRepository _repo) : ICategoryService
    {
        public List<GetCategoryDto> GetAll()
        {
            return _repo.GetAll();
        }
    }
}
