using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Core.DTOs.common;
using ToDoList.Domain.Core.DTOs.User;

namespace ToDoList.Domain.Core.Contracts.ApplicationService
{
    public interface IUserApplicationService
    {
        ResultDto<UserLoginDto> Login(string username, string password);
        ResultDto<bool> Register(CreateUserDto userDto);
    }
}
