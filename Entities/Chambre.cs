using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Entities
{
	public class Chambre : BaseEntity
	{
		[ForeignKey("Categorie")]
		public Guid CategorieID { get; set; }
		public virtual Categorie Categorie { get; set; }

		public int Numero { get; set; }
		public int NumEtage { get; set; }
		public int NumBatiment { get; set; }
		public int NbLits{ get; set; }
		public Boolean IsAvailable { get; set; }
		public Boolean HasBalcon { get; set; }
		public Boolean HasVue_sur_mer { get; set; }
		public Boolean HasSalle_sejour { get; set; }
		public Boolean HasCuisine { get; set; }
	}
}
