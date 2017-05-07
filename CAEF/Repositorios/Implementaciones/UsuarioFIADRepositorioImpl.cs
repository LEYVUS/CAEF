using CAEF.Models.Entidades.FIAD;
using CAEF.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CAEF.Repositorios.Implementacion
{
    public class UsuarioFIADRepositorioImpl : IUsuarioFIADRepositorio
    {

        public Usuario BuscarPorCorreo(string correo)
        {
            UsuariosFIAD context = new UsuariosFIAD();
            Usuario usuarioFIAD;
            var usuario = from u in context.Usuarios
                          where u.Email == correo
                          select u;
            try
            {
                usuarioFIAD = usuario.First<Usuario>();
            }
            catch (Exception ex)
            {
                return null;
            }

            return usuarioFIAD;
        }
    }
}
