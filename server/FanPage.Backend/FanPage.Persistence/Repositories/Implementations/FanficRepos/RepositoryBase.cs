using FanPage.Domain.Entities.Fanfic;
using FanPage.Persistence.Context;

namespace FanPage.Persistence.Repositories.Implementations.FanficRepos
{
    public class RepositoryBase<T> where T : class, IEntity
    {
        protected FanficContext _context;

        public RepositoryBase(FanficContext context)
        {
            _context = context;
        }

        public virtual T[] GetAll()
        {
            return _context.Set<T>().ToArray();
        }

        public virtual T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public virtual void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }

        public virtual void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public virtual void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }
    }
}