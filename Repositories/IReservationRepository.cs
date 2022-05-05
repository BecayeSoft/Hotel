using Hotel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Hotel.Repositories
{
    public interface IReservationRepository
    {
        //Task<IEnumerable<Reservation>> GetReservationByUser(Guid idUser);

        IEnumerable<Reservation> GetReservationByUserIncludes(Guid idUser,params Expression<Func<Reservation, Object>>[] includes);
    }
}
