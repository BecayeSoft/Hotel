using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Repositories
{
	public class Repository: IRepository
	{
		public AppDbContext Context { get; }
		public Repository(AppDbContext context)
        {
			Context = context;
        }

        public async Task Add(T obj)
       {
            try
           {
                await Context.AddAsync<T>(obj);
                await Context.SaveChangesAsync();
            }
            catch (Exception)
            {
            }
        }
        public async Task<T> GetById(int id)
        {
            try
            {
                return await Context.FindAsync(id);
            }
            catch(Exception)
            {
                return new T();
            }
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            try
            {
                return await Context.ToListAsyn();
            }
            catch (Exception)
            {
                return new List<T>();
            }
        }
        public async Task Delete(T obj)
        {
            try
            {
                Context.Remove(T);
                await Context.SaveChangesAsync();
            }
            catch (Exception)
            {
            }
        }
        public async Task Update(T obj)
        {
            try
            {
                Context.Update(T);
                await Context.SaveChangesAsync();
            }
            catch (Exception)
            {
            }
        }
    }
}
