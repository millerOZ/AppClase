using AppClase.Clases;
using AppClase.Modelos;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Web;

namespace AppClase.Controladores
{
    public class ControladorCliente : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                string DatosCliente;
                StreamReader reader = new StreamReader(context.Request.InputStream);
                DatosCliente = reader.ReadToEnd();
                //Vamos a convertir el texto que está en la variable DatosCliente, a una clase: del modelo Cliente
                //Se hace con las clases de Newtonsoft, utilizar la clase jsonconvert
                Cliente _Cliente = JsonConvert.DeserializeObject<Cliente>(DatosCliente);
                //context.Response.Write("Hello " + _Cliente.Nombre + " " + _Cliente.PrimerApellido + " " + _Cliente.SegundoApellido);


                switch (_Cliente.Comando.ToUpper())
                {
                    case "INSERTAR":
                        context.Response.Write(Insertar(_Cliente));
                        break;
                    case "ACTUALIZAR":
                        context.Response.Write(Actualizar(_Cliente));
                        break;
                    case "ELIMINAR":
                        context.Response.Write(Eliminar(_Cliente));
                        break;
                    case "CONSULTAR":
                        context.Response.Write(Consultar(_Cliente));
                        break;
                }


            }
            catch (Exception ex)
            {
                context.Response.Write(ex.ToString());
            }




        }
        private string Insertar(Cliente _cliente)
        {
            clsCliente oCliente = new clsCliente();
            oCliente._cliente = _cliente;
            if (oCliente.Insertar())
            {
                return "Se insertó en la base de datos";
            }
            else
            {
                return oCliente._cliente.Error;
            }
        }
        private string Actualizar(Cliente _cliente)
        {
            clsCliente oCliente = new clsCliente();
            oCliente._cliente = _cliente;
            if (oCliente.Actualizar())
            {
                return "Se actualizo en la base de datos";
            }
            else
            {
                return oCliente._cliente.Error;
            }
        }
        private string Eliminar(Cliente _cliente)
        {
            clsCliente oCliente = new clsCliente();
            oCliente._cliente = _cliente;
            if (oCliente.Eliminar())
            {
                return "Se elimino el cliente en la base de datos";
            }
            else
            {
                return oCliente._cliente.Error;
            }
        }
        private string Consultar(Cliente _cliente)
        {
            clsCliente oCliente = new clsCliente();
            oCliente._cliente = _cliente;
            if (oCliente.Consultar())
            {
                return JsonConvert.SerializeObject(oCliente._cliente);
            }
            else
            {
                return oCliente._cliente.Error;
            }
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}