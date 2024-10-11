using Ahmed.C42.DAL.Entities.Identity;
using Ahmed.C42.PL.ViewModels.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ahmed.C42.PL.Controllers
{
	public class AccountController : Controller
	{
		#region Services

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

		#endregion

		#region SignUp

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

		#endregion

		#region SignIn

		[HttpGet]
		public IActionResult SignIn()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> SignIn(SignInViewModel signInViewModel)
		{
			if (!ModelState.IsValid)
				return BadRequest();

			var user = await _userManager.FindByEmailAsync(signInViewModel.Email);
			
			if(user is not null)
			{
				var checkPass = await _userManager.CheckPasswordAsync(user,signInViewModel.Password);
				if (checkPass)
				{
					var result = await _signInManager.PasswordSignInAsync(user, signInViewModel.Password, signInViewModel.RememberMe, true);

					if (result.IsNotAllowed)
						ModelState.AddModelError(string.Empty, "Your account is not Confirmed yet!!");

					if (result.IsLockedOut)
						ModelState.AddModelError(string.Empty, "Youe Account is Locked!!");

					///if (result.RequiresTwoFactor)
					///{
					///}

					if(result.Succeeded)
						return RedirectToAction(nameof(HomeController.Index) ,"Home");
				}
			}

			ModelState.AddModelError(string.Empty, " Invalid Login Attempt.");
			return View(signInViewModel);

		}
		#endregion
	}
}
