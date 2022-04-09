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
    public class BLLAsistencia
    {
        private OperacionesSQL_DAL objDAL = new OperacionesSQL_DAL();

        public BLLAsistencia(string conexion)
        {
            objDAL.cadenaConexion = conexion;
        }
        public Boolean InsertaAsistencia(Ent_Asistencia nuevo, ref string msj)
        {
            Boolean salida = false;
            string inserta = "Insert into Asistencia(Fecha,F_ProfeCuatri,F_Laboratorio,F_HoraEntrada,F_HoraSalida,N_Alumnos,Tema) " +
                "values(@fe,@pc,@lab,@he,@hs,@na,@te);";
            List<SqlParameter> lista = new List<SqlParameter>();
            lista.Add(new SqlParameter()
            {
                ParameterName = "fe",
                SqlDbType = SqlDbType.Date,
                Value = nuevo.Fecha
            });
            lista.Add(new SqlParameter()
            {
                ParameterName = "pc",
                SqlDbType = SqlDbType.Int,
                Value = nuevo.f_ProfeCuatri
            });
            lista.Add(new SqlParameter()
            {
                ParameterName = "lab",
                SqlDbType = SqlDbType.SmallInt,
                Value = nuevo.f_Laboratorio
            });
            lista.Add(new SqlParameter()
            {
                ParameterName = "he",
                SqlDbType = SqlDbType.TinyInt,
                Value = nuevo.f_HoraEntrada
            });
            lista.Add(new SqlParameter()
            {
                ParameterName = "hs",
                SqlDbType = SqlDbType.TinyInt,
                Value = nuevo.f_HoraSalida
            });
            lista.Add(new SqlParameter()
            {
                ParameterName = "na",
                SqlDbType = SqlDbType.TinyInt,
                Value = nuevo.N_Alumnos
            });
            lista.Add(new SqlParameter()
            {
                ParameterName = "te",
                SqlDbType = SqlDbType.VarChar,
                Size = 250,
                Value = nuevo.Tema
            });
            SqlConnection cnt = objDAL.AbrirConexion(ref msj);
            salida = objDAL.ModificarBDParametros(inserta, cnt, ref msj, lista);

            return salida;
        }//TERMINAR DE MODIFICAR
        public List<Ent_Asistencia> MostrarAsistencias(ref string men)
        {
            string msj = "";
            string query = "SELECT Id_Asistencia,Fecha,F_ProfeCuatri,F_Laboratorio,F_horaEntrada,F_horaSalida,N_Alumnos,Tema FROM Asistencia;";
            SqlDataReader atrapa = null;
            SqlConnection con = null;
            con = objDAL.AbrirConexion(ref msj);
            List<SqlParameter> noParametros = new List<SqlParameter>();
            atrapa = objDAL.EjecutaConsultaDRParametros(con, query, ref msj, noParametros);
            List<Ent_Asistencia> lista = new List<Ent_Asistencia>();
            if (atrapa != null)
            {
                while (atrapa.Read())
                {
                    lista.Add(new Ent_Asistencia()
                    {
                        Id = (int)atrapa[0],
                        Fecha = Convert.ToDateTime(atrapa[1]),
                        f_ProfeCuatri = (int)atrapa[2],
                        f_Laboratorio = (Int16)atrapa[3],
                        f_HoraEntrada = (Byte)atrapa[4],
                        f_HoraSalida = (Byte)atrapa[5],
                        N_Alumnos = (Byte)atrapa[6],
                        Tema = atrapa[7].ToString()
                    });
                }
            }
            else
            {
                men = "DataReader no tiene datos";
            }
            return lista;
        }
        public Boolean ModificarAsistencia(Ent_Asistencia asistencia,ref string msj)
        {
            SqlConnection conexion;
            List<SqlParameter> lista = new List<SqlParameter>();
            SqlParameter temp = null;
            conexion = objDAL.AbrirConexion(ref msj);
            string sentencia = "update Asistencia set Fecha=@fe,F_ProfeCuatri=@pc,F_Laboratorio=@lab,F_HoraEntrada=@he,F_HoraSalida=@hs,N_Alumnos=@na,Tema=@te where id_Asistencia=@id";
            temp = new SqlParameter()
            {
                ParameterName = "fe",
                SqlDbType = SqlDbType.Date,
                Value = asistencia.Fecha
            };
            lista.Add(temp);
            temp = new SqlParameter()
            {
                ParameterName = "pc",
                SqlDbType = SqlDbType.Int,
                Value = asistencia.f_ProfeCuatri
            };
            lista.Add(temp);
            temp = new SqlParameter()
            {
                ParameterName = "lab",
                SqlDbType = SqlDbType.SmallInt,
                Value = asistencia.f_Laboratorio
            };
            lista.Add(temp);
            temp = new SqlParameter()
            {
                ParameterName = "he",
                SqlDbType = SqlDbType.TinyInt,
                Value = asistencia.f_HoraEntrada
            };
            lista.Add(temp);
            temp = new SqlParameter()
            {
                ParameterName = "hs",
                SqlDbType = SqlDbType.TinyInt,
                Value = asistencia.f_HoraSalida
            };
            lista.Add(temp);
            temp = new SqlParameter()
            {
                ParameterName = "na",
                SqlDbType = SqlDbType.TinyInt,
                Value = asistencia.N_Alumnos

            };
            lista.Add(temp);
            temp = new SqlParameter()
            {
                ParameterName = "te",
                SqlDbType = SqlDbType.VarChar,
                Size = 250,
                Value = asistencia.Tema
            };
            lista.Add(temp);
            temp = new SqlParameter()
            {
                ParameterName = "id",
                SqlDbType = SqlDbType.Int,
                Value = asistencia.Id
            };
            lista.Add(temp);
            Boolean salida = objDAL.ModificarBDParametros(sentencia, conexion, ref msj, lista);
            return salida;
        }
        public void EliminarAsistencia(ref string msj, Ent_Asistencia asis)
        {
            SqlConnection conexion = null;
            int id = asis.Id;
            conexion = objDAL.AbrirConexion(ref msj);
            List<SqlParameter> noParametros = new List<SqlParameter>();
            Boolean resul = objDAL.ModificarBDParametros("delete from Asistencia where id_Asistencia=" + id + ";", conexion, ref msj, noParametros);
            if (resul)
            {
                msj = "Asistencia eliminada";
            }
            else
                msj = "No eliminado";
        }
        public SqlDataReader MuestraProfeCuatri()
        {
            SqlDataReader container = null;
            SqlConnection conexion = null;
            string msj = "";
            conexion = objDAL.AbrirConexion(ref msj);
            container = objDAL.EjecutaConsultaDR(conexion, "select id_AsignaPro,Nombre,Ap_pat,Ap_Mat from AsignaProfeMateriaCuatri " +
                "inner join Profesor on F_Profe=ID_Profe", ref msj);
            return container;
        }
        public SqlDataReader MuestraLaboratorio()
        {
            SqlDataReader container = null;
            SqlConnection conexion = null;
            string msj = "";
            conexion = objDAL.AbrirConexion(ref msj);
            container =objDAL.EjecutaConsultaDR(conexion, "select F_laboratorio,Edificio,Laboratorio from Asistencia " +
                "inner join Laboratorio on F_laboratorio=Id_laboratorio", ref msj);
            return container;
        }
        public SqlDataReader MuestraHoraEntrada()
        {
            SqlDataReader container = null;
            SqlConnection conexion = null;
            string msj = "";
            conexion = objDAL.AbrirConexion(ref msj);
            container = objDAL.EjecutaConsultaDR(conexion, "select F_horaEntrada,Hora from Asistencia " +
                "inner join horas on F_horaEntrada=id_horas", ref msj);
            return container;
        }
        public SqlDataReader MuestraHoraSalida()
        {
            SqlDataReader container = null;
            SqlConnection conexion = null;
            string msj = "";
            conexion = objDAL.AbrirConexion(ref msj);
            container = objDAL.EjecutaConsultaDR(conexion, "select F_horaSalida,Hora from Asistencia " +
                "inner join horas on F_horaSalida=id_horas", ref msj);
            return container;
        }
    }
}
