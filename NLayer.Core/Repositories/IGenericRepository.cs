using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

//veri tabanına yapacağım tüm temel sorgular here (CRUD)
namespace NLayer.Core.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        Task<T> GetByIdAsync(int id);
        IQueryable<T> Where(Expression<Func<T,bool>> expression);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        Task AddAsync (T entity);
        Task AddRangeAsync (IEnumerable<T> entities);
        void Update(T entity);
        void Remove(T entity);
        void RemoveRange (IEnumerable<T> entities);
    }
}
