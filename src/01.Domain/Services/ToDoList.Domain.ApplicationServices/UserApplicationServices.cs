using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Core.Contracts.ApplicationService;
using ToDoList.Domain.Core.Contracts.Service;
using ToDoList.Domain.Core.DTOs.common;
using ToDoList.Domain.Core.DTOs.User;
using ToDoList.framework;

namespace ToDoList.Domain.ApplicationServices
{
    public class UserApplicationServices(IUserService userService) : IUserApplicationService
    {
        public ResultDto<UserLoginDto> Login(string username, string password)
        {
            return userService.Login(username, password);
        }

        public ResultDto<bool> Register(CreateUserDto userDto)
        {
            
            return userService.Register(userDto);   
        }
    }
}
