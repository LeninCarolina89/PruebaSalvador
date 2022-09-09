using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebPrueba.Models
{
    public class Empleado
    {
        public int ID { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }

        public string Correo { get; set; }

        public string Foto { get; set; }
        public string Fecha { get; set; }
       
    }
}