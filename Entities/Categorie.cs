using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Entities
{
	public class Categorie : BaseEntity
	{
		public string Libelle { get; set; }
		public double Tarif { get; set; }
		public string Description { get; set; }
	}
}
