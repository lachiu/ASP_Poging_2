using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;
using System.Collections.Generic;
using VoorraadSysteem.Models;
using Microsoft.AspNetCore.Identity;

namespace VoorraadSysteem.ViewModels
{
	public class EditUserViewModel
	{
		public string Id { get; set; }
		[Required(ErrorMessage = "Gelieve een geldige naam op te geven.")]
		public string Name { get; set; }
		[Required(ErrorMessage = "Gelieve een geldige email op te geven.")]
		[EmailAddress]
		public string Email { get; set; }
		public string Password { get; set; }
		public ICollection<String> AllRoles { get; set; }
		public ICollection<String> UserRoles { get; set; }
	}
}