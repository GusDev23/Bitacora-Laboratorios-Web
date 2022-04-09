using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBitacoraASP
{
    public class Config
    {
        public string cadenaConexion { get; set; }
        public Config()
        {
            cadenaConexion = @"Data Source=DESKTOP-LUHL6NJ;" +
                " Initial Catalog=Bitacora2021LabsUTP; Integrated Security=true;";
        }
        public string LimpiaCadena(string men)
        {//CAMBIAR A SWITCH
            string cad = "";
            for (int i = 0; i < 150; i++)
            {
                if (men[i] == '\'')
                {
                    cad = cad + '-';
                }
                if (men[i] == '"')
                {
                    cad = cad + '-';
                }
                if (men[i] == '`')
                {
                    cad = cad + '-';
                }
                if (men[i] == ',')
                {
                    cad = cad + '-';
                }
                if (men[i] == '\\')
                {
                    cad = cad + '-';
                }
                if (men[i] == ':')
                {
                    cad = cad + '-';
                }
                else
                    cad = cad + men[i];
            }
            return cad;
        }
    }
}