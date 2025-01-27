using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace Freelance.Repositiories
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<List<T>> GetAllAsync(params Expression<Func<T, object>>[] includes);
        Task<T> GetByID(int ID, params Expression<Func<T, object>>[] includes);
        Task<T> GetByID(string ID);
        Task<List<T>> GetBy(Func<T, bool> predicate);
        void Save(T entity);
        void Update(T entity);
        void Update(List<T> entity);
        void Delete(T entity);
        Task<T> Insert(T entity);
    }
}
