using BMS.DataLayer.ApplicationUser;
using BMS.DataModel;
using BookManagementSystem_24Feb2024.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BookManagementSystem_24Feb2024.Controllers
{
    [AllowAnonymous]
    public class AccountController : BaseController
    {
        private readonly IAppUser appuser;

        public AccountController(IAppUser user)
        {
            appuser = user;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginModel model,string ReturnUrl = "/")
        {
            //bool isValid = appuser.IsValid(model.UserId, model.Password, out User user);
            if (appuser.IsValid(model.UserId, model.Password, out User user))
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name,user.UserName),
                    new Claim(ClaimTypes.Email,user.UserEmail)
                };

                var Identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var Princple = new ClaimsPrincipal(Identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, Princple);
                return LocalRedirect(ReturnUrl);
            }
            Notify("Invalid User", "Incorrect username or password", MessagetType.error);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(Login));
        }


    }
}
