using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SensorDataChallenge.DTOs;
using SensorDataChallenge.Enums;
using SensorDataChallenge.Filters;
using SensorDataChallenge.Interfaces;
using SensorDataChallenge.Models;
using System.Threading.Tasks;

namespace SensorDataChallenge.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IAccountRepository accountRepository)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            _accountRepository = accountRepository;
        }

        // GET: Account/Register
        [Authorize(PermissionEnum.CreateClient)]
        public async Task<IActionResult> Register()
        {
            var permissions = await _accountRepository.GetPermissions();
            ViewBag.Permissions = new MultiSelectList(permissions, "Id", "Description");
            var clients = _accountRepository.GetClients();
            ViewData["ClientId"] = new SelectList(clients, "Id", "BusinessName");

            return View(new RegisterDTO());
        }

        // POST: Account/Register
        [Authorize(PermissionEnum.CreateClient)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterDTO model)
        {
            model.Permission = await _accountRepository.Permissions(model);

            if (ModelState.IsValid)
            {
                // Copy data from RegisterViewModel to IdentityUser
                var user = new ApplicationUser
                {
                    UserName = model.UserName,
                    Description = model.Description,
                    Name = model.Name,
                    ClientId = model.ClientId,
                    Permission = model.Permission
                };

                // Store user data in AspNetUsers database table
                var result = await userManager.CreateAsync(user, model.Password);

                // If user is successfully created, sign-in the user using
                // SignInManager and redirect to index action of HomeController
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }

                // If there are any errors, add them to the ModelState object
                // which will be displayed by the validation summary tag helper
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [Microsoft.AspNetCore.Authorization.AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [Microsoft.AspNetCore.Authorization.AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginDTO model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(
                    model.UserName, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }

            return View(model);
        }

        [AcceptVerbs("Get", "Post")]
        [Microsoft.AspNetCore.Authorization.AllowAnonymous]
        public async Task<IActionResult> IsUserNameInUse(string username)
        {
            var user = await userManager.FindByEmailAsync(username);

            if (user == null)
            {
                return Json(true);
            }
            else
            {
                return Json($"Username {username} is already in use.");
            }
        }
    }
}