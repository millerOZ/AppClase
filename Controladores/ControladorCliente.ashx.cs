using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using AppClase.Modelos;
using Newtonsoft.Json;

namespace AppClase.Controladores
{
    public class ControladorCliente : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            StreamReader reader = new StreamReader(context.Request.InputStream);
            string DatosCliente = reader.ReadToEnd();
            //Vamos a convertir el texto que está en la variable DatosCliente, a una clase: del modelo Cliente
            //Se hace con las clases de Newtonsoft, utilizar la clase jsonconvert
            Cliente _Cliente = JsonConvert.DeserializeObject<Cliente>(DatosCliente);

           
            context.Response.Write("Hello " +_Cliente.Nombre + " "+_Cliente.PrimerApellido + " "+_Cliente.SegundoApellido);
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