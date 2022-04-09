using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using ClassEntidades;
using DAL_Bitacora;

namespace ClassBLL
{
    public class BLL_Laboratorio
    {
        private OperacionesSQL_DAL objDAL = new OperacionesSQL_DAL();
        public BLL_Laboratorio(string conexion)
        {
            objDAL.cadenaConexion = conexion;
        }
        public Boolean InsertaLaboratorio(Ent_Laboratorio nuevo, ref string msj)
        {
            Boolean salida = false;
            string inserta = "Insert into Laboratorio(Edificio,Laboratorio,Descripción) values(@ed,@lab,@des);";
            List<SqlParameter> lista = new List<SqlParameter>();
            lista.Add(new SqlParameter()
            {
                ParameterName = "ed",
                SqlDbType = SqlDbType.VarChar,
                Size = 5,
                Value = nuevo.Edificio
            });
            lista.Add(new SqlParameter()
            {
                ParameterName = "lab",
                SqlDbType = SqlDbType.VarChar,
                Size = 5,
                Value = nuevo.Laboratorio
            });
            lista.Add(new SqlParameter()
            {
                ParameterName = "des",
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                Value = nuevo.Descripcion
            });
            SqlConnection cnt = objDAL.AbrirConexion(ref msj);
            salida = objDAL.ModificarBDParametros(inserta, cnt, ref msj, lista);

            return salida;
        }
        public List<Ent_Laboratorio> MostrarLaboratorio(ref string men)
        {
            string msj = "";
            string query = "select id_Laboratorio,Edificio,Laboratorio,Descripción from Laboratorio;";
            SqlDataReader atrapa = null;
            SqlConnection con = null;
            con = objDAL.AbrirConexion(ref msj);
            List<SqlParameter> noParametros = new List<SqlParameter>();
            atrapa = objDAL.EjecutaConsultaDRParametros(con, query, ref msj,noParametros);
            List<Ent_Laboratorio> lista = new List<Ent_Laboratorio>();
            if (atrapa != null)
            {
                while (atrapa.Read())
                {
                    lista.Add(new Ent_Laboratorio()
                    {
                        id = (Int16)atrapa[0],
                        Edificio = atrapa[1].ToString(),
                        Laboratorio = atrapa[2].ToString(),
                        Descripcion = atrapa[3].ToString()
                    });
                }
            }
            else
            {
                men = "DataReader no tiene datos";
            }
            return lista;
        }
        public Boolean ModificarLaboratorio(Ent_Laboratorio lab,ref string msj )
        {
            
            SqlConnection conexion;
            List<SqlParameter> lista = new List<SqlParameter>();
            SqlParameter temp = null;
            conexion = objDAL.AbrirConexion(ref msj);
            string sentencia = "update Laboratorio set Edificio=@ed,Laboratorio=@lab,Descripción=@des where id_Laboratorio=@id";
            temp = new SqlParameter()
            {
                ParameterName = "ed",
                SqlDbType = SqlDbType.VarChar,
                Size=5,
                Value =lab.Edificio
            };
            lista.Add(temp);
            temp = new SqlParameter()
            {
                ParameterName = "lab",
                SqlDbType = SqlDbType.VarChar,
                Size = 5,
                Value = lab.Laboratorio
            };
            lista.Add(temp);
            temp = new SqlParameter()
            {
                ParameterName = "des",
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                Value = lab.Descripcion
            };
            lista.Add(temp);
            temp = new SqlParameter()
            {
                ParameterName = "id",
                SqlDbType = SqlDbType.SmallInt,
                Value = lab.id
            };
            lista.Add(temp);
            Boolean salida =objDAL.ModificarBDParametros(sentencia, conexion, ref msj, lista);
            return salida;
        }
        public Boolean EliminarLaboratorio(ref string msj, Ent_Laboratorio lab)
        {
            SqlConnection conexion = null;
            Int16 id = lab.id;
            conexion = objDAL.AbrirConexion(ref msj);
            List<SqlParameter> noParametros = new List<SqlParameter>();
            Boolean resul = objDAL.ModificarBDParametros("delete from Laboratorio where id_Laboratorio=" + id + ";", conexion, ref msj,noParametros);
            if (resul)
            {
                msj = "Laboratorio eliminado";
            }
            else
                msj = "No eliminado";

            return resul;
        }
        
    }
}
