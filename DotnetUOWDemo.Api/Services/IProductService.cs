using System.Linq.Expressions;
using DotnetUOWDemo.Api.Models;

namespace DotnetUOWDemo.Api.Services;

public interface IProductService
{
    Task<Product> AddProductAsync(Product product);
    Task<Product> UpdateProductAsync(Product product);
    Task DeleteProductAsync(Product product);
    Task<Product?> GetProductByIdAsync(int id);

    Task<IEnumerable<Product>> GetAllProductsAsync(string sTerm = "");
}
