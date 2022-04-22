using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Models
{
	public class Categorie
	{
		[Key]
		public string Id { get; set; }
		public string Libelle { get; set; }
		public double Tarif { get; set; }
		public string Description { get; set; }
	}
}
