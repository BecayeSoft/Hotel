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
		public string Id { get; set; }
		public int NumEtage { get; set; }
		public string NumBatiment { get; set; }
		public int NbLits{ get; set; }
		public Categorie Categorie { get; set; }
		public Boolean IsAvailable { get; set; }
		public Boolean HasBalcon { get; set; }
		public Boolean HasVue_sur_mer { get; set; }
		public Boolean HasSalle_sejour { get; set; }
		public Boolean HasCuisine { get; set; }
	}
}
