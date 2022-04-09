using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassBLL;
using ClassEntidades;
using System.Data.SqlClient;
namespace WebBitacoraASP
{
    public partial class WebFormAsistencia : System.Web.UI.Page
    {
        BLLAsistencia objAsistencia;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Config temp = new Config();
                objAsistencia = new BLLAsistencia(temp.cadenaConexion);
                Session["session"] = objAsistencia;
                CargaProfeCuatri();
                CargaLab();
                CargaHentrada();
                CargaHsalida();
            }
            else
                objAsistencia = (BLLAsistencia)Session["session"];
        }
        private void CargaProfeCuatri()
        {
            SqlDataReader atrapa = objAsistencia.MuestraProfeCuatri();
            DropDownList1.Items.Clear();
            if (atrapa != null)
            {
                while (atrapa.Read())
                {
                    DropDownList1.Items.Add(
                        new ListItem(atrapa[1].ToString() + " " + atrapa[2].ToString() + " " + atrapa[3].ToString(), atrapa[0].ToString()));
                }
            }
        }
        private void CargaLab()
        {
            SqlDataReader atrapa = objAsistencia.MuestraLaboratorio();
            DropDownList2.Items.Clear();
            if (atrapa != null)
            {
                while (atrapa.Read())
                {
                    DropDownList2.Items.Add(
                        new ListItem(atrapa[1].ToString() + " " + atrapa[2].ToString(), atrapa[0].ToString()));
                }
            }
        }
        private void CargaHentrada()
        {
            SqlDataReader atrapa = objAsistencia.MuestraHoraEntrada();
            DropDownList3.Items.Clear();
            if (atrapa != null)
            {
                while (atrapa.Read())
                {
                    DropDownList3.Items.Add(
                        new ListItem(atrapa[1].ToString(), atrapa[0].ToString()));
                }
            }
        }
        private void CargaHsalida()
        {
            SqlDataReader atrapa = objAsistencia.MuestraHoraSalida();
            DropDownList4.Items.Clear();
            if (atrapa != null)
            {
                while (atrapa.Read())
                {
                    DropDownList4.Items.Add(
                        new ListItem(atrapa[1].ToString(), atrapa[0].ToString()));
                }
            }
        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            string msj = "";
            Ent_Asistencia temp = new Ent_Asistencia()
            {
                Fecha = Calendar1.SelectedDate,
                f_ProfeCuatri = int.Parse(DropDownList1.Items[DropDownList1.SelectedIndex].Value),
                f_Laboratorio = Convert.ToInt16(DropDownList2.Items[DropDownList2.SelectedIndex].Value),
                f_HoraEntrada = Convert.ToByte(DropDownList3.Items[DropDownList3.SelectedIndex].Value),
                f_HoraSalida = Convert.ToByte(DropDownList4.Items[DropDownList4.SelectedIndex].Value),
                N_Alumnos = Convert.ToByte(txtNalumnos.Text),
                Tema = txtTema.Text
            };
            if (objAsistencia.InsertaAsistencia(temp, ref msj))
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "isBien", "<script> Mimessage('Todo Bien','" + msj + "','success') </script>");
            }
            else
            {
                Config ob = new Config();
                string m = ob.LimpiaCadena(msj);
                this.ClientScript.RegisterStartupScript(this.GetType(), "isBien", "<script> Mimessage('Hubo Error','" + "','error') </script>");
            }
        }

        protected void btnMostrar_Click(object sender, EventArgs e)
        {
            string msj = "";
            List<Ent_Asistencia> temp;
            temp = objAsistencia.MostrarAsistencias(ref msj);
            foreach (Ent_Asistencia item in temp)
            {
                GridView1.DataSource = temp;
                GridView1.DataBind();
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            string msj = "";
            Ent_Asistencia temp = new Ent_Asistencia()
            {
                Id= Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text),
                Fecha = Calendar1.SelectedDate,
                f_ProfeCuatri = int.Parse(DropDownList1.Items[DropDownList1.SelectedIndex].Value),
                f_Laboratorio = Convert.ToInt16(DropDownList2.Items[DropDownList2.SelectedIndex].Value),
                f_HoraEntrada = Convert.ToByte(DropDownList3.Items[DropDownList3.SelectedIndex].Value),
                f_HoraSalida = Convert.ToByte(DropDownList4.Items[DropDownList4.SelectedIndex].Value),
                N_Alumnos = Convert.ToByte(txtNalumnos.Text),
                Tema = txtTema.Text
            };
            if (objAsistencia.ModificarAsistencia(temp, ref msj))
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "isBien", "<script> Mimessage('Todo Bien','" + msj + "','success') </script>");

            }
            else
            {
                Config ob = new Config();
                string m = ob.LimpiaCadena(msj);
                this.ClientScript.RegisterStartupScript(this.GetType(), "Mal", "<script> Mimessage('Hubo Error','" + "','error') </script>");
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNalumnos.Text = "";
            txtTema.Text = "";
            txtNalumnos.Text= HttpUtility.HtmlDecode(GridView1.SelectedRow.Cells[7].Text);
            txtTema.Text= HttpUtility.HtmlDecode(GridView1.SelectedRow.Cells[8].Text);
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            string msj = "";
            Ent_Asistencia temp = new Ent_Asistencia()
            {
                Id = Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text)
            };
            objAsistencia.EliminarAsistencia(ref msj, temp);
            this.ClientScript.RegisterStartupScript(this.GetType(), "isBien", "<script> Mimessage('','" + msj + "','success') </script>");

        }
    }
}