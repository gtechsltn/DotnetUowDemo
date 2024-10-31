using DotnetUOWDemo.Api.Models;
using DotnetUOWDemo.Api.Repositories;

namespace DotnetUOWDemo.Api.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    IRepository<Category> CategoryRepository { get; }
    IRepository<Product> ProductRepository { get; }
    Task<int> SaveChangesAsync();
}
