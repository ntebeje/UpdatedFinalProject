using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CSC273_NTebeje_Final_Project.Auth;
using CSC273_NTebeje_Final_Project.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CSC273_NTebeje_Final_Project.Controllers
{
	public class AccountController : Controller
	{

		// apply the signinManager and UserManager clases
		private readonly UserManager<IdentityUser> _userManager;
		private readonly SignInManager<IdentityUser> _signInManager;


		// create a dependency injection
		public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
		{
			_signInManager = signInManager;
			_userManager = userManager;
		}

		// GET: /<controller>/
		public IActionResult Login(string returnUrl)
		{
			return View(new LoginViewModel
			{
				ReturnUrl = returnUrl
			});
		}

		// an action method responsible for the post action
		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel loginViewModel)
		{
			// Ckeck if the entered data is valid
			if (!ModelState.IsValid)
				return View(loginViewModel);

			// Search the username 
			var user = await _userManager.FindByNameAsync(loginViewModel.UserName);


			// This will return the user name
			if (user != null)
			{
				var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);

				// Redirect the user to the home page
				if (result.Succeeded)
				{
					return RedirectToAction("Index", "Home");
				}

			}

			// Display the combination is invalid
			ModelState.AddModelError("", "User name/password not found");
			return View(loginViewModel);
		}

		// An action method for registeration an account
		public IActionResult Register()
		{
			return View();
		}

		// an action method for responding for the registration account
		[HttpPost]
		public async Task<IActionResult> Register(LoginViewModel loginViewModel)
		{
			// Check if the entered data is correct
			if (ModelState.IsValid)
			{
				var user = new IdentityUser() { UserName = loginViewModel.UserName };
				var result = await _userManager.CreateAsync(user, loginViewModel.Password);

				// redirect the user to the home page
				if (result.Succeeded)
				{
					return RedirectToAction("Index", "Home");
				}

			}
			ModelState.AddModelError("", "User name/password is not valid");
			return View(loginViewModel);
		}

		// An action method for loging out
		[HttpPost]
		public async Task<IActionResult> Logout()
		{

			await _signInManager.SignOutAsync();
			return RedirectToAction("Index", "Home");
		}


		[AllowAnonymous]
		public IActionResult GoogleLogin(string returnUrl = null)
		{
			var redirectUrl = Url.Action("GoogleLoginCallback", "Account", new { ReturnUrl = returnUrl });
			var properties = _signInManager.ConfigureExternalAuthenticationProperties(ExternalLoginServiceConstants.GoogleProvider, redirectUrl);
			return Challenge(properties, ExternalLoginServiceConstants.GoogleProvider);
		}

		[AllowAnonymous]
		public async Task<IActionResult> GoogleLoginCallback(string returnUrl = null, string serviceError = null)
		{
			if (serviceError != null)
			{
				ModelState.AddModelError(string.Empty, $"Error from external provider: {serviceError}");
				return View(nameof(Login));
			}

			var info = await _signInManager.GetExternalLoginInfoAsync();
			if (info == null)
			{
				return RedirectToAction(nameof(Login));
			}

			var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, false);
			if (result.Succeeded)
			{
				if (returnUrl == null)
					return RedirectToAction("index", "home");

				return Redirect(returnUrl);
			}

			var user = new IdentityUser
			{
				Email = info.Principal.FindFirst(ClaimTypes.Email).Value,
				UserName = info.Principal.FindFirst(ClaimTypes.Email).Value
			};

			var identityResult = await _userManager.CreateAsync(user);

			

			identityResult = await _userManager.AddLoginAsync(user, info);

			

			await _signInManager.SignInAsync(user, false);

			if (returnUrl == null)
				return RedirectToAction("index", "home");

			return Redirect(returnUrl);
		}

	}
}

