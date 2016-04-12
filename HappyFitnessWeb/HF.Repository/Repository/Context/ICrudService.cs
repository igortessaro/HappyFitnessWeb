namespace HF.Repository.Repository.Context
{
    public interface ICrudService<TEntity>
        where TEntity : class
    {
        int Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        TEntity Get(params object[] ids);
    }
}
