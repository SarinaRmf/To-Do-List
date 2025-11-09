using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Core.DTOs.User;

namespace ToDoList.Domain.Core.Contracts.Repository
{
    public interface IUserRepository
    {
        UserLoginDto Login(string username, string password);
        bool Register(CreateUserDto userDto);
        bool UsernameExist(string username);

    }
}
