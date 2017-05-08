using CAEF.Models.Entidades.DTO;
using CAEF.Servicios;
using System.Web.Http;

namespace CAEF.Controllers
{
    /// <summary>
    /// Controlador de Sesion
    /// </summary>
    public class SesionController : ApiController
    {
        private SesionServicio sesionServicio = new SesionServicio();

        /// <summary>
        /// Recibe los datos del usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns>Devuelve los datos del usuario</returns>
        [Route("CAEF/Login")]
        [HttpPost]
        public IHttpActionResult Index(UsuarioDTO usuario)
        {
            return Ok(sesionServicio.InicioSesion(usuario));
        }
    }
}