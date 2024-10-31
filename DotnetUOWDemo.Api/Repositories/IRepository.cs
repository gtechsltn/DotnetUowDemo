using System.Linq.Expressions;

namespace DotnetUOWDemo.Api.Repositories;

public interface IRepository<T> where T : class
{
    T Add(T entity);
    T Update(T entity);
    void Delete(T entity);
    T? GetById(int id);
    IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, IOrderedQueryable<T>? orderBy = null, string includeProperties = "");
    IEnumerable<T> GetPaged(Expression<Func<T, bool>>? filter = null, IOrderedQueryable<T>? orderBy = null, string includeProperties = "", int pageNumber = 1,
    int pageSize = 10);
}
