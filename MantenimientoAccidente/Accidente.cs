using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MantenimientoAccidente
{
    public class Accidente
    {
        public int id { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [StringLength(30, ErrorMessage = "El texto sobrepasa la longitud de 30 caracteres")]
        public string nombre { get; set; }
        
        [Required(ErrorMessage = "El campo es requerido")]
        [StringLength(30, ErrorMessage = "El texto sobrepasa la longitud de 30 caracteres")]
        public string apellido{ get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [Range(0, 120)]
        public int edad { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [Range(0, 1)]
        public int sexo { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        public string accidente { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [Range(0, 1)]
        public int estado { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [StringLength(100, ErrorMessage = "El texto sobrepasa la longitud de 100 caracteres")]
        public string foto { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [StringLength(4, ErrorMessage = "El texto sobrepasa la longitud de 4 caracteres")]
        public string lesion { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [StringLength(250, ErrorMessage = "El texto sobrepasa la longitud de 250 caracteres")]
        public string direccion { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [StringLength(500, ErrorMessage = "El texto sobrepasa la longitud de 500 caracteres")]
        public string detalle { get; set; }
    }
}