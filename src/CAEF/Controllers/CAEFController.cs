using AutoMapper;
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
using CAEF.Services;
using CAEF.Repositories;

namespace CAEF.Controllers
{
    public class CAEFController : Controller
    {        
        private IFIADRepository _repositorioFIAD;
        private CarreraRepository _repositorioCarrera;
        private MateriaRepository _repositorioMateria;

        private UsuarioServices _servicioUsuario;
        private RolServices _serviocioRol;
        private SolicitudAdministrativaServices _servicioSolicitud;        

        public CAEFController(IFIADRepository repositorioFIAD,
            UsuarioServices repositorioUsuario, RolServices servicioRol,
            SolicitudAdministrativaServices servicioSolicitud, CarreraRepository repositorioCarrera,
            MateriaRepository repositorioMateria)
        {            
            _repositorioFIAD = repositorioFIAD;
            _servicioUsuario = repositorioUsuario;
            _serviocioRol = servicioRol;
            _servicioSolicitud = servicioSolicitud;
            _repositorioCarrera = repositorioCarrera;
            _repositorioMateria = repositorioMateria;
        }

        [Authorize]
        [HttpGet("Acta")]
        public IActionResult SolicitarActaAdmin()
        {
            var usuarioActual = _servicioUsuario.UsuarioAutenticado(User.Identity.Name);

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
            var roles = _serviocioRol.ObtenerRoles();
            return Ok(roles);
        }

        [Authorize]
        [HttpGet("CAEF/Carreras")]
        public IActionResult VerCarreras()
        {
            var carreras = _repositorioCarrera.BuscarTodos();
            return Ok(carreras);
        }

        [Authorize]
        [HttpGet("CAEF/Materias")]
        public IActionResult VerMaterias()
        {
            var materias = _repositorioMateria.BuscarTodos();
            return Ok(materias);
        }

        [Authorize]
        [HttpGet("CAEF/Subtipos")]
        public IActionResult VerSubtipos()
        {
            var subtipos = _servicioSolicitud.ObtenerSubtiposExamen();
            return Ok(subtipos);
        }

        [Authorize]
        [HttpGet("CAEF/Tipos")]
        public IActionResult VerTipos()
        {
            var tipos = _servicioSolicitud.ObtenerTiposExamen();
            return Ok(tipos);
        }

        [Authorize]
        [HttpPost("CAEF/AgregarActaDocente")]
        public async Task<IActionResult> AgregarActaDocente([FromBody] ActaDocenteDTO acta)
        {
            var id = _servicioSolicitud.AgregarActaDocente(Mapper.Map<SolicitudDocente>(acta));

            if (id != 0)
            {
                await _servicioUsuario.GuardarCambios();
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
                _servicioSolicitud.AgregarSolicitudAlumno(Mapper.Map<IEnumerable<SolicitudAlumno>>(solicitud));

                if (await _servicioUsuario.GuardarCambios())
                {
                    return Ok("Se agregó la solicitud correctamente.");
                }
            }

            return BadRequest("Ocurrió un error al agregar solicitud.");

        }
    }
}
