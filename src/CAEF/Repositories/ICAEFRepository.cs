using System.Collections.Generic;
using CAEF.Models.Entities.CAEF;
using System.Threading.Tasks;

namespace CAEF.Repositories
{
    public interface ICAEFRepository
    {                
        IEnumerable<Carrera> ObtenerCarreras();
        IEnumerable<Materia> ObtenerMaterias();
        IEnumerable<SubtipoExamen> ObtenerSubtiposExamen();
        IEnumerable<TipoExamen> ObtenerTiposExamen();        
        int AgregarActaDocente(SolicitudDocente acta);
        void AgregarActaAdmin(SolicitudAdmin acta);
        void AgregarSolicitudAlumno(IEnumerable<SolicitudAlumno> solicitudes);                        
        bool AlumnoExiste(int Id);        
                
    }
}