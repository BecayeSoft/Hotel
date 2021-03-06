using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Entities
{
	public class User : BaseEntity
	{
		public string IdFirebaseUser { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public string Nom { get; set; }
		public string Prenom { get; set; }
		public string Adresse { get; set; }
		public string Email { get; set; }
		public string Telephone { get; set; }
		public int Age { get; set; }
		public string Sexe { get; set; }
		public string Privilege { get; set; }
	}
}
