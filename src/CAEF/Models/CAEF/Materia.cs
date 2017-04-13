using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAEF.Models.CAEF
{
    public class Materia
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
    }
}
