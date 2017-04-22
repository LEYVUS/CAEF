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

namespace CAEF.Controllers.API
{
    public class CAEFController : Controller
    {
        private ICAEFRepository _repositorioCAEF;

        public CAEFController(ICAEFRepository repositorioCAEF)
        {
            _repositorioCAEF = repositorioCAEF;
        }

        [Authorize]
        [HttpGet("Usuarios")]
        public IActionResult ListarUsuarios()
        {
            var usuarios = _repositorioCAEF.ObtenerUsuarios();
            var usuariosDTO = Mapper.Map<IEnumerable<UsuarioDTO>>(usuarios);
            return View(usuariosDTO);
        }

        [Authorize]
        [HttpGet("API/Usuarios")]
        public IActionResult VerUsuarios()
        {
            var usuarios = _repositorioCAEF.ObtenerUsuarios();
            var usuariosDTO = Mapper.Map<IEnumerable<UsuarioDTO>>(usuarios);
            return Ok(usuariosDTO);
        }

        [Authorize]
        [HttpGet("API/Roles")]
        public IActionResult VerRoles()
        {
            var roles = _repositorioCAEF.ObtenerRoles();
            return Ok(roles);
        }

        [Authorize]
        [HttpPost("API/Editar")]
        public async Task<IActionResult> EditarUsuarios([FromBody] UsuarioDTO usuario)
        {
            _repositorioCAEF.EditarUsuario(Mapper.Map<Usuario>(usuario));
            if(await _repositorioCAEF.GuardarCambios())
            {
                return Ok();
            }
            return BadRequest("Error al editar el usuario");
        }

        [Authorize]
        [HttpPost("API/Borrar")]
        public async Task<IActionResult> BorrarUsuarios([FromBody] UsuarioDTO usuario)
        {
            _repositorioCAEF.BorrarUsuario(Mapper.Map<Usuario>(usuario));
            if (await _repositorioCAEF.GuardarCambios())
            {
                return Ok();
            }
            return BadRequest("Error al borrar el usuario");
        }

        [Authorize]
        [HttpGet("AgregarUsuario")]
        public IActionResult AgregarUsuario()
        {
            var roles = _repositorioCAEF.ObtenerRoles();
            ViewBag.Roles = roles;
            return View();
        }

        [Authorize]
        [HttpPost("AgregarUsuario")]
        public async Task<IActionResult> AgregarUsuario(UsuarioDTO usuario)
        {
            var roles = _repositorioCAEF.ObtenerRoles();
            ViewBag.Roles = roles;

            var usuarioExiste = _repositorioCAEF.UsuarioExiste(Mapper.Map<Usuario>(usuario));
            var usuarioDuplicado = _repositorioCAEF.UsuarioDuplicado(Mapper.Map<Usuario>(usuario));

            if (!usuarioExiste) ModelState.AddModelError("", "El usuario no es miembro de UABC");
            if (usuarioDuplicado) ModelState.AddModelError("", "El usuario ya existe en el sistema");
            if (ModelState.IsValid)
            {
                _repositorioCAEF.AgregarUsuario(Mapper.Map<Usuario>(usuario));

                if(await _repositorioCAEF.GuardarCambios())
                {
                    ViewBag.Mensaje = "Se agregó el usuario";
                    ModelState.Clear();
                    return View();
                    //return Created($"Usuario/{usuario.Id}", usuario);
                }
            }
            return View();
        }
    }
}
