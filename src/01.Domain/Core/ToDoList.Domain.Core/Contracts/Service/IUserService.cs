using ToDoList.Domain.Core.DTOs.common;
using ToDoList.Domain.Core.DTOs.User;

namespace ToDoList.Domain.Core.Contracts.Service
{
    public interface IUserService
    {
        ResultDto<UserLoginDto> Login(string username, string password);
        ResultDto<bool> Register(CreateUserDto userDto);
    }
}
