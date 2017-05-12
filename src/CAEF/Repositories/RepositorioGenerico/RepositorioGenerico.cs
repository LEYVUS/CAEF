using System;
using System.Collections.Generic;
using CAEF.Models.Contexts;


namespace CAEF.Models.Repositories.RepositorioGenerico
{
    public abstract class RepositorioGenerico<Entity> : IRepositorioGenerico<Entity> where Entity : class
    {
        private CAEFContext _contextoCAEF;

        public RepositorioGenerico(CAEFContext contextoCAEF)
        {
            _contextoCAEF = contextoCAEF;
        }
        public void Agregar(Entity entidad)
        {
            _contextoCAEF.Add(entidad);
        }

        public void Borrar(Entity entidad)
        {
            _contextoCAEF.Remove(entidad);
        }

        public void BuscarID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Entity> BuscarTodos()
        {
            //return _contextoCAEF.Usuarios
            //  .Include(u => u.Rol)
            //.ToList();
            return null;// _contextoCAEF.Set<Entity>().ToList();
        }

        public void Modificar(Entity entidad)
        {
            _contextoCAEF.Set<Entity>();
        }
    }
}
