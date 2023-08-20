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
	
	public class VatPercentageController : Controller
	{
		private readonly IUnitOfWork _uow;
		public VatPercentageController(IUnitOfWork uow) { _uow = uow; }
		[Authorize(Roles = "Gebruiker, Admin")]
		public IActionResult Index()
		{
			VatPercentageListViewModel viewModel = new VatPercentageListViewModel();
			viewModel.VatPercentages = _uow.VatPercentageRepository.All().ToList();
			return View(viewModel);
		}
		[Authorize(Roles = "Gebruiker, Admin")]
		public IActionResult Search(VatPercentageListViewModel viewModel)
		{
			if (viewModel.VatPercentageSearch>=0)
			{
				viewModel.VatPercentages = _uow.VatPercentageRepository.Search().Where(v => v.Percentage == viewModel.VatPercentageSearch).ToList();
			}
			else
			{
				viewModel.VatPercentages = _uow.VatPercentageRepository.All().ToList();
			}
			return View("index", viewModel);
		}

		[Authorize(Roles = "Admin")]
		public IActionResult Create()
		{
			CreateVatPercentageViewModel viewModel = new CreateVatPercentageViewModel();
			return View(viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Create(CreateVatPercentageViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				_uow.VatPercentageRepository.Add(new VatPercentage()
				{
					Percentage = viewModel.Percentage
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

			var vatPercentage = await _uow.VatPercentageRepository.Find((int)id);
			if (vatPercentage == null)
			{
				return NotFound();
			}

			EditVatPercentageViewModel viewModel = new EditVatPercentageViewModel()
			{
				Id = vatPercentage.Id,
				Percentage = vatPercentage.Percentage,
			};
			return View(viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Edit(int id, EditVatPercentageViewModel viewModel)
		{
			if (id != viewModel.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					VatPercentage vatPercentage = await _uow.VatPercentageRepository.Find(id);
					vatPercentage.Percentage = viewModel.Percentage;
					_uow.VatPercentageRepository.Update(vatPercentage);
					await _uow.Save();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!_uow.VatPercentageRepository.Search().Any(s => s.Id == viewModel.Id))
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

			var vatPercentage = await _uow.VatPercentageRepository.Find((int)id);
			if (vatPercentage == null)
			{
				return NotFound();
			}

			DeleteVatPercentageViewModel viewModel = new DeleteVatPercentageViewModel()
			{
				Id = vatPercentage.Id,
				Percentage = vatPercentage.Percentage
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

			var user = await _uow.VatPercentageRepository.Find((int)id);
			if (user == null)
			{
				return NotFound();
			}

			_uow.VatPercentageRepository.Delete(user);
			await _uow.Save();
			return RedirectToAction(nameof(Index));
		}
	}
}
