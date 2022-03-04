using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Models
{
	public class Chambre
	{
		[Key]
		public string IdChambre { get; set; }
		public int Num_etage { get; set; }
		public string Batiment { get; set; }
		public Option Option { get; set; }
		public Categorie Categorie { get; set; }
		public Lit Lit { get; set; }
	}
}
