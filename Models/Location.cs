using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;
using VoorraadSysteem.Models;

namespace VoorraadSysteem.Models
{
	public class Location
	{
		[Key]
		public int Id { get; set; }

		[Display(Name = "Naam")]
		[Required(ErrorMessage = "Het veld 'naam' moet ingevuld zijn.")]
		[MaxLength(50)]
		public string Name { get; set; }

		[Required(ErrorMessage = "Er moet een gebruiker geselecteerd zijn.")]
		public string UserId { get; set; }
		public virtual User User { get; set; }
		public ICollection<Stock> Stocks { get; set; }
	}
}