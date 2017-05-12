using System.Collections.Generic;

namespace CAEF.Models.Repositories
{
    public interface IRepositorioGenerico<Entidad> where Entidad : class
    {
        void Agregar(Entidad entidad);
        void Borrar(Entidad entidad);
        void Modificar(Entidad entidad);
        void BuscarID(int id);
        List<Entidad> BuscarTodos();
    }
}
