using Hotel.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options)
			:base(options)
		{

		}

		// Tables
		public DbSet<Categorie> Categories { get; set; }
		public DbSet<Chambre> Chambres { get; set; }
		public DbSet<Lit> Lits { get; set; }
		public DbSet<Option> Options { get; set; }
		public DbSet<Personne> Personnes { get; set; }
		public DbSet<Reservation> Reservations { get; set; }
	}
}
