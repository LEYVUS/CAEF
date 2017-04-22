using CAEF.Models.Entities.UABC;
using CAEF.Models.Repositories;
using CAEF.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CAEF.Controllers.Web
{
    [Route("/")]
    public class LoginController : Controller
    {
        private IUABCRepository _repositorioUABC;
        private SignInManager<UsuarioUABC> _signIn;

        public LoginController(IUABCRepository repositorioUABC, SignInManager<UsuarioUABC> signInManager)
        {
            _repositorioUABC = repositorioUABC;
            _signIn = signInManager;
        }

        [HttpGet("Login")]
        public IActionResult Login()
        {
            if(User.Identity.IsAuthenticated)
            {
                return Redirect("/");
            }
            return View();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTO login, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var username = login.Email.Split('@')[0];
                var signIn = await _signIn.PasswordSignInAsync(username,
                                                         login.Password,
                                                         true, false);
                if (signIn.Succeeded)
                {
                    if (string.IsNullOrWhiteSpace(returnUrl))
                    {
                        return Redirect("/");
                    }
                    else
                    {
                        return Redirect(returnUrl);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Usuario o contraseña incorrectos");
                }
            }
            return View();
        }

        [HttpGet("Logout")]
        public async Task<IActionResult> Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                await _signIn.SignOutAsync();
            }
            return Redirect("/");
        }

        [Authorize]
        [HttpGet("")]
        public IActionResult Inicio()
        {
            return View();
        }
    }
}
