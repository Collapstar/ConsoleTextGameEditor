using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;

namespace JogoTexto3.Models {
	public class JogoDbContext : DbContext {
		public DbSet<Room> Rooms { get; set; }
		//public DbSet<Character> Characters { get; set; }
		public DbSet<Player> Players { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder) {
			modelBuilder.Entity<Room>()
				.HasOne(r => r.NorthExit)
				.WithMany();

			modelBuilder.Entity<Room>()
				.HasOne(r => r.SouthExit)
				.WithMany();

			modelBuilder.Entity<Room>()
				.HasOne(r => r.WestExit)
				.WithMany();

			modelBuilder.Entity<Room>()
				.HasOne(r => r.EastExit)
				.WithMany();
		}


		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
			optionsBuilder.UseSqlServer(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = JogoTexto3; Integrated Security = True;");
		}
	}
}
