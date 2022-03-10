using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Models
{
	public class Lit
	{
		[Key]
		public string IdLit { get; set; }
		public int Nombre { get; set; }
		public int Nb_places { get; set; }
	}
}
