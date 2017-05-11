using AutoMapper;
using CAEF.Models.Contexts;
using CAEF.Models.DTO;
using CAEF.Models.Entities.CAEF;
using CAEF.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CAEF.Controllers
{
    public class UsuarioController : Controller
    {        
        private IFIADRepository _repositorioFIAD;
        private IUsuarioRepository _repositorioUsuario;        

        public UsuarioController(IFIADRepository repositorioFIAD, IUsuarioRepository repositorioUsuario)
        {            
            _repositorioFIAD = repositorioFIAD;
            _repositorioUsuario = repositorioUsuario;
        }

        [Authorize]
        [HttpGet("Usuarios")]
        public IActionResult ListarUsuarios()
        {
            var usuarioActual = _repositorioUsuario.UsuarioAutenticado(User.Identity.Name);
            var usuarios = _repositorioUsuario.ObtenerUsuarios();
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
        [HttpGet("Usuarios/Usuarios")]
        public IActionResult VerUsuarios()
        {
            var usuarios = _repositorioUsuario.ObtenerUsuarios();
            var usuariosDTO = Mapper.Map<IEnumerable<UsuarioDTO>>(usuarios);
            return Ok(usuariosDTO);
        }

        [Authorize]
        [HttpPost("Usuarios/Editar")]
        public async Task<IActionResult> EditarUsuarios([FromBody] UsuarioDTO usuario)
        {
            _repositorioUsuario.EditarUsuario(Mapper.Map<Usuario>(usuario));
            if (await _repositorioUsuario.GuardarCambios())
            {
                return Ok("El usuario fue modificado exitosamente");
            }
            return BadRequest("Ocurrió un error al modificar usuario");
        }

        [Authorize]
        [HttpPost("Usuarios/Borrar")]
        public async Task<IActionResult> BorrarUsuarios([FromBody] UsuarioDTO usuario)
        {
            _repositorioUsuario.BorrarUsuario(Mapper.Map<Usuario>(usuario));
            if (await _repositorioUsuario.GuardarCambios())
            {
                return Ok("Se ha eliminado el usuario.");
            }
            return BadRequest("Error al borrar el usuario");
        }

        [Authorize]
        [HttpGet("AgregarUsuario")]
        public IActionResult AgregarUsuario()
        {
            var usuarioActual = _repositorioUsuario.UsuarioAutenticado(User.Identity.Name);
            if (usuarioActual.RolId == 1)
            {
                return View();
            }
            else
            {
                return Redirect("/");
            }
        }

        [Authorize]
        [HttpPost("Usuarios/Agregar")]
        public async Task<IActionResult> AgregarUsuario([FromBody] UsuarioDTO usuario)
        {
            var usuarioDuplicado = _repositorioUsuario.UsuarioDuplicado(usuario.Correo);
            var usuarioExisteFIAD = _repositorioFIAD.UsuarioExiste(usuario.Correo);
            var usuarioExisteUABC = _repositorioUsuario.UsuarioExiste(usuario.Correo);

            if (!usuarioExisteUABC) return BadRequest("El usuario no es miembro de UABC.");
            if (!usuarioExisteFIAD) return BadRequest("El usuario no es miembro de FIAD.");
            if (usuarioDuplicado) return BadRequest("El usuario ya está registrado en el sistema.");

            _repositorioUsuario.AgregarUsuario(Mapper.Map<Usuario>(usuario));

            if (await _repositorioUsuario.GuardarCambios())
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
