using Ahmed.C42.DAL.Entities.Identity;
using Ahmed.C42.PL.ViewModels.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ahmed.C42.PL.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;

		public AccountController(
			UserManager<ApplicationUser> userManager,
			SignInManager<ApplicationUser> signInManager
			)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}
		[HttpGet]
		public IActionResult SignUp()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> SignUp(SignUpViewModel signUpViewModel)
		{
			if (!ModelState.IsValid)
				return BadRequest();

			var user = await _userManager.FindByNameAsync(signUpViewModel.UserName);


			if (user is not null)
			{
				ModelState.AddModelError(nameof(SignUpViewModel.UserName), "This Username is already in user for another account.");
				return View(signUpViewModel);
			}

			user = new ApplicationUser()
			{
				FName = signUpViewModel.FirstName,
				LName = signUpViewModel.LastName,
				UserName = signUpViewModel.UserName,
				Email = signUpViewModel.Email,
				IsAgree = signUpViewModel.IsAgree,

			};

			var result = await _userManager.CreateAsync(user, signUpViewModel.Password);

			if (result.Succeeded)
				return RedirectToAction(nameof(SignIn));

			foreach (var error in result.Errors)
				ModelState.AddModelError(string.Empty, error.Description);

			return View(signUpViewModel);
		}
	}
}
