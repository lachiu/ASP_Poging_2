using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoorraadSysteem.Data.UnitOfWork;
using VoorraadSysteem.Models;
using VoorraadSysteem.ViewModels;

namespace VoorraadSysteem.Controllers
{
	public class TicketController : Controller
	{
		private readonly IUnitOfWork _uow;
		public TicketController(IUnitOfWork uow) { _uow = uow; }

		public IActionResult Index()
		{
			TicketListViewModel viewModel = new TicketListViewModel();
			viewModel.Tickets = _uow.TicketRepository.All().ToList();
			return View(viewModel);
		}

		public IActionResult Search(TicketListViewModel viewModel)
		{
			if (!string.IsNullOrEmpty(viewModel.StoreSearch))
			{
				viewModel.Tickets = _uow.TicketRepository.Search().Where(s => s.Store.Name.Contains(viewModel.StoreSearch)).ToList();
			}
			else
			{
				viewModel.Tickets = _uow.TicketRepository.All().ToList();
			}
			return View("index", viewModel);
		}

		public async Task<IActionResult> Details(int? id)
		{
			Ticket ticket = await _uow.TicketRepository.Find((int)id);
			if (ticket != null)
			{
				TicketDetailsViewModel viewModel = new TicketDetailsViewModel()
				{
					Store = ticket.Store,
					Total = ticket.Total,
					PurchaseDate = ticket.PurchaseDate,
					TicketsProducts = ticket.TicketsProducts
				};
				return View(viewModel);
			}
			else
			{
				TicketListViewModel viewModel = new TicketListViewModel();
				viewModel.Tickets = _uow.TicketRepository.All().ToList();
				return View("index", viewModel);
			}
		}

		public IActionResult Create()
		{
			CreateTicketViewModel viewModel = new CreateTicketViewModel();
			viewModel.Stores = _uow.StoreRepository.All().ToList();
			return View(viewModel);
		}

		// Tijdgebrek
		//[HttpPost]
		//[ValidateAntiForgeryToken]
		//public async Task<IActionResult> Create(CreateTicketViewModel viewModel)
		//{
		//	if (ModelState.IsValid)
		//	{
		//		_uow.TicketRepository.Add(new Ticket()
		//		{
		//			store_id = viewModel.store_id,
		//			purchase_date = viewModel.purchase_date
		//		});
		//		await _uow.Save();
		//		return RedirectToAction(nameof(Index));
		//	}
		//	return View(viewModel);
		//}

		// Tijdgebrek
		//public async Task<IActionResult> Edit(int? id)
		//{
		//	if (id == null)
		//	{
		//		return NotFound();
		//	}

		//	var user = await _uow.TicketRepository.Find((int)id);
		//	if (user == null)
		//	{
		//		return NotFound();
		//	}

		//	EditTicketViewModel viewModel = new EditTicketViewModel()
		//	{
		//		id = user.id,
		//		name = user.name,
		//		password = user.password,
		//		permission_id = user.permission_id,
		//		created = user.created,
		//		last_login = user.last_login,
		//		Permissions = _uow.PermissionRepository.All().ToList()
		//	};
		//	return View(viewModel);
		//}

		//[HttpPost]
		//[ValidateAntiForgeryToken]
		//public async Task<IActionResult> Edit(int id, EditTicketViewModel viewModel)
		//{
		//	if (id != viewModel.id)
		//	{
		//		return NotFound();
		//	}

		//	if (ModelState.IsValid)
		//	{
		//		try
		//		{
		//			Ticket user = new Ticket()
		//			{
		//				id = viewModel.id,
		//				name = viewModel.name,
		//				password = viewModel.password,
		//				permission_id = viewModel.permission_id,
		//				created = viewModel.created
		//			};
		//			_uow.TicketRepository.Update(user);
		//			await _uow.Save();
		//		}
		//		catch (DbUpdateConcurrencyException)
		//		{
		//			if (!_uow.TicketRepository.Search().Any(e => e.id == viewModel.id))
		//			{
		//				return NotFound();
		//			}
		//			else
		//			{
		//				throw;
		//			}
		//		}
		//		return RedirectToAction(nameof(Index));
		//	}
		//	return View(viewModel);
		//}

		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var ticket = await _uow.TicketRepository.Find((int)id);
			if (ticket == null)
			{
				return NotFound();
			}

			DeleteTicketViewModel viewModel = new DeleteTicketViewModel()
			{
				Id = ticket.Id
			};
			return View(viewModel);
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var user = await _uow.TicketRepository.Find((int)id);
			if (user == null)
			{
				return NotFound();
			}

			_uow.TicketRepository.Delete(user);
			await _uow.Save();
			return RedirectToAction(nameof(Index));
		}
	}
}
