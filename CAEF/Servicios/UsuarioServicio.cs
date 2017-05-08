using CAEF.Models.Entidades;
using CAEF.Models.Entidades.DTO;
using CAEF.Repositorios.Implementacion;
using CAEF.Servicios.Componente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CAEF.Servicios
{
    public class UsuarioServicio
    {
        UsuarioRepositorioImpl usuarioRepositorio = new UsuarioRepositorioImpl(new EntidadesCAEF());
        UsuarioFIADRepositorioImpl usuarioFIADRepositorio = new UsuarioFIADRepositorioImpl();
        UsuarioUABCRepositorioImpl usuarioUABCepositorio = new UsuarioUABCRepositorioImpl();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        public void BorrarUsuario(int Id)
        {
            Usuario usuario = usuarioRepositorio.BuscarPorId(Id);
            if(usuario != null)
            {
                usuarioRepositorio.Borrar(usuario);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuario"></param>
        public void AgregarUsuario(UsuarioDTO usuario)
        {
            if (this.ValidarUsuario(usuario))
            {
                usuarioRepositorio.Agregar(TransferirEntidad.TransferirDatosUsuarioDTO(usuario));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<UsuarioDTO> BuscarTodos()
        {
            List<UsuarioDTO> usuariosDTO = new List<UsuarioDTO>();
            List<Usuario> usuarios = usuarioRepositorio.BuscarTodos();
            foreach(Usuario usuario in usuarios)
            {
                usuariosDTO.Add(TransferirDTO.TransferirUsuario(usuario));
            }
            return usuariosDTO;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public UsuarioDTO BuscarPorId(int Id)
        {
            return TransferirDTO.TransferirUsuario(usuarioRepositorio.BuscarPorId(Id));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuario"></param>
        public MensajeDTO Modificar(UsuarioDTO usuarioDTO)
        {
            if (this.ValidarUsuario(usuarioDTO))
            {
                if (usuarioFIADRepositorio.BuscarPorCorreo(usuarioDTO.Correo) != null && usuarioUABCepositorio.BuscarPorCorreo(usuarioDTO.Correo) != null)
                {
                    if (usuarioRepositorio.BuscarPorCorreo(usuarioDTO.Correo) == null)
                    {
                        Usuario usuario = usuarioRepositorio.BuscarPorId(usuarioDTO.Id);
                        usuario.Correo = usuarioDTO.Correo;
                        usuarioRepositorio.Modificar(usuario);
                        return MensajeComponente.mensaje("", true);
                    }
                    return MensajeComponente.mensaje("El correo ya existe en el sistema", false);
                }
                return MensajeComponente.mensaje("El correo no pertenece a UABC", false);
            }
            return MensajeComponente.mensaje("Los datos no son validos", false);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public bool ValidarUsuario(UsuarioDTO usuario)
        {
            if(usuario != null)
            {
                if(usuario.Correo == null)
                {
                    return false;
                }
                 if(usuario.Rol.Nombre != null)
                {
                    return false;
                }
            }
            return true;
        }

    }
}