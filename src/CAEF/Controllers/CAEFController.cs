﻿using AutoMapper;
using CAEF.Models.Contexts;
using CAEF.Models.DTO;
using CAEF.Models.Entities.CAEF;
using CAEF.Repositories;
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
        private IUsuarioRepository _repositorioUsuario;

        public CAEFController(ICAEFRepository repositorioCAEF, IFIADRepository repositorioFIAD, IUsuarioRepository repositorioUsuario)
        {
            _repositorioCAEF = repositorioCAEF;
            _repositorioFIAD = repositorioFIAD;
            _repositorioUsuario = repositorioUsuario;
        }

        [Authorize]
        [HttpGet("Acta")]
        public IActionResult SolicitarActaAdmin()
        {
            var usuarioActual = _repositorioUsuario.UsuarioAutenticado(User.Identity.Name);

            if (usuarioActual.RolId == 1)
            {
                return View();
            }
            else
            {
                return View("SolicitarActaDocente");
            }
        }

        [Authorize]
        [HttpGet("CAEF/Roles")]
        public IActionResult VerRoles()
        {
            var roles = _repositorioCAEF.ObtenerRoles();
            return Ok(roles);
        }

        [Authorize]
        [HttpGet("CAEF/Carreras")]
        public IActionResult VerCarreras()
        {
            var carreras = _repositorioCAEF.ObtenerCarreras();
            return Ok(carreras);
        }

        [Authorize]
        [HttpGet("CAEF/Materias")]
        public IActionResult VerMaterias()
        {
            var materias = _repositorioCAEF.ObtenerMaterias();
            return Ok(materias);
        }

        [Authorize]
        [HttpGet("CAEF/Subtipos")]
        public IActionResult VerSubtipos()
        {
            var subtipos = _repositorioCAEF.ObtenerSubtiposExamen();
            return Ok(subtipos);
        }

        [Authorize]
        [HttpGet("CAEF/Tipos")]
        public IActionResult VerTipos()
        {
            var tipos = _repositorioCAEF.ObtenerTiposExamen();
            return Ok(tipos);
        }

        [Authorize]
        [HttpPost("CAEF/AgregarActaDocente")]
        public async Task<IActionResult> AgregarActaDocente([FromBody] ActaDocenteDTO acta)
        {
            var id = _repositorioCAEF.AgregarActaDocente(Mapper.Map<SolicitudDocente>(acta));

            if (id != 0)
            {
                await _repositorioUsuario.GuardarCambios();
                return Ok(id);
            }
            else
            {
                return BadRequest("Ocurrió un error al agregar solicitud.");
            }
        }

        [Authorize]
        [HttpPost("CAEF/AgregarSolicitudAlumno")]
        public async Task<IActionResult> AgregarSolicitudAlumno([FromBody] IEnumerable<SolicitudAlumnoDTO> solicitud)
        {
            if(solicitud != null)
            {
                _repositorioCAEF.AgregarSolicitudAlumno(Mapper.Map<IEnumerable<SolicitudAlumno>>(solicitud));

                if (await _repositorioUsuario.GuardarCambios())
                {
                    return Ok("Se agregó la solicitud correctamente.");
                }
            }

            return BadRequest("Ocurrió un error al agregar solicitud.");

        }
    }
}