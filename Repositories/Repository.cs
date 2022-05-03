using Hotel.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Hotel.Repositories
{
    public class Repository<T> : IRepository<T> where T: BaseEntity
    {

        public AppDbContext Context { get; }
        private DbSet<T> table = null;

        public Repository(AppDbContext appDbContext)
        {
            Context = appDbContext;
            table = appDbContext.Set<T>();
            
        }

        

        public async Task<IEnumerable<T>> GetAll()
        {
            try
            {
                return await Context.Set<T>().ToListAsync();
            }
            catch (Exception)
            {
                return new List<T>();
            }
        }

        public async Task<T> GetById(Guid id)
        {
            
            return await table.AsNoTracking().SingleOrDefaultAsync(e => e.Id == id);
            

        }

        public async Task Add(T obj)
        {

            await table.AddAsync(obj);
            await Context.SaveChangesAsync();

        }

        public Task Delete(T obj)
        {
         
            table.Remove(obj);
            //await Context.SaveChangesAsync();
            return Task.FromResult(Context.SaveChanges());

        }

        


        public Task Update(T obj)
        {
 

            table.Update(obj);
            //Context.SaveChanges();
            return Task.FromResult(Context.SaveChanges());
           


        }

        public IEnumerable<T> GetIncludes(params Expression<Func<T, object>>[] includes)
        {

            IQueryable<T> query = table.Include(includes[0]);
            foreach (var include in includes.Skip(1))
            {
                query = query.Include(include);
            }
            return query.ToList();
        }
    }
}
