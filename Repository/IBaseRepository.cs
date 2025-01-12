using System.Linq.Expressions;

namespace repositorypattern.Repository
{
    public interface IBaseRepository<T>
    {
        Task<List<T>> GetAll(params Expression<Func<T, object>>[] includes);
        Task<T> Get(Guid Id,params Expression<Func<T, object>>[] includes);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(Guid Id);
    }
}