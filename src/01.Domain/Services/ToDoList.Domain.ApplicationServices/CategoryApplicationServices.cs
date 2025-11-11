using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Core.Contracts.ApplicationService;
using ToDoList.Domain.Core.Contracts.Service;
using ToDoList.Domain.Core.DTOs.Category;

namespace ToDoList.Domain.ApplicationServices
{
    public class CategoryApplicationServices(ICategoryService categoryService) : ICategoryApplicationService
    {
        public List<GetCategoryDto> GetAll()
        {
            return categoryService.GetAll();
        }
    }
}
