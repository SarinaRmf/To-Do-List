using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Core.Contracts.Repository;
using ToDoList.Domain.Core.Contracts.Service;
using ToDoList.Domain.Core.DTOs.common;
using ToDoList.Domain.Core.DTOs.User;
using ToDoList.framework;

namespace ToDoList.Domain.Services
{
    public class UserServices(IUserRepository _repo) : IUserService
    {
        public ResultDto<UserLoginDto> Login(string username, string password)
        {

            var result = _repo.Login(username, password.ToMd5Hex());
            if (result is null)
            {
                return new ResultDto<UserLoginDto> { IsSuccess = false, Message = "Username or Password is Incorrect!" };
            }
            return new ResultDto<UserLoginDto> { IsSuccess = true, Message = "Logged in Successfully", Data = result };
        }

        public ResultDto<bool> Register(CreateUserDto userDto)
        {
            if (_repo.UsernameExist(userDto.Username))
            {

                return new ResultDto<bool> { IsSuccess = false, Message = "Username has already exist!" };
            }

            userDto.Password = userDto.Password.ToMd5Hex();
            if (_repo.Register(userDto))
            {
                return new ResultDto<bool> { IsSuccess = true, Message = "Registered Successfully" };
            }
            return new ResultDto<bool> { IsSuccess = false, Message = "Registration went wrong!" };
        }

    }
}
