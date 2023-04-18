namespace API.DAL
{
    public abstract class Repository<TEntity>
    where TEntity : class
    {
        private DataContext dataContext;

        protected Repository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        protected IQueryable<TEntity> Query => dataContext.Set<TEntity>();
    }
}
