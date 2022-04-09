using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ClassEntidades;
using DAL_Bitacora;
namespace ClassBLL
{
    public class BLLGradoEspecialidad
    {
        private OperacionesSQL_DAL objDAL = new OperacionesSQL_DAL();

        public BLLGradoEspecialidad(string conexion)
        {
            objDAL.cadenaConexion = conexion;
        }
        public Boolean InsertaGradoEspecialidad(Ent_GradoEspecialidad nuevo, ref string msj)
        {
            Boolean salida = false;
            string inserta = "Insert into GradoEspecialidad(Titulo,Institucion,Pais) values(@ti,@ins,@pa);";
            List<SqlParameter> lista = new List<SqlParameter>();
            lista.Add(new SqlParameter()
            {
                ParameterName = "ti",
                SqlDbType = SqlDbType.VarChar,
                Size = 150,
                Value = nuevo.Titulo
            });
            lista.Add(new SqlParameter()
            {
                ParameterName = "ins",
                SqlDbType = SqlDbType.VarChar,
                Size = 150,
                Value = nuevo.Institucion
            });
            lista.Add(new SqlParameter()
            {
                ParameterName = "pa",
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                Value = nuevo.Pais
            });
            SqlConnection cnt = objDAL.AbrirConexion(ref msj);
            salida = objDAL.ModificarBDParametros(inserta, cnt, ref msj, lista);

            return salida;
        }
        public List<Ent_GradoEspecialidad> MostrarGradoEspecialidad(ref string men)
        {
            string msj = "";
            string query = "select id_Grado,Titulo,Institucion,Pais from GradoEspecialidad;";
            SqlDataReader atrapa = null;
            SqlConnection con = null;
            con = objDAL.AbrirConexion(ref msj);
            List<SqlParameter> noParametros = new List<SqlParameter>();
            atrapa = objDAL.EjecutaConsultaDRParametros(con, query, ref msj, noParametros);
            List<Ent_GradoEspecialidad> lista = new List<Ent_GradoEspecialidad>();
            if (atrapa != null)
            {
                while (atrapa.Read())
                {
                    lista.Add(new Ent_GradoEspecialidad()
                    {
                        Id = (Int16)atrapa[0],
                        Titulo = atrapa[1].ToString(),
                        Institucion = atrapa[2].ToString(),
                        Pais = atrapa[3].ToString()
                    });
                }
            }
            else
            {
                men = "DataReader no tiene datos";
            }
            return lista;
        }
        public Boolean ModificarGradoEspecialidad(Ent_GradoEspecialidad especialidad,ref string msj)
        {
            SqlConnection conexion;
            List<SqlParameter> lista = new List<SqlParameter>();
            SqlParameter temp = null;
            conexion = objDAL.AbrirConexion(ref msj);
            string sentencia = "update GradoEspecialidad set Titulo=@ti,Institucion=@ins,Pais=@pa where id_Grado=@id";
            temp = new SqlParameter()
            {
                ParameterName = "ti",
                SqlDbType = SqlDbType.VarChar,
                Size = 150,
                Value = especialidad.Titulo
            };
            lista.Add(temp);
            temp = new SqlParameter()
            {
                ParameterName = "ins",
                SqlDbType = SqlDbType.VarChar,
                Size = 150,
                Value = especialidad.Institucion
            };
            lista.Add(temp);
            temp = new SqlParameter()
            {
                ParameterName = "pa",
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                Value = especialidad.Pais
            };
            lista.Add(temp);
            temp = new SqlParameter()
            {
                ParameterName = "id",
                SqlDbType = SqlDbType.SmallInt,
                Value = especialidad.Id
            };
            lista.Add(temp);
            Boolean salida = objDAL.ModificarBDParametros(sentencia, conexion, ref msj, lista);
            return salida;
        }
        public Boolean EliminarGradoEspecialidad(ref string msj, Ent_GradoEspecialidad esp)
        {
            SqlConnection conexion = null;
            Int16 id = esp.Id;
            conexion = objDAL.AbrirConexion(ref msj);
            List<SqlParameter> noParametros = new List<SqlParameter>();
            Boolean resul = objDAL.ModificarBDParametros("delete from GradoEspecialidad where id_Grado=" + id + ";", conexion, ref msj, noParametros);
            if (resul)
            {
                msj = "Grado Especialidad eliminado";
            }
            else
                msj = "No eliminado";

            return resul;
        }
    }
}
