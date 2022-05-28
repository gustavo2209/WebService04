﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebService04
{
    /// <summary>
    /// Descripción breve de WebServicePeru
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServicePeru : System.Web.Services.WebService
    {

        [WebMethod]
        public List<object[]> departamentos()
        {
            List<object[]> list = new List<object[]>();

            using(var model = new ModelPeru())
            {
                var query = from depa in model.departamentos
                            select new
                            {
                                iddepartamento = depa.iddepartamento,
                                departamento = depa.departamento
                            };

                foreach(var fil in query)
                {
                    list.Add(new object[] { fil.iddepartamento, fil.departamento });
                }
            }
            return list;
        }
    }
}
