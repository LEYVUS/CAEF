using System;
using System.Collections.Generic;

namespace CAEF.Models.Entidades.DTO
{
    public class MensajeDTO
    {

        /// <summary>
        ///  
        /// </summary>
        public Dictionary<String, Object> Respuesta { get; set; }
        public bool estado;

        public MensajeDTO()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        public MensajeDTO(String mensaje,Object objeto)
        {
            Respuesta = new Dictionary<String, Object>();
            Respuesta.Add("Objeto", objeto);
            Respuesta.Add("Mensaje", mensaje);
        }

        public void SetMensaje(Object objeto,bool estado, String mensaje)
        {
            this.estado = estado;
            Respuesta.Add("Objeto", objeto);
            Respuesta.Add("Mensaje", mensaje);
        }


    }
}
