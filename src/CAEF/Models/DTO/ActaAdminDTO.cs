﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAEF.Models.DTO
{
    public class ActaAdminDTO
    {
        [Required]
        public int IdSolicitud { get; set; }
        [Required]
        public string ClaveUnidad { get; set; }
        [Required]
        public string UnidadAcademica { get; set; }
        [Required]
        public DateTime FechaAceptacion { get; set; }
        [Required]
        public int NumeroAlumnos { get; set; }
        [Required]
        public string CalificacionLetra { get; set; }
        [Required]
        public string CicloEscolar { get; set; }
        [Required]
        public int IdSubtipoExamen { get; set; }
        [Required]
        public string PlanEstudios { get; set; }
        [Required]
        public string EtapaSemestre { get; set; }
        [Required]
        public string Comentario { get; set; }
        [Required]
        public string URLDocumento { get; set; }
    }
}
