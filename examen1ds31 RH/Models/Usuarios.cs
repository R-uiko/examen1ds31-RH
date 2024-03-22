using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using System.ComponentModel.DataAnnotations;

namespace examen1ds31_RH.Models
{
    public class Usuarios
    {
        //atributos para cada campo de la tabla
        [Required(ErrorMessage = "El campo esta vacio, No Puede Estar Vacio")]
        public int cod_user { get; set; }
        [Required]

        public string nombre_usuario { get; set; }
        [Required]

        public string contra { get; set; }
        [Required]

        public string nivel_usuario { get; set; }
        // contructore
        public Usuarios()
        {

        }
        public Usuarios(int id, string us, string pa, string ni)
        {
            this.cod_user = id;
            this.nombre_usuario = us;
            this.contra = pa;
            this.nivel_usuario = ni;
        }
    }
}
