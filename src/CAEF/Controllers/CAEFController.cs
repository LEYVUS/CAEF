using AutoMapper;
using CAEF.Models.Contexts;
using CAEF.Models.Entities.CAEF;
using CAEF.Models.Repositories;
using CAEF.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAEF.Controllers
{
    public class CAEFController : Controller
    {
        private ICAEFRepository _repositorioCAEF;
        private IFIADRepository _repositorioFIAD;

        public CAEFController(ICAEFRepository repositorioCAEF, IFIADRepository repositorioFIAD)
        {
            _repositorioCAEF = repositorioCAEF;
            _repositorioFIAD = repositorioFIAD;
        }

        [Authorize]
        [HttpGet("Usuarios")]
        public IActionResult ListarUsuarios()
        {
            var usuarioActual = _repositorioCAEF.UsuarioAutenticado(User.Identity.Name);
            var usuarios = _repositorioCAEF.ObtenerUsuarios();
            var usuariosDTO = Mapper.Map<IEnumerable<UsuarioDTO>>(usuarios);

            if (usuarioActual.RolId == 1)
            {
                return View(usuariosDTO);
            }
            else
            {
                return Redirect("/");
            }
        }

        [Authorize]
        [HttpGet("CAEF/Usuarios")]
        public IActionResult VerUsuarios()
        {
            var usuarios = _repositorioCAEF.ObtenerUsuarios();
            var usuariosDTO = Mapper.Map<IEnumerable<UsuarioDTO>>(usuarios);
            return Ok(usuariosDTO);
        }

        [Authorize]
        [HttpGet("CAEF/Roles")]
        public IActionResult VerRoles()
        {
            var roles = _repositorioCAEF.ObtenerRoles();
            return Ok(roles);
        }

        [Authorize]
        [HttpPost("CAEF/Editar")]
        public async Task<IActionResult> EditarUsuarios([FromBody] UsuarioDTO usuario)
        {
            _repositorioCAEF.EditarUsuario(Mapper.Map<Usuario>(usuario));
            if (await _repositorioCAEF.GuardarCambios())
            {
                return Ok("El usuario fue modificado exitosamente");
            }
            return BadRequest("Ocurrió un error al modificar usuario");
        }

        [Authorize]
        [HttpPost("CAEF/Borrar")]
        public async Task<IActionResult> BorrarUsuarios([FromBody] UsuarioDTO usuario)
        {
            _repositorioCAEF.BorrarUsuario(Mapper.Map<Usuario>(usuario));
            if (await _repositorioCAEF.GuardarCambios())
            {
                return Ok("Se ha eliminado el usuario.");
            }
            return BadRequest("Error al borrar el usuario");
        }

        [Authorize]
        [HttpGet("AgregarUsuario")]
        public IActionResult AgregarUsuario()
        {
            var usuarioActual = _repositorioCAEF.UsuarioAutenticado(User.Identity.Name);
            if(usuarioActual.RolId == 1)
            {
                return View();
            }
            else
            {
                return Redirect("/");
            }
        }

        [Authorize]
        [HttpPost("CAEF/Agregar")]
        public async Task<IActionResult> AgregarUsuario([FromBody] UsuarioDTO usuario)
        {
            var usuarioDuplicado = _repositorioCAEF.UsuarioDuplicado(usuario.Correo);
            var usuarioExisteFIAD = _repositorioFIAD.UsuarioExiste(usuario.Correo);
            var usuarioExisteUABC = _repositorioCAEF.UsuarioExiste(usuario.Correo);

            if (!usuarioExisteUABC) return BadRequest("El usuario no es miembro de UABC.");
            if (!usuarioExisteFIAD) return BadRequest("El usuario no es miembro de FIAD.");
            if (usuarioDuplicado) return BadRequest("El usuario ya está registrado en el sistema.");

            _repositorioCAEF.AgregarUsuario(Mapper.Map<Usuario>(usuario));

            if (await _repositorioCAEF.GuardarCambios())
            {
                return Ok("Se agregó el usuario correctamente.");
            }
            else
            {
                return BadRequest("Ocurrió un error al agregar usuario.");
            }
        }
    }
}
