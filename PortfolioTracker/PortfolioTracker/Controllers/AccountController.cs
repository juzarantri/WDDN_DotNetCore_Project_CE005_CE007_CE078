using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PortfolioTracker.Controllers;
using PortfolioTracker.Models.Portfoliomodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PortfolioTracker.Models
{
    public class AccountController : Controller
    {
        public static string id;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signManager;
        public AccountController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signManager)
        {
            this.userManager = userManager;
            this.signManager = signManager;
        }

        [HttpGet]
        public ViewResult Register()
        {
            return View();
        }
        [HttpGet]
        public ViewResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> Register(UsersRegister user) {
            if (ModelState.IsValid)
            {
                var userData = new IdentityUser
                {
                    UserName = user.username,
                    Email = user.email
                };
                var success = await userManager.CreateAsync(userData, user.password);

                if (success.Succeeded) {
                    await signManager.SignInAsync(userData, isPersistent: false);
                    TempData["flag"] = "set";
                    using (var context = userManager)
                    {
                        foreach (var userdetails in context.Users)
                        {
                            if (userdetails.UserName == user.username)
                                id = userdetails.Id;
                        }
                    }
                    return RedirectToAction("Index", "Coin");
                }

                foreach (var err in success.Errors) {
                    ViewData["error"] += err.Description + " ";
                }
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UsersLogin user)
        {
            var success = await signManager.PasswordSignInAsync(user.username, user.password, false,true);
            if (success.Succeeded)
            {

                TempData["flag"] = "set";

                using (var context = userManager)
                {
                    foreach (var userdetails in context.Users)
                    {
                        if(userdetails.UserName == user.username)
                            id = userdetails.Id;
                    }
                }

                return RedirectToAction("Index", "Coin");
            }
            else
            {
                ViewData["error"] = "Invalid Login Attempt";
                return View();
            }
        }

        [HttpPost]
        public async Task<ActionResult> Logout() {
            await signManager.SignOutAsync();
            CoinController.t = -1;
            TempData["flag"] = null;
            return RedirectToAction("Login", "Account");
        }

    }
}
