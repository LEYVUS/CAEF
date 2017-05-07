namespace CAEF.Models.Entidades.DTO
{
    public class SolicitudAlumnoDTO
    {
        public int IdSolicitud { get; set; }
        public int IdAlumno { get; set; }
        public AlumnoDTO Alumno { get; set; }
    }
}
