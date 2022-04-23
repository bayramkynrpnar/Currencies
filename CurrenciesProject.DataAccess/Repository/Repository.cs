using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrenciesProject.DataAccess
{
    /// <summary>
    ///  EntityFramework için hazırlıyor olduğumuz bu repositoriyi daha önceden tasarladığımız generic repositorimiz olan IRepository arayüzünü implemente ederek tasarladık.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext DbContext;
        private readonly DbSet<T> DbSet;
        public Repository(DbContext dbContext)
        {
            DbContext = dbContext;
            DbSet = dbContext.Set<T>();
        }
        public void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public bool Any(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Any(predicate);
        }

        public void BulkDelete(List<T> entityList)
        {
            foreach (var entity in entityList)
            {
                DbSet.Remove(entity);
            }
        }

        public void BulkInsert(List<T> entityList)
        {
            foreach (var entity in entityList)
            {
                DbSet.Add(entity);
            }
        }

        public void Delete(T entity, bool forceDelete = false)
        {
            // Önce entity'nin state'ini kontrol etmeliyiz.
            EntityEntry<T> dbEntityEntry = DbContext.Entry(entity);

            if (dbEntityEntry.State != EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                DbSet.Attach(entity);
                DbSet.Remove(entity);
            }
        }

        public void Delete(Expression<Func<T, bool>> predicate, bool forceDelete = false)
        {
            T model = DbSet.FirstOrDefault(predicate);

            if (model != null)
                Delete(model, forceDelete);
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> iQueryable = DbSet
               .Where(predicate);
            return iQueryable.ToList().FirstOrDefault();
        }

        public IQueryable<T> GetAll()
        {
            IQueryable<T> iQueryable = DbSet.Where(x => x != null);
            return iQueryable;
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> iQueryable = DbSet
                .Where(predicate);
            return iQueryable;
        }

        public DbContext GetDbContext()
        {
            return DbContext;
        }

        public void Update(T entity)
        {
            DbSet.Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
