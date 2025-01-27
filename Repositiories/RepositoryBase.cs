using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Freelance.Repositiories
{
    public class RepositoryBase<T, C> :IRepositoryBase<T> where T : class where C : DbContext
    {
        internal DbSet<T> dbSet;
        protected C _context;
        public RepositoryBase(C context)
        {
            context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _context = context;
            this.dbSet = _context.Set<T>();
        }

        public async Task<List<T>> GetAllAsync(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = dbSet;

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.ToListAsync();
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<List<T>> GetBy(Func<T, bool> predicate)
        {
            List<T> filterData = null;
            filterData = dbSet.AsNoTracking().Where(predicate).ToList();
            return filterData;

        }

        public async Task<T> GetByID(int ID, params Expression<Func<T, object>>[] includes)
        {            
            IQueryable<T> query = dbSet;

            // Add Include for related entities if provided
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            var entity = await query.SingleOrDefaultAsync(e => EF.Property<int>(e, "Id") == ID);
            if (entity != null)
            {
                _context.Entry(entity).State = EntityState.Detached;
            }
            // Return the entity with the specified ID
            return entity;
        }
        public async Task<T> GetByID(string ID)
        {
            var entity = await dbSet.FindAsync(ID);
            if (entity != null)
            {
                _context.Entry(entity).State = EntityState.Detached;
            }
            return entity;
        }
      


        public void Update(T entity)
        {           
            dbSet.Update(entity);
        }

        public void Update(List<T> entity)
        {
            dbSet.UpdateRange(entity);
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public void Save(T entity)
        {            
            dbSet.Add(entity);
        }


        public async Task<T> Insert(T entity)
        {
            var updatedEntity = await dbSet.AddAsync(entity);
            return updatedEntity.Entity;
        }

        public void Save(List<T> entity)
        {            
            dbSet.AddRange(entity);
        }      
    }
}
