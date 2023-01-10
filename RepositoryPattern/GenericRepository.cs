using Contracts;
using Entities;

namespace RepositoryPattern
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class 
    {
        protected readonly OnlineStoreDbContext
        public void Complete()
        {
            throw new NotImplementedException();
        }

        public void Create(T obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public T Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(T obj)
        {
            throw new NotImplementedException();
        }
    }
}