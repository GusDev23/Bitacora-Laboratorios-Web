<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormGradoEspecialidad.aspx.cs" Inherits="WebBitacoraASP.WebFormGradoEspecialidad" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <!-- CSS only -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous"/>
    <!-- JavaScript Bundle with Popper -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-ka7Sk0Gln4gmtz2MlQnikT1wXgYsOg+OMhuP+IlRH9sENBO0LRn5q+8nbTov4+1p" crossorigin="anonymous"></script>
    <link href="css/sweetalert2.min.css" rel="stylesheet" />
    <script src="js/sweetalert2.min.js"></script>
    <script src="js/MiSweet.js"></script>
</head>
<body>
    <ul class="nav nav-tabs" id="myTab" role="tablist" style="background-color:cornflowerblue">
        <li class="" role="presentation">
            <a class="nav-link"  href="WebFormAsistencia.aspx" type="button" role="tab"  aria-selected="true">Asistencia</a>
        </li>
        <li class="nav-item" role="presentation">
            <a class="nav-link"  href="WebFormLaboratorio.aspx" type="button" role="tab"  aria-selected="false">Laboratorio</a>
        </li>
        <li class="nav-item" role="presentation">
            <a class="nav-link active"  href="WebFormGradoEspecialidad.aspx" role="tab" aria-selected="false">Grado Especialidad</a>
        </li>
    </ul>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col">
            <br />
            Titulo<br />
            <asp:TextBox ID="txtTitulo" runat="server"></asp:TextBox>
            <br />
            <br />
            Institucion<br />
            <asp:TextBox ID="txtInstitucion" runat="server" style="margin-bottom: 0px"></asp:TextBox>
            <br />
            <br />
            Pais<br />
            <asp:TextBox ID="txtPais" runat="server"></asp:TextBox>
            <br />
            <br />
            <br />
            <asp:Button ID="btnInsertar" runat="server" OnClick="btnInsertar_Click" Text="Insertar" />
            <br />
            <br />
                    </div>
                <div class="col">
            <asp:Button ID="btnMostrar" runat="server" OnClick="btnMostrar_Click" Text="Mostrar" />
            <asp:Button ID="btnModificar" runat="server" OnClick="btnModificar_Click" Text="Modificar" />
            <asp:Button ID="btnEliminar" runat="server" OnClick="btnEliminar_Click" Text="Eliminar" />
            <br />
            <br />
            <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <Columns>
                   <asp:CommandField ShowSelectButton="True"/>
               </Columns>
            </asp:GridView>
                    </div>
            <br />
            <br />
                </div>
        </div>
    </form>
</body>
</html>
