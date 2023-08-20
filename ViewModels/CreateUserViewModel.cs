using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;
using System.Collections.Generic;
using VoorraadSysteem.Models;
using Microsoft.AspNetCore.Identity;

namespace VoorraadSysteem.ViewModels
{
	public class CreateUserViewModel
	{
		public string Name { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public ICollection<IdentityRole> Roles { get; set; }
		public ICollection<String> SelectedRoles { get; set; }
	}
}