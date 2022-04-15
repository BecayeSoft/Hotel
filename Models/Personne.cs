using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Models
{
	public class Personne
	{
		[Key]
		public string IdPersonne { get; set; }

		public string IdFirebasePersonne { get; set; }

		public string Nom { get; set; }
		
		public string Prenom { get; set; }
		
		public string Adresse { get; set; }

		public string Email { get; set; }
		
		public string Telephone { get; set; }
		
		public string Mot_de_passe { get; set; }
		
		public int Age { get; set; }
		
		public string Sexe { get; set; }
		
		public string Privilege { get; set; }
	}
}
