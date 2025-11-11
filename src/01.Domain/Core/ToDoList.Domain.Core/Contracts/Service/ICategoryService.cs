using ToDoList.Domain.Core.DTOs.Category;

namespace ToDoList.Domain.Core.Contracts.Service
{
    public interface ICategoryService
    {
        List<GetCategoryDto> GetAll();
    }
}
