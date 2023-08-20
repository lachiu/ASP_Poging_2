using System.Collections.Generic;
using VoorraadSysteem.Models;

namespace VoorraadSysteem.ViewModels
{
	public class UserListViewModel
	{
		public string UserSearch { get; set; }
		public List<User> Users { get; set; }
	}
}
