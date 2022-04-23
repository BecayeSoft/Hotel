using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Entities
{
    public class ReservationChambre
    {
        public Guid ChambreId { get; set; }
        public Chambre Chambre { get; set; }

        public Guid ReservationId { get; set; }
        public Reservation Reservation { get; set; }
    }
}
