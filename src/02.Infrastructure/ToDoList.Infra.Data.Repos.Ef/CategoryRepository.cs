using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Core.Contracts.Repository;
using ToDoList.Domain.Core.DTOs.Category;
using ToDoList.Infra.Db.SqlServer.Ef;

namespace ToDoList.Infra.Data.Repos.Ef
{
    public class CategoryRepository(AppDbContext _context) : ICategoryRepository
    {
        public List<GetCategoryDto> GetAll()
        {
            return _context.Categories.AsNoTracking()
                .Select(c => new GetCategoryDto
                {
                    Name = c.Name,
                    Id = c.Id,
                }).ToList();
        }
    }
}
