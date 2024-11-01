using System.Linq.Expressions;
using DotnetUOWDemo.Api.Models;

namespace DotnetUOWDemo.Api.Services;

public interface ICategoryService
{
    Task<Category> AddCategoryAsync(Category category);
    Task<Category> UpdateCategoryAsync(Category category);
    Task DeleteCategoryAsync(Category category);
    Task<Category?> GetCategoryByIdAsync(int id);
    Task<IEnumerable<Category>> GetAllCategoriesAsync();
}
