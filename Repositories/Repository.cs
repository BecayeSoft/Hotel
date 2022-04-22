using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Repositories
{
    public class Repository<T> : IRepository<T> where T: class
    {

        public Repository(AppDbContext appDbContext)
        {
            Context = appDbContext;
        }

        public AppDbContext Context { get; }

        public async Task Add(T obj)
        {
            try
            {
                Context.Set<T>().Add(obj);
                await Context.SaveChangesAsync();
            }
            catch(Exception)
            {

            }
        }

        public async Task Delete(T obj)
        {
            try
            {
                Context.Set<T>().Remove(obj);
                await Context.SaveChangesAsync();
            }
            catch(Exception)
            {

            }
            //Context.Remove<T>(obj);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            try
            {
                return await Context.Set<T>().ToListAsync();
            }
            catch(Exception)
            {
                return new List<T>();
            }
        }

        public async Task<T> GetById(string id)
        {
            try
            {
                return await Context.Set<T>().FindAsync(id);
            }
            catch
            {
                return Activator.CreateInstance<T>();
            }
        }


        public async Task Update(T obj)
        {
            try
            {
                Context.Set<T>().Update(obj);
                await Context.SaveChangesAsync();
            }
            catch (Exception)
            {
                
            }

        }
    }
}
