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
    }
}