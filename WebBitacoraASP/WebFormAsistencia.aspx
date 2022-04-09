<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormAsistencia.aspx.cs" Inherits="WebBitacoraASP.WebFormAsistencia" %>

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
        <li class="nav-item active" role="presentation">
            <a class="nav-link active"  href="WebFormAsistencia.aspx" type="button" role="tab"  aria-selected="true">Asistencia</a>
        </li>
        <li class="nav-item" role="presentation">
            <a class="nav-link"  href="WebFormLaboratorio.aspx" type="button" role="tab"  aria-selected="false">Laboratorio</a>
        </li>
        <li class="nav-item" role="presentation">
            <a class="nav-link "  href="WebFormGradoEspecialidad.aspx" role="tab" aria-selected="false">Grado especialidad</a>
        </li>
    </ul>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
       
                <div class="col">
                    
                    <br />
                    Fecha Asistencia
                    <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
                    <br />
                    Profe Cuatri<br />
                    <asp:DropDownList ID="DropDownList1" runat="server">
                    </asp:DropDownList>
                    <br />
                    <br />
                    Laboratorio<br />
                    <asp:DropDownList ID="DropDownList2" runat="server">
                    </asp:DropDownList>
                    <br />
                    <br />
                    Hora entrada<br />
                    <asp:DropDownList ID="DropDownList3" runat="server">
                    </asp:DropDownList>
                    <br />
                    <br />
                    Hora salida<br />
                    <asp:DropDownList ID="DropDownList4" runat="server">
                    </asp:DropDownList>
                    <br />
                    <br />
                    Numero de alumnos<br />
                    <asp:TextBox ID="txtNalumnos" runat="server"></asp:TextBox>
                    <br />
                    <br />
                    Tema<br />
                    <asp:TextBox ID="txtTema" runat="server"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Button ID="btnInsertar" runat="server" Text="Insertar Asistencia" OnClick="btnInsertar_Click" />
                    <br />

                </div>
                  
                <div class="col">
                   
                    <br />
                    <asp:Button ID="btnMostrar" runat="server" Text="Mostrar Asistencias" OnClick="btnMostrar_Click" />
&nbsp;
                    <asp:Button ID="btnModificar" runat="server" Text="Modificar Asistencia" OnClick="btnModificar_Click" />
                    <br />
                    <br />
                    <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                        <Columns>
                        <asp:CommandField ShowSelectButton="True"/>
                    </Columns>
                    </asp:GridView>
                    <br />
                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar Asistencia" OnClick="btnEliminar_Click" />
                    <br />

                </div>
                
            </div>
        </div>

    </form>
</body>
</html>
