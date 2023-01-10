using Contracts;
using Entities;

namespace RepositoryPattern
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class 
    {
        protected readonly OnlineStoreDbContext dbContext;
        public GenericRepository(OnlineStoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(T obj) => dbContext.Set<T>().Add(obj);

        public void Delete(int id) => dbContext.Set<T>().Remove(Get(id));

        public T Get(int id) => dbContext.Set<T>().Find(id)!;

        public IEnumerable<T> GetAll() => dbContext.Set<T>().ToList();

        public void Update(T obj) => dbContext.Set<T>().Update(obj);
    }
}