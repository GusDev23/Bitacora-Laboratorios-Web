<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormLaboratorio.aspx.cs" Inherits="WebBitacoraASP.WebFormLaboratorio" %>

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
            <a class="nav-link active"  href="WebFormLaboratorio.aspx" type="button" role="tab"  aria-selected="false">Laboratorio</a>
        </li>
        <li class="nav-item" role="presentation">
            <a class="nav-link"  href="WebFormGradoEspecialidad.aspx" role="tab" aria-selected="false">Grado especialidad</a>
        </li>
    </ul>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
             <div class="col">
            <br />
            Edificio<br />
            <asp:TextBox ID="txtEdificio" runat="server"></asp:TextBox>
            <br />
            <br />
            Laboratorio<br />
            <asp:TextBox ID="txtLaboratorio" runat="server"></asp:TextBox>
            <br />
            <br />
            Descripcion<br />
            <asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnAgregar" runat="server" OnClick="btnAgregar_Click" Text="Agregar" />
            
            </div>
            <div class="col">
                <br />
                <br />
            <asp:Button ID="btnMostrar" runat="server" OnClick="btnMostrar_Click" Text="Mostrar" Width="69px" />

            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnModificar_Click" />
            
            <asp:Button ID="brnModificar" runat="server" OnClick="brnModificar_Click" Text="Modificar" Width="84px" />
                <br />
                <br />
            <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <Columns>
                   <asp:CommandField ShowSelectButton="True"/>
               </Columns>
            </asp:GridView>
             </div>
            </div>
        </div>
    </form>
</body>
</html>
