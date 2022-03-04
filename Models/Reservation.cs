using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Models
{
	public class Reservation
	{
		[Key]
		public string IdReservation { get; set; }
		public Chambre Chambre { get; set; }
		public DateTime DateReservation { get; set; }
		public DateTime DateEntree { get; set; }
		public DateTime DateSortie { get; set; }
		public bool Etat { get; set; }
		public Personne Personne { get; set; }
		public double Montant { get; set; }
	}
}
