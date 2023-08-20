using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VoorraadSysteem.Models;

namespace VoorraadSysteem.Models
{
	public class User : IdentityUser
	{		
		public string Name { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime LastLogin { get; set; }
		public ICollection<Ticket> Tickets { get; set; }
		public ICollection<Location> Locations { get; set; }
	}
}