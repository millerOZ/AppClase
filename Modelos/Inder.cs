using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppClase.Modelos
{
    public class Inder
    {
        public string Documento { set; get; }
        public string Nombre { set; get; }
        public string CantHorasReserva { set; get; }
        public string DiaSemana { set; get; }
        public string ReservaSinDescuento { set; get; }
        public string ValorDescuento { set; get; }
        public string ValorPagar { set; get; }
        public string Comando { set; get; }
        public string Error { set; get; }
    }
}