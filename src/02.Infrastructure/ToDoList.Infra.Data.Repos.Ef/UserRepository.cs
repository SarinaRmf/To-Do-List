using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Core.Contracts.Repository;
using ToDoList.Domain.Core.DTOs.User;
using ToDoList.Domain.Core.Entities;
using ToDoList.Domain.Core.Value_Objects;
using ToDoList.Infra.Db.SqlServer.Ef;

namespace ToDoList.Infra.Data.Repos.Ef
{
    public class UserRepository(AppDbContext _context) : IUserRepository
    {
        public UserLoginDto? Login(string username, string password)
        {
            return _context.Users.Where(u => u.Username == username && u.PasswordHash == password)
                .Select(u => new UserLoginDto
                {
                    userId = u.Id,
                    userName = u.Username,
                }).FirstOrDefault();

        }

        public bool Register(CreateUserDto userDto)
        {
            var entity = new User
            {
                Username = userDto.Username,
                PasswordHash = userDto.Password,
                Email = userDto.Email,
                CreatedAt = DateTime.Now,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,    
                Phone = Mobile.Create(userDto.Phone),
               
            };
            _context.Users.Add(entity);
            return _context.SaveChanges() > 0;

        }
        public bool UsernameExist(string username)
        {

            return _context.Users.Any(u => u.Username == username);

        }
    }
}
