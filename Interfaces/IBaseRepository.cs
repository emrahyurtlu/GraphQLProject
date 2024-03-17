namespace GraphQLProject.Interfaces
{
    public interface IBaseRepository<TEntity>
    {
        List<TEntity> GetAll();
        TEntity GetById(int id);
        TEntity Add(TEntity entity);
        TEntity Update(int id, TEntity entity);
        void Delete(int id);
    }
}
