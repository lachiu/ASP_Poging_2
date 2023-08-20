using System.ComponentModel.DataAnnotations;

namespace VoorraadSysteem.ViewModels
{
	public class CreateProductViewModel
	{
		[Required(ErrorMessage = "Er moet een productnaam opgegeven worden.")]
		public string Name { get; set; }
		public string Description { get; set; }
		public string Barcode { get; set; }
	}
}
