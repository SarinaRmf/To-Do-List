using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Domain.Core.DTOs.User
{
    public class UserLoginDto
    {
        public int userId { get; set; }
        public string userName { get; set; }
    }
}
