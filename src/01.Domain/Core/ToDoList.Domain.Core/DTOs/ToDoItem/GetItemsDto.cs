using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Core.Entities;
using ToDoList.Domain.Core.Enums;

namespace ToDoList.Domain.Core.DTOs.ToDoItem
{
    public class GetItemsDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DueTime { get; set; }
        public string? DueTimeFa { get; set; }
        public string CategoryName{ get; set; }
        public StatusEnum Status { get; set; }
    }
}
