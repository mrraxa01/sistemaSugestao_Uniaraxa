using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sistemasugestao.Context;
using sistemasugestao.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;



namespace sistemasugestao.Controllers
{
    public class LoginController: Controller
    {

        private readonly UserManager<Login> _userManager;
        private readonly SignInManager<Login> _signInManager;
        private readonly ILogger<Login> _logger;
        public LoginController(UserManager<Login> userManager,
        SignInManager<Login> signInManager,
        ILogger<Login> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index(string returnURL = null)
        {
            ViewBag.ReturnUrl = returnURL;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(LoginViewModel model,
        string returnURL = null)
        {
            ViewBag.ReturnUrl = returnURL;
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(
                    model.Email, model.Password, model.flManterLogado, lockoutOnFailure: false
                );
                if (result.Succeeded)
                {
                    _logger.LogInformation("Usuário Autenticado.");
                    return RedirectToLocal(returnURL);
                }
            }
           
            TempData["type"] = "danger";
            TempData["title"] = "Erro";
            TempData["body"] = "Falha na tentativa de login, tente novamente!";

            return View(model);
        }

        private IActionResult RedirectToLocal(string returnURL)
        {
            if (Url.IsLocalUrl(returnURL))
            {
                return Redirect(returnURL);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public IActionResult RegistrarNovoUsuario()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegistrarNovoUsuario(LoginViewModel model,
                                                             string returnUrl = null)
        {
            ViewBag.ReturnUrl = returnUrl;
            if (ModelState.IsValid)
            {
                var user = new Login { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("Usuário criou uma nova conta com senha!");
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    _logger.LogInformation("Usuário acesso com a conta criada!");

                    TempData["type"] = "success";
                    TempData["title"] = "Logon:";
                    TempData["body"] = "Usuario cadastrado com sucesso!";

                    return RedirectToLocal(returnUrl);
                }
                AddErrors(result);
            }
            return View(model);
        }
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }


        [HttpGet]
        public async Task<IActionResult> Sair()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("Usuário realizou Logout!");
            return RedirectToAction("Login", "Usuario");
        }

    }



}