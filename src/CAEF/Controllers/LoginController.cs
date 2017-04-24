using CAEF.Models.Entities.UABC;
using CAEF.Models.Repositories;
using CAEF.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CAEF.Controllers
{
    [Route("/")]
    public class LoginController : Controller
    {
        private SignInManager<UsuarioUABC> _signIn;
        private IFIADRepository _repositorioFIAD;
        private IUABCRepository _repositorioUABC;
        private ICAEFRepository _repositorioCAEF;

        public LoginController(
            SignInManager<UsuarioUABC> signInManager,
            IFIADRepository repositorioFIAD,
            IUABCRepository repositorioUABC,
            ICAEFRepository repositorioCAEF)
        {
            _repositorioFIAD = repositorioFIAD;
            _repositorioUABC = repositorioUABC;
            _repositorioCAEF = repositorioCAEF;
            _signIn = signInManager;
        }

        [HttpGet("Login")]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return Redirect("/");
            }
            return View();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO login)
        {
            var username = login.Email.Split('@')[0];

            if (_repositorioUABC.UsuarioExiste(login.Email))
            {
                var signIn = await _signIn.PasswordSignInAsync(username,
                                                     login.Password,
                                                     true, false);
                if (signIn.Succeeded)
                {
                    if (_repositorioFIAD.UsuarioExiste(login.Email))
                    {
                        if (_repositorioCAEF.UsuarioDuplicado(login.Email))
                        {
                            return Ok();
                        }
                        else
                        {
                            await _signIn.SignOutAsync();
                            return BadRequest("El usuario no se encuentra registrado en el sistema.");
                        }
                    }
                    else
                    {
                        await _signIn.SignOutAsync();
                        return BadRequest("El usuario no pertenece a FIAD.");
                    }
                }
                else
                {
                    await _signIn.SignOutAsync();
                    return BadRequest("Ocurrió un error al iniciar sesión. Favor de verificar los datos.");
                }
            }
            else
            {
                return BadRequest("El usuario no pertenece a UABC.");
            }
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

        [Authorize]
        [HttpGet("CAEF/UsuarioActual")]
        public IActionResult GetCurrentUser()
        {
            var usuarioActual = _repositorioCAEF.UsuarioAutenticado(User.Identity.Name);

            return Ok(usuarioActual);
        }
    }
}
