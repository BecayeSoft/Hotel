using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Entities
{
	public class Reservation : BaseEntity
	{
		[ForeignKey("IdUser")]
		public Guid IdUser { get; set; }
        public virtual User User { get; set; }
        public ICollection<ReservationChambre> Chambres { get; set; }
		public DateTime DateReservation { get; set; }
		public DateTime DateEntree { get; set; }
		public DateTime DateSortie { get; set; }
		public bool IsActive { get; set; }
		public double Montant { get; set; }
		public int Nb_Adults { get; set; }
		public int Nb_Enfants { get; set; }
	}
}
