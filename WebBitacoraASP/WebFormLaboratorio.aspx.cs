using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassBLL;
using ClassEntidades;

namespace WebBitacoraASP
{
    public partial class WebFormLaboratorio : System.Web.UI.Page
    {
        
        BLL_Laboratorio objLab;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Config temp = new Config();
                objLab = new BLL_Laboratorio(temp.cadenaConexion);
                Session["session"] = objLab;
            }
            else
                objLab = (BLL_Laboratorio)Session["session"];
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            string msj = "";            
            Ent_Laboratorio temp = new Ent_Laboratorio()
            {
                Edificio = txtEdificio.Text,
                Laboratorio = txtLaboratorio.Text,
                Descripcion = txtDescripcion.Text
            };
            if (objLab.InsertaLaboratorio(temp, ref msj))
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
            List<Ent_Laboratorio> temp;
            temp = objLab.MostrarLaboratorio(ref msj);
            foreach (Ent_Laboratorio item in temp)
            {
                GridView1.DataSource = temp;
                GridView1.DataBind();
            }
        }
        protected void brnModificar_Click(object sender, EventArgs e)
        {
            string msj = "";
            Ent_Laboratorio temp = new Ent_Laboratorio()
            {
                id = Convert.ToInt16(GridView1.SelectedRow.Cells[1].Text),
                Edificio = txtEdificio.Text,
                Laboratorio = txtLaboratorio.Text,
                Descripcion = txtDescripcion.Text
            };
            if (objLab.ModificarLaboratorio(temp, ref msj))
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
            txtDescripcion.Text = "";
            txtEdificio.Text = "";
            txtLaboratorio.Text = "";
            txtEdificio.Text= HttpUtility.HtmlDecode(GridView1.SelectedRow.Cells[2].Text);
            txtLaboratorio.Text = HttpUtility.HtmlDecode(GridView1.SelectedRow.Cells[3].Text);
            txtDescripcion.Text = HttpUtility.HtmlDecode(GridView1.SelectedRow.Cells[4].Text);
        }

        protected void btnModificar_Click(object sender, EventArgs e)//eliminar
        {
            string msj = "";
            Ent_Laboratorio temp = new Ent_Laboratorio()
            {
                id = Convert.ToInt16(GridView1.SelectedRow.Cells[1].Text),
                Edificio = txtEdificio.Text,
                Laboratorio = txtLaboratorio.Text,
                Descripcion = txtDescripcion.Text
            };
            objLab.EliminarLaboratorio(ref msj, temp);
            this.ClientScript.RegisterStartupScript(this.GetType(), "isBien", "<script> Mimessage('','" + msj + "','success') </script>");
        }
    }
}