using System.ComponentModel.DataAnnotations;

namespace VoorraadSysteem.ViewModels
{
	public class EditVatPercentageViewModel
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "Er moet een percentage meegegeven worden.")]
		public int Percentage { get; set; }
	}
}
