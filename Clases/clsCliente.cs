using AppClase.Modelos;
using libComunes.CapaDatos;
namespace AppClase.Clases
{
    public class clsCliente
    {
        public Cliente _cliente { get; set; }
        public bool Insertar()
        {
            string SQL = "INSERT into tblCliente (Documento,Nombre,PrimerApellido,SegundoApellido,Direccion,Telefono,Email,FechaNacimiento)" +
                "VALUES(@prDocumento,@prNombre,@prPrimerApellido,@prSegundoApellido,@prDireccion,@prTelefono,@prEmail,@prFechaNacimiento)";
            clsConexion oConexion = new clsConexion();
            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prDocumento", _cliente.Documento);
            oConexion.AgregarParametro("@prNombre", _cliente.Nombre);
            oConexion.AgregarParametro("@prPrimerApellido", _cliente.PrimerApellido);
            oConexion.AgregarParametro("@prSegundoApellido", _cliente.SegundoApellido);
            oConexion.AgregarParametro("@prDireccion", _cliente.Direccion);
            oConexion.AgregarParametro("@prTelefono", _cliente.Telefono);
            oConexion.AgregarParametro("@prEmail", _cliente.Email);
            oConexion.AgregarParametro("@prFechaNacimiento", _cliente.FechaNacimiento);

            if (oConexion.EjecutarSentencia())
            {
                return true;
            }
            else
            {
                _cliente.Error = oConexion.Error;
                return false;
            }

        }
        public bool Actualizar()
        {
            string SQL = "UPDATE  tblCliente " +
                         "SET     Nombre = @prNombre, " +
                                 "PrimerApellido = @prPrimerApellido, " +
                                 "SegundoApellido = @prSegundoApellido, " +
                                 "Direccion = @prDireccion, " +
                                 "Telefono = @prTelefono, " +
                                 "Email = @prEmail, " +
                                 "FechaNacimiento = @prFechaNacimiento " +
                "WHERE           Documento = @prDocumento";
            clsConexion oConexion = new clsConexion();
            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prDocumento", _cliente.Documento);
            oConexion.AgregarParametro("@prNombre", _cliente.Nombre);
            oConexion.AgregarParametro("@prPrimerApellido", _cliente.PrimerApellido);
            oConexion.AgregarParametro("@prSegundoApellido", _cliente.SegundoApellido);
            oConexion.AgregarParametro("@prDireccion", _cliente.Direccion);
            oConexion.AgregarParametro("@prTelefono", _cliente.Telefono);
            oConexion.AgregarParametro("@prEmail", _cliente.Email);
            oConexion.AgregarParametro("@prFechaNacimiento", _cliente.FechaNacimiento);

            if (oConexion.EjecutarSentencia())
            {
                return true;
            }
            else
            {
                _cliente.Error = oConexion.Error;
                return false;
            }

        }

        public bool Eliminar()
        {
            string SQL = "DELETE from tblCliente " +
                         "WHERE      Documento = @prDocumento";
            clsConexion oConexion = new clsConexion();
            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prDocumento", _cliente.Documento);

            if (oConexion.EjecutarSentencia())
            {
                return true;
            }
            else
            {
                _cliente.Error = oConexion.Error;
                return false;
            }
        }
        public bool Consultar()
        {
            string SQL = "SELECT  Nombre, PrimerApellido, SegundoApellido, Direccion, Telefono, Email, FechaNacimiento " +
                         "FROM   tblCliente " +
                         "WHERE  Documento = @prDocumento";
            clsConexion oConexion = new clsConexion();
            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prDocumento", _cliente.Documento);

            if (oConexion.Consultar())
            {
                if (oConexion.Reader.HasRows)
                {
                    oConexion.Reader.Read();
                    _cliente.Nombre = oConexion.Reader.GetString(0);
                    _cliente.PrimerApellido = oConexion.Reader.GetString(1);
                    _cliente.SegundoApellido = oConexion.Reader.GetString(2);
                    _cliente.Direccion = oConexion.Reader.GetString(3);
                    _cliente.Telefono = oConexion.Reader.GetString(4);
                    _cliente.Email = oConexion.Reader.GetString(5);
                    _cliente.FechaNacimiento = oConexion.Reader.GetDateTime(6);
                    return true;
                }
                else
                {
                    _cliente.Error = "No hay datos para el cliente";
                    return false;
                }
               
            }
            else
            {
                _cliente.Error = oConexion.Error;
                return false;
            }
        }
    }
}