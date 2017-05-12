using System.Collections.Generic;
using CAEF.Models.Entities.CAEF;
using System.Threading.Tasks;

namespace CAEF.Repositories
{
    public interface ICAEFRepository
    {                       
        IEnumerable<Materia> ObtenerMaterias();
                
    }
}