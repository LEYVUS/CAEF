using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System;

namespace CAEF.Repositorios.RepositorioGenericos
{
    /// <summary>
    /// Repositorio Generico 
    /// </summary>
    /// <typeparam name="Entity"></typeparam>
    public abstract class RepostorioCRUD<Entity> : IRepositorioGenerico<Entity> where Entity : class  
    {
        protected DbContext context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public RepostorioCRUD(DbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Busca todo los registro
        /// </summary>
        /// <returns></returns>
        public List<Entity> BuscarTodos()
        {
            return context.Set<Entity>().ToList<Entity>();
        }

        /// <summary>
        /// Busca los registros por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Entity BuscarPorId(int id)
        {
            return context.Set<Entity>().Find(id);
        }

        /// <summary>
        /// Agregar un nuevo registro
        /// </summary>
        /// <param name="entity"></param>
        public void Agregar(Entity entity)
        {
            context.Set<Entity>().Add(entity);
            context.SaveChanges();
        }

        /// <summary>
        /// Borra un registro
        /// </summary>
        /// <param name="entity"></param>
        public void Borrar(Entity entity)
        {
            context.Set<Entity>().Remove(entity);
            context.SaveChanges();
        }

        /// <summary>
        /// Modifica un registro
        /// </summary>
        /// <param name="entity"></param>
        public abstract void Modificar(Entity entity);


    }
}