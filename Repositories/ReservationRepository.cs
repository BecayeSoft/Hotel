using Hotel.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Hotel.Repositories
{
    public class ReservationRepository : IReservationRepository
    {

        public ReservationRepository(AppDbContext appDbContext)
        {
            Context = appDbContext;
            table = appDbContext.Set<Reservation>();
        }

        public AppDbContext Context { get; }

        private DbSet<Reservation> table;

        public IEnumerable<Reservation> GetReservationByUserIncludes(Guid idUser, params Expression<Func<Reservation, object>>[] includes)
        {
            IQueryable<Reservation> query = table.Include(includes[0]).Where(r => r.UserID == idUser);
            foreach (var include in includes.Skip(1))
            {
                query = query.Include(include);
            }
            return query.ToList();
        }
    }
}
