using GraphQLProject.Data;
using GraphQLProject.Interfaces;

namespace GraphQLProject.Services
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly GraphqlDbContext _context;

        protected BaseRepository(GraphqlDbContext context)
        {
            _context = context;
        }

        public TEntity Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public List<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            var entity = _context.Set<TEntity>().Find(id);
            return entity;
        }

        public TEntity Update(int id, TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
