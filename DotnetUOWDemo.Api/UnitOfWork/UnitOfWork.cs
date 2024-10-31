using DotnetUOWDemo.Api.Models;
using DotnetUOWDemo.Api.Repositories;

namespace DotnetUOWDemo.Api.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    private IRepository<Category>? _categoryRepository = null;
    private IRepository<Product>? _productRepository = null;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }
    IRepository<Category> CategoryRepository
    {
        get
        {
            if (_categoryRepository == null)
            {
                _categoryRepository = new Repository<Category>(_context);
            }
            return CategoryRepository;
        }
    }
    public IRepository<Product> ProductRepository
    {
        get
        {
            if (_productRepository == null)
            {
                _productRepository = new Repository<Product>(_context);
            }
            return ProductRepository;
        }
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public Task<int> SaveChangesAsync()
    {
        throw new NotImplementedException();
    }
}
