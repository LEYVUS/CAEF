

using CAEF.Models.Entidades.DTO;
using System;

namespace CAEF.Servicios.Componente
{   /// <summary>
    /// 
    /// </summary>
    public static class MensajeComponente
    {

       /// <summary>
       /// Agrega Entidad y Mensaje al mensajeEstado
       /// </summary>
       /// <param name="mensaje"></param>
       /// <param name="entidad"></param>
       /// <returns>Devuelve un mensaje de Estado</returns>
        public static MensajeDTO mensaje(string mensaje, Object entidad)
        {
            MensajeDTO mensajeEstado = new MensajeDTO();
            mensajeEstado.Respuesta.Add("Entidad", entidad);
            mensajeEstado.Respuesta.Add("Mensaje", mensaje);
            return mensajeEstado;
        }
    }
}