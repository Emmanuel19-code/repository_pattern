using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using repositorypattern.Infrastructure.Context;

namespace repositorypattern.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly AppDbContext _appDbContext;
        public BaseRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        //helps add value to the database
        public async Task<T> Add(T entity)
        {
            await _appDbContext.Set<T>().AddAsync(entity);
            await _appDbContext.SaveChangesAsync();
            return entity;
        }



        public async Task<T> IBaseRepository<T>.Get(Guid Id, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _appDbContext.Set<T>();
            query = includes.Aggregate(query, (current, include) => current.Include(include));
            return await query.FirstOrDefault(e => EF.Property<Guid>(e, "Id") == Id);
        }

        public Task<List<T>> GetAll(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _appDbContext.Set<T>();
            query = includes.Aggregate(query, (current, include) => current.Include(include));
            return query.ToListAsync();
        }



        public Task<T> Update(T entity)
        {
            _appDbContex.Set<T>().Update(entity);
            _appDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Delete(Guid Id)
        {
            var entity = await _appDbContext.Set<T>().FindAsync(Id);
            if(entity != null)
            {
                _appDbContext.Set<T>().Remove(entity);
                await _appDbContext.SaveChangesAsync();
            }
            return entity;
        }


    }
}