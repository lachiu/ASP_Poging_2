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
	
	public class ProductController : Controller
	{
		private readonly IUnitOfWork _uow;
		public ProductController(IUnitOfWork uow) { _uow = uow; }
		public IActionResult Index()
		{
			ProductListViewModel viewModel = new ProductListViewModel();
			viewModel.Products = _uow.ProductRepository.All().ToList();
			return View(viewModel);
		}
		public IActionResult Search(ProductListViewModel viewModel)
		{
			if (!string.IsNullOrEmpty(viewModel.ProductSearch))
			{
				viewModel.Products = _uow.ProductRepository.Search().Where(p => p.Name.Contains(viewModel.ProductSearch)).ToList();
			}
			else
			{
				viewModel.Products = _uow.ProductRepository.All().ToList();
			}
			return View("index", viewModel);
		}

		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Details(int id)
		{
			Product product = await _uow.ProductRepository.Find(id);
			if (product != null)
			{
				ProductDetailsViewModel viewModel = new ProductDetailsViewModel()
				{
					Id = product.Id,
					Name = product.Name,
					Description = product.Description,
					Barcode= product.Barcode,
					Stocks = product.Stocks,
					TicketsProducts = product.TicketsProducts
				};
				return View(viewModel);
			}
			else
			{
				ProductListViewModel viewModel = new ProductListViewModel();
				viewModel.Products = _uow.ProductRepository.All().ToList();
				return View("index", viewModel);
			}
		}

		[Authorize(Roles = "Admin")]
		public IActionResult Create()
		{
			CreateProductViewModel viewModel = new CreateProductViewModel();
			return View(viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Create(CreateProductViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				_uow.ProductRepository.Add(new Product()
				{
					Name = viewModel.Name,
					Description = viewModel.Description,
					Barcode = viewModel.Barcode
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

			var product = await _uow.ProductRepository.Find((int)id);
			if (product == null)
			{
				return NotFound();
			}

			EditProductViewModel viewModel = new EditProductViewModel()
			{
				Id = product.Id,
				Name = product.Name,
				Description = product.Description,
				Barcode = product.Barcode
			};
			return View(viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Edit(int id, EditProductViewModel viewModel)
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
					Product product = await _uow.ProductRepository.Find(id);
					product.Name = viewModel.Name;
					_uow.ProductRepository.Update(product);
					await _uow.Save();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!_uow.ProductRepository.Search().Any(s => s.Id == viewModel.Id))
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

			var product = await _uow.ProductRepository.Find((int)id);
			if (product == null)
			{
				return NotFound();
			}

			DeleteProductViewModel viewModel = new DeleteProductViewModel()
			{
				Id = product.Id,
				Name = product.Name
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

			var user = await _uow.ProductRepository.Find((int)id);
			if (user == null)
			{
				return NotFound();
			}

			_uow.ProductRepository.Delete(user);
			await _uow.Save();
			return RedirectToAction(nameof(Index));
		}
	}
}
