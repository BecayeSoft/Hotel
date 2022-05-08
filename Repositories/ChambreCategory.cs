using Hotel.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Hotel.Repositories
{
	public class ChambreCategory : IChambreCategory
	{
		public ChambreCategory(AppDbContext appDbContext)
		{
			Context = appDbContext;
		}

		public AppDbContext Context { get; }

        public IEnumerable<Chambre> GetChambresByCategoryIncludes(Guid idCategorie, params Expression<Func<Chambre, object>>[] includes)
        {
            IQueryable<Chambre> query = Context.Chambres.Include(includes[0]).Where(c => c.CategorieID == idCategorie);
            foreach (var include in includes.Skip(1))
            {
                query = query.Include(include);
            }
            return query.ToList();
        }
    }
}
