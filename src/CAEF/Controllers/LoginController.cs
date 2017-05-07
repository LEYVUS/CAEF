using CAEF.Models.DTO;
using CAEF.Models.Entities.UABC;
using CAEF.Models.Repositories;
using CAEF.Servicios;
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


        private LoginServicio loginServicio = new LoginServicio();
        private UsuarioServicio usuarioServicio = new UsuarioServicio();
        

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

            MensajeDTO mensaje = await loginServicio.Logear(login);

            if (mensaje.estado)
            {
                return Ok();
            }
            return BadRequest(mensaje.Respuesta["Mensaje"]);
          
        }

        [HttpGet("Logout")]
        public IActionResult Logout()
        {
            loginServicio.LogOut(User.Identity.IsAuthenticated);
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
            return Ok(usuarioServicio.BuscarPorCorreo(User.Identity.Name));
        }
    }
}
