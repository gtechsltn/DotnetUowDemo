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
    public IRepository<Category> CategoryRepository
    {
        get
        {
            if (_categoryRepository == null)
            {
                _categoryRepository = new Repository<Category>(_context);
            }
            return _categoryRepository;
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
            return _productRepository;
        }
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    private bool disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
        disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
