using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Core.DTOs.Category;
using ToDoList.Domain.Core.DTOs.ToDoItem;
using ToDoList.Domain.Core.Entities;

namespace ToDoList.Domain.Core.DTOs.common
{
    public class ToDoCategoryDto
    {
        public List<GetItemsDto> Tasks { get; set; }
        public List<GetCategoryDto> Categories { get; set; }
    }
}
