using System.Linq.Expressions;
using DotnetUOWDemo.Api.Models;
using DotnetUOWDemo.Api.UnitOfWork;

namespace DotnetUOWDemo.Api.Services;

public class CategoryService : ICategoryService
{
    private readonly IUnitOfWork _unitOfWork;

    public CategoryService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Category> AddCategoryAsync(Category category)
    {
        _unitOfWork.CategoryRepository.Add(category);
        await _unitOfWork.SaveChangesAsync();
        return category;
    }

    public async Task<Category> UpdateCategoryAsync(Category category)
    {
        _unitOfWork.CategoryRepository.Update(category);
        await _unitOfWork.SaveChangesAsync();
        return category;
    }

    public async Task DeleteCategoryAsync(Category category)
    {
        _unitOfWork.CategoryRepository.Delete(category);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<Category?> GetByIdCategoryAsync(int id)
    {
        return await _unitOfWork.CategoryRepository.GetByIdAsync(id);
    }

    public Task<IEnumerable<Category>> GetAllCategoryAsync(Expression<Func<Category, bool>>? filter = null, IOrderedQueryable<Category>? orderBy = null, string includeProperties = "")
    {
        return _unitOfWork.CategoryRepository.GetAllAsync();
    }

}
