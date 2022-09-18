using AppClase.Modelos;
using libComunes.CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppClase.Clases
{
    public class clsInder
    {
        public Inder _inder { get; set; }
        public bool Insertar()
        {
            string SQL = "INSERT into tblCliente (Documento,Nombre,CantHorasReserva,DiaSemana,ReservaSinDescuento,ValorDescuento,ValorPagar)" +
                "VALUES(@prDocumento,@prNombre,@prCantHorasReserva,@prDiaSemana,@prReservaSinDescuento,@prValorDescuento,@prValorPagar)";
            clsConexion oConexion = new clsConexion();
            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prDocumento", _inder.Documento);
            oConexion.AgregarParametro("@prNombre", _inder.Nombre);
            oConexion.AgregarParametro("@prCantHorasReserva", _inder.CantHorasReserva);
            oConexion.AgregarParametro("@prDiaSemana", _inder.DiaSemana);
            oConexion.AgregarParametro("@prReservaSinDescuento", _inder.ReservaSinDescuento);
            oConexion.AgregarParametro("@prValorDescuento", _inder.ValorDescuento);
            oConexion.AgregarParametro("@prValorPagar", _inder.ValorPagar);

            if (oConexion.EjecutarSentencia())
            {
                return true;
            }
            else
            {
                _inder.Error = oConexion.Error;
                return false;
            }

        }
    }
}