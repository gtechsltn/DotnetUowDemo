using System.Linq.Expressions;
using DotnetUOWDemo.Api.Models;
using DotnetUOWDemo.Api.UnitOfWork;

namespace DotnetUOWDemo.Api.Services;

public class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Product> AddProductAsync(Product product)
    {
        _unitOfWork.ProductRepository.Add(product);
        await _unitOfWork.SaveChangesAsync();
        return product;
    }

    public async Task<Product> UpdateProductAsync(Product product)
    {
        _unitOfWork.ProductRepository.Update(product);
        await _unitOfWork.SaveChangesAsync();
        return product;
    }

    public async Task DeleteProductAsync(Product product)
    {
        _unitOfWork.ProductRepository.Delete(product);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<Product?> GetProductByIdAsync(int id)
    {
        return await _unitOfWork.ProductRepository.GetByIdAsync(id, noTracking: true);
    }

    public Task<IEnumerable<Product>> GetAllProductsAsync(string sTerm = "")
    {
        Expression<Func<Product, bool>>? filter = null;
        if (!string.IsNullOrWhiteSpace(sTerm))
        {
            sTerm = sTerm.ToLower();
            filter = x => x.ProductName.ToLower().Contains(sTerm);
        }
        return _unitOfWork.ProductRepository.GetAllAsync(filter: filter, orderBy: x => x.OrderBy(x => x.ProductName), includeProperties: "Category");
    }

}
