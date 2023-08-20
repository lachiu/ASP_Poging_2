using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VoorraadSysteem.Models;

namespace VoorraadSysteem.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{

		}
		public DbSet<Location> Locations { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Stock> Stocks { get; set; }
		public DbSet<Store> Stores { get; set; }
		public DbSet<Ticket> Tickets { get; set; }
		public DbSet<TicketsProducts> TicketsProducts { get; set; }
		public DbSet<VatPercentage> VatPercentages { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			/* Seeding */
			/* Creating 2 basic roles */
			builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" });
			builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Gebruiker", NormalizedName = "GEBRUIKER" });			

			/* Creating general stores */
			builder.Entity<Store>().HasData(new Store { Id = 1, Name = "Lidl" });
			builder.Entity<Store>().HasData(new Store { Id = 2, Name = "Carrefour" });
			builder.Entity<Store>().HasData(new Store { Id = 3, Name = "Spar" });
			builder.Entity<Store>().HasData(new Store { Id = 4, Name = "Action" });
			builder.Entity<Store>().HasData(new Store { Id = 5, Name = "Aldi" });
			builder.Entity<Store>().HasData(new Store { Id = 6, Name = "Delhaize" });
			builder.Entity<Store>().HasData(new Store { Id = 7, Name = "Albert Heijn" });
			builder.Entity<Store>().HasData(new Store { Id = 8, Name = "Jumbo" });
		}		
	}
}
