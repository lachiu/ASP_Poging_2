using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using VoorraadSysteem.Data.UnitOfWork;
using VoorraadSysteem.Models;
using VoorraadSysteem.ViewModels;

namespace VoorraadSysteem.Controllers
{
	[Authorize(Roles = "Gebruiker, Admin")]
	public class LocationController : Controller
	{
		private UserManager<User> _userManager;
		private readonly IUnitOfWork _uow;
		public LocationController(IUnitOfWork uow, UserManager<User> userManager) { _uow = uow; _userManager = userManager; }
		public IActionResult Index()
		{
			LocationListViewModel viewModel = new LocationListViewModel();
			if (User.IsInRole("Admin"))
			{
				viewModel.Locations = _uow.LocationRepository.Search().Include(x => x.User).Include(x => x.Stocks).ToList();
			}
			else
			{
				string userId = _userManager.GetUserId(User);
				viewModel.Locations = _uow.LocationRepository.Search().Include(x => x.User).Include(x => x.Stocks).Where(x => x.UserId == userId).ToList();
			}
			
			return View(viewModel);
		}
		public IActionResult Search(LocationListViewModel viewModel)
		{
			if (!string.IsNullOrEmpty(viewModel.LocationSearch))
			{
				if (User.IsInRole("Admin"))
				{
					viewModel.Locations = _uow.LocationRepository.Search().Where(s => s.Name.Contains(viewModel.LocationSearch)).ToList();
				}
				else
				{
					string userId = _userManager.GetUserId(User);
					viewModel.Locations = _uow.LocationRepository.Search().Where(s => s.Name.Contains(viewModel.LocationSearch) && s.UserId == userId).ToList();
				}
			}
			else
			{
				viewModel.Locations = _uow.LocationRepository.All().ToList();
			}
			return View("index", viewModel);
		}
		
		public IActionResult Details(int id)
		{
			Location location = _uow.LocationRepository.Search().Include(x => x.User).Include(x => x.Stocks).ThenInclude(x => x.Product).SingleOrDefault(x => x.Id == id);
			if (location != null)
			{
				LocationDetailsViewModel viewModel = new LocationDetailsViewModel()
				{
					Name = location.Name,
					User = location.User,
					Stocks = location.Stocks
				};
				return View(viewModel);
			}
			else
			{
				LocationListViewModel viewModel = new LocationListViewModel();
				viewModel.Locations = _uow.LocationRepository.All().ToList();
				return View("index", viewModel);
			}
		}

		public IActionResult Create()
		{
			CreateLocationViewModel viewModel = new CreateLocationViewModel();
			return View(viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]

		public async Task<IActionResult> Create(CreateLocationViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				_uow.LocationRepository.Add(new Location()
				{
					Name = viewModel.Name,
					UserId = _userManager.GetUserId(User)
				});
				await _uow.Save();
				return RedirectToAction(nameof(Index));
			}
			return View(viewModel);
		}

		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var location = await _uow.LocationRepository.Find((int)id);
			if (location == null)
			{
				return NotFound();
			}

			EditLocationViewModel viewModel = new EditLocationViewModel()
			{
				Id = location.Id,
				Name = location.Name
			};
			return View(viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]

		public async Task<IActionResult> Edit(int id, EditLocationViewModel viewModel)
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
					Location location = await _uow.LocationRepository.Find(id);
					location.Name = viewModel.Name;
					_uow.LocationRepository.Update(location);
					await _uow.Save();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!_uow.LocationRepository.Search().Any(s => s.Id == viewModel.Id))
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

		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var location = await _uow.LocationRepository.Find((int)id);
			if (location == null)
			{
				return NotFound();
			}

			DeleteLocationViewModel viewModel = new DeleteLocationViewModel()
			{
				Id = location.Id,
				Name = location.Name
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

			var user = await _uow.LocationRepository.Find((int)id);
			if (user == null)
			{
				return NotFound();
			}

			_uow.LocationRepository.Delete(user);
			await _uow.Save();
			return RedirectToAction(nameof(Index));
		}
	}
}
