using Hotel.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

		public async Task<IEnumerable<Chambre>> GetChambresByCategory(Guid idCategorie)
		{
            try
            {
                return await Context.Chambres.Where(c => c.IdCategorie == idCategorie).ToListAsync();
            }
            catch (Exception)
            {
                return new List<Chambre>();
            }
        }
    }
}
