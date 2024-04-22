namespace Donations.repository
{
    public class RepositoryException : ApplicationException
    {
        public RepositoryException()
        {
        }

        public RepositoryException(String mess) : base(mess)
        {
        }

        public RepositoryException(String mess, Exception e) : base(mess, e)
        {
        }
    }

    public interface IRepository<TEntity, TID>
    {
        TEntity FindOne(TID id);

        List<TEntity> FindAll();

        TID Save(TEntity entity);

        void Delete(TEntity id);

        void Update(TID id, TEntity entity);
    }
}