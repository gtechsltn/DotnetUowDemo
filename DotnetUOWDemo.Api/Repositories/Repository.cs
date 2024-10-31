using System.Linq.Expressions;
using DotnetUOWDemo.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetUOWDemo.Api.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly AppDbContext _context;
    private readonly DbSet<T> _dbSet;

    public Repository(AppDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }
    public T Add(T entity)
    {
        _dbSet.Add(entity);
        return entity;
    }

    public T Update(T entity)
    {
        _dbSet.Update(entity);
        return entity;
    }

    public void Delete(T entity) => _dbSet.Remove(entity);

    public T? GetById(int id) => _dbSet.Find(id);

    public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, IOrderedQueryable<T>? orderBy = null, string includeProperties = "")
    {
        IQueryable<T> query = _dbSet;
        if (filter != null)
        {
            query = query.Where(filter);
        }
        foreach (var includeProperty in includeProperties.Split([','], StringSplitOptions.RemoveEmptyEntries))
        {
            query = query.Include(includeProperty);
        }
        if (orderBy != null)
        {
            return orderBy.ToList();
        }
        return query.ToList();
    }

    public IEnumerable<T> GetPaged(Expression<Func<T, bool>>? filter = null, IOrderedQueryable<T>? orderBy = null, string includeProperties = "", int pageNumber = 1, int pageSize = 10)
    {
        IQueryable<T> query = _dbSet;
        if (filter != null)
        {
            query = query.Where(filter);
        }
        foreach (var includeProperty in includeProperties.Split([','], StringSplitOptions.RemoveEmptyEntries))
        {
            query = query.Include(includeProperty);
        }
        if (orderBy != null)
        {
            return orderBy.ToList();
        }
        query = query.Skip((pageNumber - 1) * pageSize).Take(pageSize);

        return query.ToList();
    }

}
