namespace CAEF.Models.Entidades.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RolDTO
    {
        public RolDTO()
        {

        }
        /// <summary>
        /// Constructor de Rol
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="descripcion"></param>
        public RolDTO(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
           
        }

        public int Id { get; set; }

        public string Nombre { get; set; }

    

    }
}
