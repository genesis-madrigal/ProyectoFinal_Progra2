<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="UserRoles.aspx.cs" Inherits="ProyectoFinal_Progra2.Roles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container text-center">
    <h1 class="display-3"> Mantenimiento de Roles </h1>
    <p> &nbsp;</p>
    <p> &nbsp;</p>

<div class="d-flex justify-content-center">
    <asp:GridView ID="gvUserRoles" runat="server" AutoGenerateColumns="False" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowPaging="True">
        
        <Columns>
                    <asp:BoundField DataField="LogInUser" HeaderText="Log In del Usuario" SortExpression="LogInUser" />
                    <asp:BoundField DataField="RolID" HeaderText="ID del Rol" SortExpression="RolID" />
          </Columns>
    </asp:GridView>
</div>
        
           <p> &nbsp;</p>
        <p> &nbsp;</p>
        <p>  
<asp:Label ID="lblLogInUser" class="lead" runat="server" Text="Log In del Usuario:"></asp:Label>
        </p>
    <p>  
<asp:TextBox ID="tbLogInUser" class="round form-control" runat="server" placeholder="Usuario" ></asp:TextBox>
        </p>
    <p> 
<asp:Label ID="lblRolID" class="lead" runat="server" Text="Nombre:"></asp:Label>
    </p>
    <p> 
      <asp:DropDownList ID="ddlRolID"  class="round form-control" runat="server" OnSelectedIndexChanged="Page_Load"></asp:DropDownList>
    </p>
    <p> &nbsp;</p>
    <p> 
        <asp:Button ID="btnAgregar" class="btn btn-outline-dark" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
        <asp:Button ID="btnConsultar" class="btn btn-outline-dark" runat="server" Text="Consultar" OnClick="btnConsultar_Click" />
        <asp:Button ID="btnModificar" class="btn btn-outline-dark" runat="server" Text="Modificar" OnClick="btnModificar_Click" />
        <asp:Button ID="btnEliminar" class="btn btn-outline-dark" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
    </p>
    <p> &nbsp;</p>
    


    </div>
</asp:Content>
