using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Core.DTOs.Category;

namespace ToDoList.Domain.Core.Contracts.ApplicationService
{
    public interface ICategoryApplicationService
    {
        List<GetCategoryDto> GetAll();
    }
}
