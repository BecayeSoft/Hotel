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

      //  public async Task Add(T obj)
       // {
         //   try
           // {
               // await Context.
           // }

       // }
	}
}
