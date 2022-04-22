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
		public string Id { get; set; }
		public string IdUser { get; set; }
		public Chambre[] Chambres { get; set; }
		public DateTime DateReservation { get; set; }
		public DateTime DateEntree { get; set; }
		public DateTime DateSortie { get; set; }
		public bool IsActive { get; set; }
		public double Montant { get; set; }
		public int Nb_Adults { get; set; }
		public int Nb_Enfants { get; set; }
	}
}
