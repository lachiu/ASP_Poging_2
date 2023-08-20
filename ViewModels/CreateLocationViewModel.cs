using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VoorraadSysteem.Models;

namespace VoorraadSysteem.ViewModels
{
	public class CreateLocationViewModel
	{
		[Required(ErrorMessage = "Het veld 'naam' moet ingevuld zijn.")]
		[MaxLength(50)]
		public string Name { get; set; }
	}
}
