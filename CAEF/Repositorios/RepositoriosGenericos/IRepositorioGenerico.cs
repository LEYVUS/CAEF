using System.Collections.Generic;

namespace CAEF.Repositorios.RepositorioGenericos
{
    /// <summary>
    /// Repositorio Generico del las funciones Agregar, Borrar, Modificar
    /// </summary>
    /// <typeparam name="Entity"></typeparam>
    interface IRepositorioGenerico<Entidad> where Entidad : class
    {
        List<Entidad> BuscarTodos();
        Entidad BuscarPorId(int id);
        void Agregar(Entidad entidad);
        void Borrar(Entidad entidad);
        void Modificar(Entidad entidad);
    }
}
