using System.Collections.Generic;
using System.Linq;
using System;
using CAEF.Repositorios;
using CAEF.Models.Entidades.UABC;


namespace CAEF.Repositorios.Implementacion
{
    public class UsuarioUABCRepositorioImpl : IUsuarioUABCRepositorio
    {


        public Usuario BuscarPorCorreo(string correo)
        {
            UsuariosUABC context = new UsuariosUABC();
            Usuario usuarioUABC;
            var usuario = from u in context.Usuarios
                          where u.Email == correo
                          select u;
            try
            {
                usuarioUABC = usuario.First<Usuario>();
            }
            catch (Exception ex)
            {
                return null;
            }

            return usuarioUABC;
        }
    }
}
