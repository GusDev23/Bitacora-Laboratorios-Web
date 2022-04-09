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
    public partial class WebFormGradoEspecialidad : System.Web.UI.Page
    {
        BLLGradoEspecialidad objGS;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Config temp = new Config();
                objGS = new BLLGradoEspecialidad(temp.cadenaConexion);
                Session["session"] = objGS;
            }
            else
                objGS = (BLLGradoEspecialidad)Session["session"];
        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            string msj = "";
            Ent_GradoEspecialidad temp = new Ent_GradoEspecialidad()
            {
                Titulo=txtTitulo.Text,
                Institucion=txtInstitucion.Text,
                Pais=txtPais.Text
            };
            if (objGS.InsertaGradoEspecialidad(temp, ref msj))
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
            List<Ent_GradoEspecialidad> temp;
            temp = objGS.MostrarGradoEspecialidad(ref msj);
            foreach (Ent_GradoEspecialidad item in temp)
            {
                GridView1.DataSource = temp;
                GridView1.DataBind();
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            string msj = "";
            Ent_GradoEspecialidad temp = new Ent_GradoEspecialidad()
            {
                Id = Convert.ToInt16(GridView1.SelectedRow.Cells[1].Text),
                Titulo = txtTitulo.Text,
                Institucion=txtInstitucion.Text,
                Pais=txtPais.Text
            };
            if (objGS.ModificarGradoEspecialidad(temp, ref msj))
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

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            string msj = "";
            Ent_GradoEspecialidad temp = new Ent_GradoEspecialidad()
            {
                Id = Convert.ToInt16(GridView1.SelectedRow.Cells[1].Text),
                Titulo = txtTitulo.Text,
                Institucion = txtInstitucion.Text,
                Pais = txtPais.Text
            };
            objGS.EliminarGradoEspecialidad(ref msj, temp);
            this.ClientScript.RegisterStartupScript(this.GetType(), "isBien", "<script> Mimessage('','" + msj + "','success') </script>");
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTitulo.Text = "";
            txtInstitucion.Text = "";
            txtPais.Text = "";
            txtTitulo.Text = HttpUtility.HtmlDecode(GridView1.SelectedRow.Cells[2].Text);
            txtInstitucion.Text = HttpUtility.HtmlDecode(GridView1.SelectedRow.Cells[3].Text);
            txtPais.Text = HttpUtility.HtmlDecode(GridView1.SelectedRow.Cells[4].Text);
        }
    }
}