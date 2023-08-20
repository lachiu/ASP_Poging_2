using System.ComponentModel.DataAnnotations;

namespace VoorraadSysteem.ViewModels
{
	public class EditProductViewModel
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "Het veld 'naam' moet ingevuld zijn.")]
		public string Name { get; set; }
		public string Description { get; set; }
		public string Barcode { get; set; }
	}
}
