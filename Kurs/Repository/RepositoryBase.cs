using Kurs.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Kurs.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext _context;

        protected RepositoryBase(RepositoryContext context)
        {
            _context = context;
        }

        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }
        public IQueryable<T> FindAll(bool trackChanges)
        {
            return !trackChanges ?
                _context.Set<T>().AsNoTracking() :
                _context.Set<T>();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            return !trackChanges ?
                _context.Set<T>().Where(expression).AsNoTracking() :
                _context.Set<T>().Where(expression);
        }
    }
}
