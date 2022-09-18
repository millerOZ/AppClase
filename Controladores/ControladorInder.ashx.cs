using AppClase.Clases;
using AppClase.Modelos;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Web;

namespace AppClase.Controladores
{
    public class ControladorInder : IHttpHandler
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
                Inder _Inder = JsonConvert.DeserializeObject<Inder>(DatosCliente);


                switch (_Inder.Comando.ToUpper())
                {
                    case "INSERTAR":
                        context.Response.Write(Insertar(_Inder));
                        break;
                }


            }
            catch (Exception ex)
            {
                context.Response.Write(ex.ToString());
            }




        }
        private string Insertar(Inder _inder)
        {
            clsInder oInder = new clsInder();
            oInder._inder = _inder;
            if (oInder.Insertar())
            {
                return "Se insertó en la base de datos";
            }
            else
            {
                return oInder._inder.Error;
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