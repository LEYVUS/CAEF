using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
