using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Domain.Core.DTOs.common
{
    public class SearchModel
    {
        public string Title { get; set; }
        public string CategoryName { get; set; }

        public string SortBy { get; set; }
    }
}
