using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppClase.Modelos
{
    public class Cliente
    {
        public string Documento { set; get; }
        public string Nombre { set; get; }
        public string PrimerApellido { set; get; }
        public string SegundoApellido { set; get; }
        public DateTime? FechaNacimiento { set; get; } = DateTime.Now;
        public string Email { set; get; }
        public string Direccion { set; get; }
        public string Telefono { set; get; }
        public string Error { set; get; }
        public string Comando { set; get; }
    }
}