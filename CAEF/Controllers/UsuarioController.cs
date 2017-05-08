using CAEF.Models.Entidades.DTO;
using CAEF.Servicios;
using System;
using System.Web.Http;

namespace SSUABC.Controllers
{
    /// <summary>
    /// Controlador de Usuario
    /// </summary>
    public class UsuarioController : ApiController
    {
        UsuarioServicio servicioUsuario = new UsuarioServicio();
       
       /// <summary>
       /// En lista Usuarios
       /// </summary>
       /// <returns>Muestra lista de Usuarios</returns>
        [Route("CAEF/Usuario")]
        [HttpGet]
        public IHttpActionResult ListarUsuarios()
        {
            return Ok(servicioUsuario.BuscarTodos());
        }
        
        /// <summary>
        /// Modifica un usuario
        /// </summary>
        /// <param name="usuarioDTO"></param>
        /// <returns>Retorna un mensaje que fue satisfacctoria la modificacion o fue un error</returns>
        [Route("CAEF/Usuario")]
        [HttpPut]
        public IHttpActionResult ModificarUsuario([FromBody] UsuarioDTO usuarioDTO)
        {
            MensajeDTO mensaje = servicioUsuario.Modificar(usuarioDTO);
            if ((bool)mensaje.Respuesta["Entidad"])
            {
                return Ok(mensaje);
            }
            return InternalServerError(new Exception((string)mensaje.Respuesta["Mensaje"]));
        }

        /// <summary>
        /// Busca un Usuario por Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Muesstra el Usuario</returns>
        [Route("SS/Usuario/{id:int}")]
        [HttpGet]
        public IHttpActionResult BuscarUsuarioPorId(int Id)
        {
            UsuarioDTO usuarioDTO = servicioUsuario.BuscarPorId(Id);
            if (usuarioDTO != null)
            {
                return Ok(usuarioDTO);
            }
            return NotFound();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [Route("CAEF/Usuario")]
        [HttpPost]
        public IHttpActionResult AgregarUsuario([FromBody]UsuarioDTO usuario)
        {
            servicioUsuario.AgregarUsuario(usuario);
            return Ok();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [Route("CAEF/Usuario")]
        [HttpDelete]
        public IHttpActionResult BorrarUsuario([FromBody]UsuarioDTO usuario)
        {

        }
    }
}