using System.ComponentModel.DataAnnotations;

namespace VoorraadSysteem.ViewModels
{
	public class DeleteVatPercentageViewModel
	{
		[Required(ErrorMessage = "Er moet een ID meegegeven worden.")]
		public int Id { get; set; }
		[Required(ErrorMessage = "Er moet een percentage meegegeven worden.")]
		public int Percentage { get; set; }
	}
}
