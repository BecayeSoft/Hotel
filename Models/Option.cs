using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Models
{
	public class Option
	{
		[Key]
		public string IdOption { get; set; }
		public bool HasBalcon { get; set; }
		public bool HasVue_Sur_Mer { get; set; }
		public bool HasSalle_Sejour { get; set; }
		public bool HasCuisine { get; set; }
	}
}
