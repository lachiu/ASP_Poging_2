using System.ComponentModel.DataAnnotations;

namespace VoorraadSysteem.ViewModels
{
	public class CreateVatPercentageViewModel
	{
		[Required(ErrorMessage = "Er moet een percentage meegegeven worden.")]
		public int Percentage { get; set; }
	}
}
