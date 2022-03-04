using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {

        public Repository(AppDbContext appDbContext)
        {
            Context = appDbContext;
        }

        public AppDbContext Context { get; }

        public void Add(T obj)
        {
            Context.Add<T>(obj);
        }

        public void Delete(T obj)
        {
            Context.Remove<T>(obj);
        }

        public List<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public T GetById(string id)
        {
             return Context.Find<T>(id);
        }

        public void Update(T obj)
        {
            Context.Update<T>(obj);
        }
    }
}
