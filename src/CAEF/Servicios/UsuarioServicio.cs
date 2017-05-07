using AutoMapper;
using CAEF.Models.Contexts;
using CAEF.Models.DTO;
using CAEF.Models.Entities.CAEF;
using CAEF.Repositorios.Implementacion;
using System;
using System.Collections.Generic;

namespace CAEF.Servicios
{


    public class UsuarioServicio
    {
        private UsuarioRepositorioImpl usuarioRepositorio;
        public UsuarioServicio()
        {
            usuarioRepositorio = new UsuarioRepositorioImpl(new EntidadesCAEF());
        }

        public List<UsuarioDTO> BuscarTodos()
        {
            return (List<UsuarioDTO>) Mapper.Map<IEnumerable<UsuarioDTO>>
                (usuarioRepositorio. BuscarTodos());
        }

        public UsuarioDTO BuscarPorId(int id)
        {
            return (UsuarioDTO)Mapper.Map<UsuarioDTO>
                (usuarioRepositorio.BuscarPorId(id));
        }

        public void Editar(UsuarioDTO usuario)
        {

        }
        
        public void Borrar(int id)
        {

        }

        public UsuarioDTO BuscarPorCorreo(String correo ) {
            return (UsuarioDTO)Mapper.Map<UsuarioDTO>
               (usuarioRepositorio.BuscarPorCorreo(correo));
        }

        public bool TienePermisos(String correo)
        {
            Usuario usuario = usuarioRepositorio.BuscarPorCorreo(correo);
            if (usuario.RolId == 1 || usuario.RolId == 2)
            {
                return true;
            }
            return false;
        }
    }
}
