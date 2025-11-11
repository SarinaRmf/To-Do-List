using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Core.Enums;

namespace ToDoList.Domain.Core.Entities
{
    public class ToDoItem : BaseEntity
    {
        public string Title { get; set; }
        public DateTime DueTime { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public StatusEnum Status { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
