using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProScape.Application.Common.Interfaces;
using ProScape.Application.Common.Utility;
using ProScape.Domain.Entities;
using ProScape.Web.ViewModels;

namespace ProScape.Web.Controllers;

public class AccountController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public AccountController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
    {
        _unitOfWork = unitOfWork;
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
    }

    public IActionResult Register(string returnUrl = null)
    {
        returnUrl ??= Url.Content("~/");

        if (!_roleManager.RoleExistsAsync(StaticDetails.Role_Admin).GetAwaiter().GetResult())
        {
            _roleManager.CreateAsync(new IdentityRole(StaticDetails.Role_Admin)).Wait();
            _roleManager.CreateAsync(new IdentityRole(StaticDetails.Role_Client)).Wait();
        }
        RegisterViewModel registerViewModel = new()
        {
            RedirectUrl = returnUrl
        };

        return View(registerViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
    {
        if (ModelState.IsValid)
        {
            ApplicationUser user = new()
            {
                FirstName = registerViewModel.FirstName,
                LastName = registerViewModel.LastName,
                PhoneNumber = registerViewModel.PhoneNumber,
                Email = registerViewModel.Email,
                NormalizedEmail = registerViewModel.Email.ToUpper(),
                EmailConfirmed = true,
                UserName = registerViewModel.Email,
                CreatedAt = DateTime.UtcNow,
            };

            var result = await _userManager.CreateAsync(user, registerViewModel.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, StaticDetails.Role_Client);
                await _signInManager.SignInAsync(user, isPersistent: false);

                if (string.IsNullOrEmpty(registerViewModel.RedirectUrl))
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return LocalRedirect(registerViewModel.RedirectUrl); ;
                }
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }
        return View(registerViewModel);
    }

    public IActionResult Login(string returnUrl = null)
    {
        returnUrl ??= Url.Content("~/");

        LoginViewModel loginViewModel = new()
        {
            RedirectUrl = returnUrl
        };

        return View(loginViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel loginViewModel)
    {
        if (ModelState.IsValid)
        {
            var result = await _signInManager
                .PasswordSignInAsync(loginViewModel.Email, loginViewModel.Password, loginViewModel.RememberMe, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                if (string.IsNullOrEmpty(loginViewModel.RedirectUrl))
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return LocalRedirect(loginViewModel.RedirectUrl); ;
                }
            }
            else
            {
                {
                    ModelState.AddModelError("", "Invalid login attempt");
                }
            }
        }

        return View(loginViewModel);
    }

    public async Task<IActionResult> LogOut()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }

    public IActionResult AccessDenied()
    {
        return View();
    }
}
