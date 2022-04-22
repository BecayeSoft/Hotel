using Hotel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Repositories
{
	public interface IChambreCategory
	{
		Task<IEnumerable<Chambre>> GetChambresByCategory(Guid idCategorie);
	}
}
