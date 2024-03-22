using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace examen1ds31_RH.Models
{
    public class Clientes
    {
        
        [Required(ErrorMessage = "El campo esta vacio, No Puede Estar Vacio")]
        public string cod_clientes { get; set; }
        [Required]

        public string nombres { get; set; }
        [Required]

        public string apellidos { get; set; }
        [Required]

        public string dui { get; set; }
        [Required]

        public string direccion { get; set; }
        [Required]

        public string nit { get; set; }

        // contructore
        public Clientes()
        {

        }
        public Clientes(string cid, string nom, string ap, string dui, string di, string ni)
        {
            this.cod_clientes = cid;
            this.nombres = nom;
            this.apellidos = ap;
            this.dui = dui;
            this.direccion = di;
            this.nit = ni;
        }
    }
}

