using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace examen1ds31_RH.Models
{
    public class Productos
    {
        //Producto       cod_prod=pid | username=descripcion dess | pass=existencia  paw-->ex varc-->int | nivrl=garantia ni=ga| nombre nnnn nombre=no
        [Required(ErrorMessage = "El campo esta vacio, No Puede Estar Vacio")]
        public int cod_prod { get; set; }
        [Required]

        public string descripcion { get; set; }
        [Required]

        public int existencia { get; set; }
        [Required]

        public int Precio_unit { get; set; }
        [Required]

        public int garantia { get; set; }
        [Required]

        public string nombre { get; set; }

        // contructore
        public Productos()
        {

        }
        public Productos(int pid, string dess, int pu, int ex, int ga, string no)
        {
            this.cod_prod = pid;
            this.descripcion = dess;
            this.Precio_unit = pu;
            this.existencia = ex;
            this.garantia = ga;
            this.nombre = no;
        }
    }
}
