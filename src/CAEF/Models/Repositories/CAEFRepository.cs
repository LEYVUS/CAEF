using CAEF.Models.Contexts;
using CAEF.Models.Entities.CAEF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAEF.Models.Repositories
{
    public class CAEFRepository : ICAEFRepository
    {
        private CAEFContext _contextoCAEF;
        private UsuarioUABCContext _contextoUABC;

        public CAEFRepository(CAEFContext contextoCAEF, UsuarioUABCContext contextoUABC)
        {
            _contextoCAEF = contextoCAEF;
            _contextoUABC = contextoUABC;
        }


        public IEnumerable<Rol> ObtenerRoles()
        {
            return _contextoCAEF.Roles.ToList();
        }




        public IEnumerable<Carrera> ObtenerCarreras()
        {
            return _contextoCAEF.Carreras.ToList();
        }

        public IEnumerable<Materia> ObtenerMaterias()
        {
            return _contextoCAEF.Materias.ToList();
        }

        public IEnumerable<SubtipoExamen> ObtenerSubtiposExamen()
        {
            return _contextoCAEF.SubtiposExamen.ToList();
        }

        public IEnumerable<TipoExamen> ObtenerTiposExamen()
        {
            return _contextoCAEF.TiposExamen.ToList();
        }

        public int AgregarActaDocente(SolicitudDocente acta)
        {
            _contextoCAEF.SolicitudesDocente.Add(acta);
            _contextoCAEF.SaveChanges();
            return acta.Id;
        }

        public void AgregarActaAdmin(SolicitudAdmin acta)
        {
            _contextoCAEF.SolicitudesAdministrativo.Add(acta);
        }

        public void AgregarSolicitudAlumno(IEnumerable<SolicitudAlumno> solicitudes)
        {
            foreach (SolicitudAlumno solicitud in solicitudes)
            {
                solicitud.IdAlumno = solicitud.Alumno.Id;

                if (AlumnoExiste(solicitud.Alumno.Id))
                {
                    //_contextoCAEF.Alumnos.Attach(solicitud.Alumno);
                    _contextoCAEF.SolicitudesAlumno.Add(solicitud);
                }
                else
                {
                    _contextoCAEF.SolicitudesAlumno.Add(solicitud);
                }

            }
        }

        public bool AlumnoExiste(int Id)
        {
            var resultado = _contextoCAEF.Alumnos
                .Where(a => a.Id == Id)
                .FirstOrDefault();

            return resultado == null ? false : true;
        }
    }
}
