using CAEF.Models.Entities.UABC;
using CAEF.Models.Repositories;
using CAEF.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using CAEF.Models.Services;

namespace CAEF.Controllers
{
    [Route("/")]
    public class LoginController : Controller
    {
        private SignInManager<UsuarioUABC> _signIn;
        private IFIADRepository _repositorioFIAD;
        private IUABCRepository _repositorioUABC;
        private ICAEFRepository _repositorioCAEF;
        private IUsuarioRepository _repositorioUsuario;
        private LoginServices _login;

        public LoginController(
            SignInManager<UsuarioUABC> signInManager,
            IFIADRepository repositorioFIAD,
            IUABCRepository repositorioUABC,
            ICAEFRepository repositorioCAEF,
            IUsuarioRepository repositorioUsuario,
            LoginServices login)
        {
            _repositorioFIAD = repositorioFIAD;
            _repositorioUABC = repositorioUABC;
            _repositorioCAEF = repositorioCAEF;
            _signIn = signInManager;
            _login = login;
            _repositorioUsuario = repositorioUsuario;
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
            string sesion = await _login.Login(login);

            if (sesion != null)
                return BadRequest(sesion);
            else
                return Ok();
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
            var usuarioActual = _repositorioUsuario.UsuarioAutenticado(User.Identity.Name);

            return Ok(usuarioActual);
        }
    }
}
