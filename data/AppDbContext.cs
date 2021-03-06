using Hotel.Entities;
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
		public DbSet<User> Users { get; set; }
		public DbSet<Reservation> Reservations { get; set; }
	}
}
