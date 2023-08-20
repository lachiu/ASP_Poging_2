using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Linq;
using VoorraadSysteem.Models;
using VoorraadSysteem.ViewModels;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using VoorraadSysteem.Data.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace VoorraadSysteem.Controllers
{
    public class UserController : Controller
    {
		private UserManager<User> _userManager;
		private RoleManager<IdentityRole> _roleManager;
		public UserController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
		{
			_userManager = userManager;
			_roleManager = roleManager;
		}
		public IActionResult Index()
        {
            UserListViewModel viewModel = new UserListViewModel();
            viewModel.Users = _userManager.Users.ToList();
            return View(viewModel);
        }

        public IActionResult Search(UserListViewModel viewModel)
        {
            if (!string.IsNullOrEmpty(viewModel.UserSearch))
            {
                viewModel.Users = _userManager.Users.Where(u => u.Name.Contains(viewModel.UserSearch)).ToList();
            } 
            else
            {
                viewModel.Users = _userManager.Users.ToList();
			}
			return View("index", viewModel);
		}

        public async Task<IActionResult> Details(string id)
        {
            User user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                UserDetailsViewModel viewModel = new UserDetailsViewModel()
                {
                    Name = user.Name,
                    CreatedAt = user.CreatedAt,
                    LastLogin = user.LastLogin
                };
                return View(viewModel);
            }
            else
            {
                UserListViewModel viewModel = new UserListViewModel();
                viewModel.Users = _userManager.Users.ToList();
				return View("index", viewModel);
			}
        }

        public IActionResult Create()
        {
			CreateUserViewModel viewModel = new CreateUserViewModel();
            viewModel.Roles = _roleManager.Roles.ToList();
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateUserViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                User _user = new User { Id = Guid.NewGuid().ToString(), Name = viewModel.Name, Email = viewModel.Email, CreatedAt = DateTime.UtcNow };
				string hashedPassword = _userManager.PasswordHasher.HashPassword(_user, viewModel.Password);
                _user.PasswordHash = hashedPassword;
                _user.SecurityStamp = Guid.NewGuid().ToString();
				IdentityResult result = await _userManager.CreateAsync(_user);
                if (result.Succeeded)
                {
                    await _userManager.AddToRolesAsync(_user, viewModel.SelectedRoles);
					return RedirectToAction(nameof(Index));
				}				
            }
            return View(viewModel);
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            User user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            EditUserViewModel viewModel = new EditUserViewModel()
            {
                Name = user.Name,
                Email = user.Email,
                AllRoles = _roleManager.Roles.Select(x => x.Name).ToList(),
                UserRoles = await _userManager.GetRolesAsync(user)
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, EditUserViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    User _user = await _userManager.FindByIdAsync(id);
					if (_user == null)
					{
						return NotFound();
					}

                    if (!String.IsNullOrEmpty(viewModel.Password)) 
                    {
						string hashedPassword = _userManager.PasswordHasher.HashPassword(_user, viewModel.Password);
						_user.PasswordHash = hashedPassword;
                        _user.SecurityStamp = Guid.NewGuid().ToString();
					}

                    _user.Name = viewModel.Name;
					_user.Email = viewModel.Email;

					IdentityResult result = await _userManager.UpdateAsync(_user);										
					if (result.Succeeded)
					{
                        ICollection<String> originalRoles = await _userManager.GetRolesAsync(_user);
                        IEnumerable<String> rolesToAdd = viewModel.UserRoles.Where(x => !originalRoles.Contains(x));
						IEnumerable<String> rolesToDelete = originalRoles.Where(x => !viewModel.UserRoles.Contains(x));

                        if (rolesToAdd.Any())
                        {
							await _userManager.AddToRolesAsync(_user, rolesToAdd);
						}

						if (rolesToDelete.Any())
						{
							await _userManager.RemoveFromRolesAsync(_user, rolesToDelete);
						}

						return RedirectToAction(nameof(Index));
					}
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            User user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            DeleteUserViewModel viewModel = new DeleteUserViewModel()
            {
                Id = user.Id,
                Name = user.Name
            };
            return View(viewModel);
        }

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(string id)
		{
			if (id == null)
			{
				return NotFound();
			}

			User user = await _userManager.FindByIdAsync(id);
			if (user == null)
			{
				return NotFound();
			}

            await _userManager.DeleteAsync(user);
			return RedirectToAction(nameof(Index));
		}
	}
}
