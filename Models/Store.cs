using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace VoorraadSysteem.Models
{
	public class Store
	{
		[Key]
		public int Id { get; set; }
		[Display(Name = "Naam")]
		[Required(ErrorMessage = "Het veld 'naam' moet ingevuld zijn.")]
		[MaxLength(50)]
		public string Name { get; set; }

		public ICollection<Ticket> Tickets { get; set; }
	}
}
