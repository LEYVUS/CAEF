﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CAEF.Models.Contexts;
using CAEF.Models.Entities.CAEF;

namespace CAEF.Services
{
    public class SolicitudAdministrativaServices
    {
        private CAEFContext _contextoCAEF;

        public SolicitudAdministrativaServices(CAEFContext contextoCAEF)
        {
            _contextoCAEF = contextoCAEF;
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
