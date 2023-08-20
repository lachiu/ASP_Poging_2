using Microsoft.AspNetCore.Authorization;
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
	public class StoreController : Controller
	{
		private readonly IUnitOfWork _uow;
		public StoreController(IUnitOfWork uow) { _uow = uow; }
		public IActionResult Index()
		{
			StoreListViewModel viewModel = new StoreListViewModel();
			viewModel.Stores = _uow.StoreRepository.All().ToList();
			return View(viewModel);
		}
		public IActionResult Search(StoreListViewModel viewModel)
		{
			if (!string.IsNullOrEmpty(viewModel.StoreSearch))
			{
				viewModel.Stores = _uow.StoreRepository.Search().Where(s => s.Name.Contains(viewModel.StoreSearch)).ToList();
			}
			else
			{
				viewModel.Stores = _uow.StoreRepository.All().ToList();
			}
			return View("index", viewModel);
		}
        [Authorize(Roles = "Admin")]
        public IActionResult Details(int id)
		{
			Store store = _uow.StoreRepository.Search().Include(x => x.Tickets).SingleOrDefault(x => x.Id == id);
			if (store != null)
			{
				StoreDetailsViewModel viewModel = new StoreDetailsViewModel()
				{
					Name = store.Name,
					Tickets = store.Tickets
				};
				return View(viewModel);
			}
			else
			{
				StoreListViewModel viewModel = new StoreListViewModel();
				viewModel.Stores = _uow.StoreRepository.All().ToList();
				return View("index", viewModel);
			}
		}
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
		{
			CreateStoreViewModel viewModel = new CreateStoreViewModel();
			return View(viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(CreateStoreViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				_uow.StoreRepository.Add(new Store()
				{
					Name = viewModel.Name
				});
				await _uow.Save();
				return RedirectToAction(nameof(Index));
			}
			return View(viewModel);
		}
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var store = await _uow.StoreRepository.Find((int)id);
			if (store == null)
			{
				return NotFound();
			}

			EditStoreViewModel viewModel = new EditStoreViewModel()
			{
				Id = store.Id,
				Name = store.Name,
			};
			return View(viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, EditStoreViewModel viewModel)
		{
			if (id != viewModel.Id)
			{
				return NotFound();
			}

			if (String.IsNullOrEmpty(viewModel.Name))
			{
				return View(viewModel);
			}

			if (ModelState.IsValid)
			{
				try
				{
					Store store = await _uow.StoreRepository.Find(id);
					store.Name = viewModel.Name;
					_uow.StoreRepository.Update(store);
					await _uow.Save();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!_uow.StoreRepository.Search().Any(s => s.Id == viewModel.Id))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction(nameof(Index));
			}
			return View(viewModel);
		}
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var store = await _uow.StoreRepository.Find((int)id);
			if (store == null)
			{
				return NotFound();
			}

			DeleteStoreViewModel viewModel = new DeleteStoreViewModel()
			{
				Id = store.Id,
				Name = store.Name
			};
			return View(viewModel);
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var user = await _uow.StoreRepository.Find((int)id);
			if (user == null)
			{
				return NotFound();
			}

			_uow.StoreRepository.Delete(user);
			await _uow.Save();
			return RedirectToAction(nameof(Index));
		}
	}
}
