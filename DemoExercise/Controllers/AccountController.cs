using DemoExercise.Interfaces.Services;
using DemoExercise.Models.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DemoExercise.Controllers
{
    public class AccountController : BaseController
    {
        private readonly ILoginService _loginService;

        public AccountController(ILoginService loginService, ILogger<AccountController> logger) : base(logger)
        {
            _loginService = loginService;
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> UpdateUserDetails()
        {
            var model = await _loginService.GetUserDetails(User.FindFirstValue(ClaimTypes.Name));
            return View(model);
        }

        [HttpPost, Authorize] 
        public async Task<IActionResult> UpdateUserDetails(UpdateUserDetailsViewModel model)
        {
            if(ModelState.IsValid)
            {
                var result = await _loginService.UpdateUser(model);

                if(result.Succeeded)
                {
                    return RedirectToAction("UpdateUserDetails", "Account");
                }
            }

            return View();
        }

        [AllowAnonymous, HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if(ModelState.IsValid)
            {
                var result = await _loginService.RegisterUser(model);

                if(result.Succeeded)
                {
                    var loginResult = await _loginService.LoginAsync(new LoginViewModel
                    {
                        Email = model.UserEmail,
                        Password = model.Password
                    });

                    if(loginResult.Succeeded)
                    {
                        await SignInAsync(model.UserEmail, model.FirstName, model.LastName, true);
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            return View();
        }

        [Authorize]
        public async Task<IActionResult> LoginHistory()
        {
            var model = await _loginService.GetLoginHistory(User.FindFirstValue(ClaimTypes.Name));

            return View(model);
        }

        [AllowAnonymous, HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                var result = await _loginService.LoginAsync(model);

                if(result.Succeeded)
                {
                    await SignInAsync(result.UserEmail, result.FirstName, result.LastName, model.RememberMe);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        [AllowAnonymous, HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

        public async Task SignInAsync(string userName, string firstName, string lastName, bool rememberMe)
        {
            var claims = new[]
{
                        new Claim(ClaimTypes.Name, userName),
                        new Claim("FirstName", firstName),
                        new Claim("LastName", lastName)
                    };
            var identity = new ClaimsIdentity(claims,
               CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identity);
            var props = new AuthenticationProperties();
            props.IsPersistent = rememberMe;
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props);
        }

    }
}
